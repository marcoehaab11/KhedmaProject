using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class ErrorHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandler> _logger;

    public ErrorHandler(RequestDelegate next, ILogger<ErrorHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // تمرير الطلب إلى Middleware التالي
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "حدث خطأ في التطبيق."); // تسجيل الخطأ
            await HandleExceptionAsync(context, ex); // التعامل مع الخطأ
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // تعيين كود الحالة (Status Code) المناسب بناءً على نوع الخطأ
        var (statusCode, errorMessage) = GetStatusCodeAndMessage(exception);

        // تعيين نوع المحتوى كـ JSON
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        // إنشاء كائن الخطأ
        var errorResponse = new
        {
            error = errorMessage,
            details = statusCode == HttpStatusCode.InternalServerError ? null : exception.Message // إخفاء التفاصيل في حالة 500
        };

        // تحويل الكائن إلى JSON
        var jsonResponse = JsonSerializer.Serialize(errorResponse);

        // إرسال الرد إلى العميل
        return context.Response.WriteAsync(jsonResponse);
    }

    private static (HttpStatusCode statusCode, string errorMessage) GetStatusCodeAndMessage(Exception exception)
    {
        return exception switch
        {
            ArgumentNullException _ => (HttpStatusCode.BadRequest, "البيانات المطلوبة غير موجودة."),
            UnauthorizedAccessException _ => (HttpStatusCode.Unauthorized, "غير مصرح لك بالوصول إلى هذا المورد."),
            KeyNotFoundException _ => (HttpStatusCode.NotFound, "لم يتم العثور على المورد المطلوب."),
            _ => (HttpStatusCode.InternalServerError, "حدث خطأ داخلي في الخادم.")
        };
    }
}