using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Paycore.FinalProject.Domain.Entities;

namespace Paycore.FinalProject.Persistance.Mapping
{
    public class ProductMapp : ClassMapping<Product>
    {
        public ProductMapp()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.Name, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Description, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Brand, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Color, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Price, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });
            Property(b => b.IsSold, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });
            Property(b => b.IsOfferable, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });
            Property(b => b.CreationDate, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });
            ManyToOne(x => x.User, m =>
            {
                m.Column(c =>
                {
                    c.Name("UserId");
                    c.NotNullable(true);
                });
                m.ForeignKey("FK_products_users");
            });
            ManyToOne(x => x.Category, m =>
            {
                m.Column(c =>
                {
                    c.Name("CategoryId");
                    c.NotNullable(true);
                });
                m.ForeignKey("FK_products_categories");
            });
            DynamicUpdate(true);
            Bag(x => x.Offers, c =>
            {
                c.Inverse(true);
                c.Key(k => k.Column("ProductId"));
            }, r => r.OneToMany());

            Table("products");
        }
    }
}
