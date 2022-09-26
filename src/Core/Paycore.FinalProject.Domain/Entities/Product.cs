namespace Paycore.FinalProject.Domain.Entities
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Price { get; set; }
        public virtual string Color { get; set; }
        public virtual string Brand { get; set; }
        public virtual bool IsSold { get; set; }
        public virtual bool IsOfferable { get; set; }
        public virtual int UserId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

    }
}
