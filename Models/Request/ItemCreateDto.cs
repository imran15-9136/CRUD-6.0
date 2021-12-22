using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class ItemCreateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; }
        public int ItemCategoryId { get; set; }
        public DateTime? Created { get; set; }
    }
}
