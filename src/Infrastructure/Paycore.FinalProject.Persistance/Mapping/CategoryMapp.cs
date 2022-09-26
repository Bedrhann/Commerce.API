using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Paycore.FinalProject.Domain.Entities;

namespace Paycore.FinalProject.Persistance.Mapping
{
    public class CategoryMapp : ClassMapping<Category>
    {
        public CategoryMapp()
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
                x.Length(20);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            DynamicUpdate(true);
            Table("categories");
        }
    }
}
