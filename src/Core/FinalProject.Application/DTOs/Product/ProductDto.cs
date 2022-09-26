namespace FinalProject.Application.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public bool IsOfferable { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
