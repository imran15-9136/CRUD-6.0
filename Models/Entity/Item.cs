using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; }
        public string? ImagePath { get; set; }
        public ItemCategory? Category { get; set; }
        public int? ItemCategoryId { get; set; }
        public DateTime? Created { get; set; }
    }
}
