namespace Paycore.FinalProject.Domain.Entities
{
    public class Offer
    {
        public virtual int Id { get; set; }
        public virtual int BuyerId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int OfferPrice { get; set; }
        public virtual string OfferStatus { get; set; } = "Waiting";
        public virtual DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

    }
}
