namespace FinalProject.Application.DTOs.Offer
{
    public class OfferCreateDto
    {
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public int OfferPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
