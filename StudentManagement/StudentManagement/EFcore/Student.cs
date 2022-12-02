﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebAPI.EFcore
{
    [Table("Student")]
    public class Student
    {
        [Key,Required]
        public int id { get; set; }
        public string  name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int age { get; set; }
        public decimal high { get; set; }
    }
}
