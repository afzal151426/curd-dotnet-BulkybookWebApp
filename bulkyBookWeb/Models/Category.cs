﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1 to 100 only!!!")]
        public int DisplayOrder { get; set; }
        public DateTime createdDateTime { get; set; } = DateTime.Now;
    }
}
