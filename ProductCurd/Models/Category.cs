using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return $"\nCategoryId : {Id}\nName : {Name}";
        }


    }
}
