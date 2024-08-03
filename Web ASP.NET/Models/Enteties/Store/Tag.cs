﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_ASP.NET.Models.Enteties.Store
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
    }
}
