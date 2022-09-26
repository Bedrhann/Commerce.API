using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Paycore.FinalProject.Domain.Entities;

namespace Paycore.FinalProject.Persistance.Mapping
{
    public class OfferMapp : ClassMapping<Offer>
    {
        public OfferMapp()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.OfferPrice, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });
            Property(b => b.OfferStatus, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.CreationDate, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });
            ManyToOne(x => x.Product, m =>
            {
                m.Column(c =>
                {
                    c.Name("ProductId");
                    c.NotNullable(true);
                });
                m.ForeignKey("FK_offers_products");
            });
            ManyToOne(x => x.User, m =>
            {
                m.Column(c =>
                {
                    c.Name("BuyerId");
                    c.NotNullable(true);
                });
                m.ForeignKey("FK_offers_users");
            });
            DynamicUpdate(true);

            Table("offers");
        }
    }
}
