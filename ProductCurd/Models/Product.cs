using ProductAPI.Models;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }

        public override string ToString()
        {
            return $"\nProductId : {Id}\nName : {Name}\nPrice : {Price}";
        }

    }
}
