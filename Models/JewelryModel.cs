
namespace SAOnlineMart.Models
{
    public class JewelryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; } // Nullable if you are not sure about default values
        public string? Description { get; set; }
        public int Price { get; set; }
    }
}
