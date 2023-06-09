﻿using System.ComponentModel.DataAnnotations;

namespace Film_Catalog.Models.DTO
{
    public class ReviewModifyModel
    {
        [Required]
        public string reviewText { get; set; }
        [Range(0, 10)]
        public int rating { get; set; }
        public bool isAnonymous { get; set; }
    }
}
