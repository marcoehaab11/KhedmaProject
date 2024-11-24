using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Khedma.Entites.Models;
using Khedma.Entites.Repositories;
using Khedma.Entites.ViewModels;

using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using DocumentFormat.OpenXml.Office2010.ExcelAc;


namespace Keadma.DataAccess.Helpers
{
    public class Helper : IHelper
    {
        private readonly IUnitOfWork _unitOfWork;

        public Helper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetNameForStage(int id)
        {
            var NameofStage = _unitOfWork.TheStage.GetFirstorDefault(x => x.Id == id);
            if (NameofStage == null)
            {
                return "NoNameFound";
            }
            return NameofStage.Name;
        }
        public string GetNameForSingle(int id)
        {
            var NameofStage = _unitOfWork.ForSingleName.GetFirstorDefault(x => x.ForSingleNameId == id);
            if (NameofStage == null)
            {
                return "NoNameFound";
            }
            return NameofStage.Name;
        }
        public string GetNameForArt(int id)
        {
            var NameofStage = _unitOfWork.ArtsName.GetFirstorDefault(x => x.Id == id);
            if (NameofStage == null)
            {
                return "NoNameFound";
            }
            return NameofStage.Name;
        }
        private IEnumerable<Makhdoum> ReturnListOfData(int stageId, int ActivityId,int UserId=0)
        {
            switch (ActivityId)
            {
                case 1:
                    return _unitOfWork.Koral.GetAll(x => x.StageID == stageId, "Makhdoum")
                            .Select(x => new Makhdoum
                            {
                                Name = x.Makhdoum.Name,
                                DateOfBirth = x.Makhdoum.DateOfBirth,
                                PhoneNumber = x.Makhdoum.PhoneNumber
                            }).ToList();
                    break;
                case 2:
                    return  _unitOfWork.Alhan
                            .GetAll(x => x.StageID == stageId, "Makhdoum")
                            .Select(x => new Makhdoum
                            {
                                Name = x.Makhdoum.Name,
                                DateOfBirth = x.Makhdoum.DateOfBirth,
                                PhoneNumber = x.Makhdoum.PhoneNumber
                            }).ToList(); 
                    break;
                case 3:
                    return _unitOfWork.Learning
                            .GetAll(x => x.StageID == stageId, "Makhdoum")
                            .Select(x => new Makhdoum
                            {
                                Name = x.Makhdoum.Name,
                                DateOfBirth = x.Makhdoum.DateOfBirth,
                                PhoneNumber = x.Makhdoum.PhoneNumber
                            }).ToList();
                    break;
                case 4:
                    return _unitOfWork.Theater
                            .GetAll(x => x.StageID == stageId, "Makhdoum")
                            .Select(x => new Makhdoum
                            {
                                Name = x.Makhdoum.Name,
                                DateOfBirth = x.Makhdoum.DateOfBirth,
                                PhoneNumber = x.Makhdoum.PhoneNumber
                            }).ToList();
                    break;
                case 5:
                    return _unitOfWork.Coptic
                            .GetAll(x => x.StageID == stageId, "Makhdoum")
                            .Select(x => new Makhdoum
                            {
                                Name = x.Makhdoum.Name,
                                DateOfBirth = x.Makhdoum.DateOfBirth,
                                PhoneNumber = x.Makhdoum.PhoneNumber
                            }).ToList();
                    break;
                case 6:
                    return _unitOfWork.BooksAndSaves
                            .GetAll(x => x.StageID == stageId, "Makhdoum")
                            .Select(x => new Makhdoum
                            {
                                Name = x.Makhdoum.Name,
                                DateOfBirth = x.Makhdoum.DateOfBirth,
                                PhoneNumber = x.Makhdoum.PhoneNumber
                            }).ToList();
                    break;
                case 7:
                    return _unitOfWork.ForSingle
                            .GetAll(x => x.StageID == stageId, "Makhdoum")
                            .Select(x => new Makhdoum
                            {
                                Name = x.Makhdoum.Name,
                                DateOfBirth = x.Makhdoum.DateOfBirth,
                                PhoneNumber = x.Makhdoum.PhoneNumber
                            }).ToList();
                    break;
                case 8:
                    return _unitOfWork.ForSingle
                            .GetAll(x => x.StageID == stageId&&x.MakhdoumID==UserId, "Makhdoum")
                            .Select(x => new Makhdoum
                            {
                                Name = x.Makhdoum.Name,
                                DateOfBirth = x.Makhdoum.DateOfBirth,
                                PhoneNumber = x.Makhdoum.PhoneNumber
                            }).ToList();
                    break;
                default:
                    return null;
                    break;
            }
            
        }
        public byte[] GenerateWordFile(int stageId,int ActivityId)
        {
            
            var people = ReturnListOfData(stageId,ActivityId);

            // تحميل القالب
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "wordfile/form.docx");
            string tempFilePath = Path.GetTempFileName(); // إنشاء ملف مؤقت

            // نسخ القالب إلى ملف مؤقت
            System.IO.File.Copy(templatePath, tempFilePath, true);

            // فتح الملف المؤقت باستخدام Open XML SDK
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(tempFilePath, true))
            {
                var mainPart = wordDoc.MainDocumentPart;
                var document = mainPart.Document;

                // العثور على الجدول في المستند
                var table = document.Body.Elements<Table>().FirstOrDefault();
                if (table != null)
                {
                    int rowIndex = 2; // الصف الأول يبدأ من 2 أو 3 حسب تنسيق الجدول
                    int peoplePerColumn = 25; // عدد الأشخاص في كل مجموعة

                    // تقسيم الأشخاص إلى مجموعتين
                    var firstGroup = people.Take(peoplePerColumn).ToList();
                    var secondGroup = people.Skip(peoplePerColumn).Take(peoplePerColumn).ToList();

                    // أولاً: ملء الجدول بالمجموعة الأولى (العمود الأول و الثاني)
                    for (int i = 0; i < firstGroup.Count; i++)
                    {
                        var person = firstGroup[i];

                        // العثور على الصف الحالي
                        var row = table.Elements<TableRow>().ElementAtOrDefault(i + rowIndex - 1);  // استخدام i + rowIndex لتحديد الصفوف بشكل صحيح
                        if (row == null)
                        {
                            row = new TableRow();
                            table.Append(row); // إضافة صف جديد إذا لم يكن موجودًا
                        }

                        // العثور على الأعمدة في الصف الحالي
                        var cells = row.Elements<TableCell>().ToList();
                        while (cells.Count() < 4) // التأكد من أن هناك 4 أعمدة في الصف
                        {
                            cells.Add(new TableCell(new Paragraph(new Run(new Text(""))))); // إضافة خلية فارغة
                        }

                        // ملء الأعمدة بالبيانات في العمود الأول والثاني
                        cells[0].RemoveAllChildren<Paragraph>();
                        cells[0].Append(new Paragraph(new Run(new Text((i + 1).ToString())))); // رقم الصف

                        cells[1].RemoveAllChildren<Paragraph>();
                        cells[1].Append(new Paragraph(new Run(new Text(person.Name)))); // الاسم

                        cells[2].RemoveAllChildren<Paragraph>();
                        cells[2].Append(new Paragraph(new Run(new Text(person.DateOfBirth?.ToString("dd/MM/yyyy"))))); // تاريخ الميلاد
                    }

                    // ثم: ملء الجدول بالمجموعة الثانية (العمود الثالث والرابع)
                    for (int i = 0; i < secondGroup.Count; i++)
                    {
                        var person = secondGroup[i];

                        // العثور على الصف الحالي
                        var row = table.Elements<TableRow>().ElementAtOrDefault(i + rowIndex - 1);  // تحديد الصف من خلال إضافة i و rowIndex
                        if (row == null)
                        {
                            row = new TableRow();
                            table.Append(row); // إضافة صف جديد إذا لم يكن موجودًا
                        }

                        // العثور على الأعمدة في الصف الحالي
                        var cells = row.Elements<TableCell>().ToList();
                        while (cells.Count() < 6) // التأكد من أن هناك 6 أعمدة في الصف (لأنك في العمود الثالث والرابع)
                        {
                            cells.Add(new TableCell(new Paragraph(new Run(new Text(""))))); // إضافة خلية فارغة
                        }

                        // ملء الأعمدة بالبيانات في العمود الثالث والرابع
                        cells[3].RemoveAllChildren<Paragraph>();
                        cells[3].Append(new Paragraph(new Run(new Text((i + 1 + peoplePerColumn).ToString())))); // رقم الصف

                        cells[4].RemoveAllChildren<Paragraph>();
                        cells[4].Append(new Paragraph(new Run(new Text(person.Name)))); // الاسم

                        cells[5].RemoveAllChildren<Paragraph>();
                        cells[5].Append(new Paragraph(new Run(new Text(person.DateOfBirth?.ToString("dd/MM/yyyy"))))); // تاريخ الميلاد
                    }

                    // حفظ التعديلات
                    document.Save();
                }
            }
            var StageName = GetNameForStage(stageId);
            
            // تحميل الملف كاستجابة للمستخدم
            byte[] fileBytes = System.IO.File.ReadAllBytes(tempFilePath);
            string fileName = StageName + ".docx";
            return fileBytes;
        }

        public byte[] GenerateWordFileForOne(int stageId, int ActivityId,int UserId=0)
        {

            var people = ReturnListOfData(stageId, ActivityId, UserId);

            // تحميل القالب
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "wordfile/form.docx");
            string tempFilePath = Path.GetTempFileName(); // إنشاء ملف مؤقت

            // نسخ القالب إلى ملف مؤقت
            System.IO.File.Copy(templatePath, tempFilePath, true);

            // فتح الملف المؤقت باستخدام Open XML SDK
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(tempFilePath, true))
            {
                var mainPart = wordDoc.MainDocumentPart;
                var document = mainPart.Document;

                // العثور على الجدول في المستند
                var table = document.Body.Elements<Table>().FirstOrDefault();
                if (table != null)
                {
                    int rowIndex = 2; // الصف الأول يبدأ من 2 أو 3 حسب تنسيق الجدول
                    int peoplePerColumn = 25; // عدد الأشخاص في كل مجموعة

                    // تقسيم الأشخاص إلى مجموعتين
                    var firstGroup = people.Take(peoplePerColumn).ToList();
                    var secondGroup = people.Skip(peoplePerColumn).Take(peoplePerColumn).ToList();

                    // أولاً: ملء الجدول بالمجموعة الأولى (العمود الأول و الثاني)
                    for (int i = 0; i < firstGroup.Count; i++)
                    {
                        var person = firstGroup[i];

                        // العثور على الصف الحالي
                        var row = table.Elements<TableRow>().ElementAtOrDefault(i + rowIndex - 1);  // استخدام i + rowIndex لتحديد الصفوف بشكل صحيح
                        if (row == null)
                        {
                            row = new TableRow();
                            table.Append(row); // إضافة صف جديد إذا لم يكن موجودًا
                        }

                        // العثور على الأعمدة في الصف الحالي
                        var cells = row.Elements<TableCell>().ToList();
                        while (cells.Count() < 4) // التأكد من أن هناك 4 أعمدة في الصف
                        {
                            cells.Add(new TableCell(new Paragraph(new Run(new Text(""))))); // إضافة خلية فارغة
                        }

                        // ملء الأعمدة بالبيانات في العمود الأول والثاني
                        cells[0].RemoveAllChildren<Paragraph>();
                        cells[0].Append(new Paragraph(new Run(new Text((i + 1).ToString())))); // رقم الصف

                        cells[1].RemoveAllChildren<Paragraph>();
                        cells[1].Append(new Paragraph(new Run(new Text(person.Name)))); // الاسم

                        cells[2].RemoveAllChildren<Paragraph>();
                        cells[2].Append(new Paragraph(new Run(new Text(person.DateOfBirth?.ToString("dd/MM/yyyy"))))); // تاريخ الميلاد
                    }

                    // ثم: ملء الجدول بالمجموعة الثانية (العمود الثالث والرابع)
                    for (int i = 0; i < secondGroup.Count; i++)
                    {
                        var person = secondGroup[i];

                        // العثور على الصف الحالي
                        var row = table.Elements<TableRow>().ElementAtOrDefault(i + rowIndex - 1);  // تحديد الصف من خلال إضافة i و rowIndex
                        if (row == null)
                        {
                            row = new TableRow();
                            table.Append(row); // إضافة صف جديد إذا لم يكن موجودًا
                        }

                        // العثور على الأعمدة في الصف الحالي
                        var cells = row.Elements<TableCell>().ToList();
                        while (cells.Count() < 6) // التأكد من أن هناك 6 أعمدة في الصف (لأنك في العمود الثالث والرابع)
                        {
                            cells.Add(new TableCell(new Paragraph(new Run(new Text(""))))); // إضافة خلية فارغة
                        }

                        // ملء الأعمدة بالبيانات في العمود الثالث والرابع
                        cells[3].RemoveAllChildren<Paragraph>();
                        cells[3].Append(new Paragraph(new Run(new Text((i + 1 + peoplePerColumn).ToString())))); // رقم الصف

                        cells[4].RemoveAllChildren<Paragraph>();
                        cells[4].Append(new Paragraph(new Run(new Text(person.Name)))); // الاسم

                        cells[5].RemoveAllChildren<Paragraph>();
                        cells[5].Append(new Paragraph(new Run(new Text(person.DateOfBirth?.ToString("dd/MM/yyyy"))))); // تاريخ الميلاد
                    }

                    // حفظ التعديلات
                    document.Save();
                }
            }
            var StageName = GetNameForStage(stageId);

            // تحميل الملف كاستجابة للمستخدم
            byte[] fileBytes = System.IO.File.ReadAllBytes(tempFilePath);
            string fileName = StageName + ".docx";
            return fileBytes;
        }
        public byte[] GenerateWordFilebylist(IEnumerable<Makhdoum> people)
        {

           

            // تحميل القالب
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "wordfile/form.docx");
            string tempFilePath = Path.GetTempFileName(); // إنشاء ملف مؤقت

            // نسخ القالب إلى ملف مؤقت
            System.IO.File.Copy(templatePath, tempFilePath, true);

            // فتح الملف المؤقت باستخدام Open XML SDK
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(tempFilePath, true))
            {
                var mainPart = wordDoc.MainDocumentPart;
                var document = mainPart.Document;

                // العثور على الجدول في المستند
                var table = document.Body.Elements<Table>().FirstOrDefault();
                if (table != null)
                {
                    int rowIndex = 2; // الصف الأول يبدأ من 2 أو 3 حسب تنسيق الجدول
                    int peoplePerColumn = 25; // عدد الأشخاص في كل مجموعة

                    // تقسيم الأشخاص إلى مجموعتين
                    var firstGroup = people.Take(peoplePerColumn).ToList();
                    var secondGroup = people.Skip(peoplePerColumn).Take(peoplePerColumn).ToList();

                    // أولاً: ملء الجدول بالمجموعة الأولى (العمود الأول و الثاني)
                    for (int i = 0; i < firstGroup.Count; i++)
                    {
                        var person = firstGroup[i];

                        // العثور على الصف الحالي
                        var row = table.Elements<TableRow>().ElementAtOrDefault(i + rowIndex - 1);  // استخدام i + rowIndex لتحديد الصفوف بشكل صحيح
                        if (row == null)
                        {
                            row = new TableRow();
                            table.Append(row); // إضافة صف جديد إذا لم يكن موجودًا
                        }

                        // العثور على الأعمدة في الصف الحالي
                        var cells = row.Elements<TableCell>().ToList();
                        while (cells.Count() < 4) // التأكد من أن هناك 4 أعمدة في الصف
                        {
                            cells.Add(new TableCell(new Paragraph(new Run(new Text(""))))); // إضافة خلية فارغة
                        }

                        // ملء الأعمدة بالبيانات في العمود الأول والثاني
                        cells[0].RemoveAllChildren<Paragraph>();
                        cells[0].Append(new Paragraph(new Run(new Text((i + 1).ToString())))); // رقم الصف

                        cells[1].RemoveAllChildren<Paragraph>();
                        cells[1].Append(new Paragraph(new Run(new Text(person.Name)))); // الاسم

                        cells[2].RemoveAllChildren<Paragraph>();
                        cells[2].Append(new Paragraph(new Run(new Text(person.DateOfBirth?.ToString("dd/MM/yyyy"))))); // تاريخ الميلاد
                    }

                    // ثم: ملء الجدول بالمجموعة الثانية (العمود الثالث والرابع)
                    for (int i = 0; i < secondGroup.Count; i++)
                    {
                        var person = secondGroup[i];

                        // العثور على الصف الحالي
                        var row = table.Elements<TableRow>().ElementAtOrDefault(i + rowIndex - 1);  // تحديد الصف من خلال إضافة i و rowIndex
                        if (row == null)
                        {
                            row = new TableRow();
                            table.Append(row); // إضافة صف جديد إذا لم يكن موجودًا
                        }

                        // العثور على الأعمدة في الصف الحالي
                        var cells = row.Elements<TableCell>().ToList();
                        while (cells.Count() < 6) // التأكد من أن هناك 6 أعمدة في الصف (لأنك في العمود الثالث والرابع)
                        {
                            cells.Add(new TableCell(new Paragraph(new Run(new Text(""))))); // إضافة خلية فارغة
                        }

                        // ملء الأعمدة بالبيانات في العمود الثالث والرابع
                        cells[3].RemoveAllChildren<Paragraph>();
                        cells[3].Append(new Paragraph(new Run(new Text((i + 1 + peoplePerColumn).ToString())))); // رقم الصف

                        cells[4].RemoveAllChildren<Paragraph>();
                        cells[4].Append(new Paragraph(new Run(new Text(person.Name)))); // الاسم

                        cells[5].RemoveAllChildren<Paragraph>();
                        cells[5].Append(new Paragraph(new Run(new Text(person.DateOfBirth?.ToString("dd/MM/yyyy"))))); // تاريخ الميلاد
                    }

                    // حفظ التعديلات
                    document.Save();
                }
            }
           

            // تحميل الملف كاستجابة للمستخدم
            byte[] fileBytes = System.IO.File.ReadAllBytes(tempFilePath);
           
            return fileBytes;
        }


    }


}

