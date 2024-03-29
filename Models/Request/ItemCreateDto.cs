﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class ItemCreateDto
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? Image { get; set; }
        public int ItemCategoryId { get; set; }
        public DateTime? Created { get; set; }
    }
}
