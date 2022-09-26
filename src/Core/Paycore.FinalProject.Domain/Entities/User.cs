namespace Paycore.FinalProject.Domain.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Role { get; set; }
        public virtual DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
