﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Khedma.Entites.Models
{
    public class Makhdoum
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يرجى إدخال الاسم الرباعي")]
        public string Name { get; set; }
        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [Phone(ErrorMessage = "يرجى إدخال رقم هاتف صحيح")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "تاريخ الميلاد مطلوب")]

        public DateOnly? DateOfBirth { get; set; }

        public ICollection<Koral> TbKoral { get; set; }

        public ICollection<Alhan> TbAlhan { get; set; }
  
        public ICollection<Learning> TBLearning { get; set; }

        public ICollection<Coptic> TBCoptic { get; set; }
     
        public ICollection<Theater> TBTheater { get; set; }
        public ICollection<BooksAndSaves> TBBooksAndSaves { get; set; }
        public ICollection<ForSingle> TBForSingle { get; set; }



    }
}