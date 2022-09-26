using FluentNHibernate.MappingModel.ClassBased;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Paycore.FinalProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paycore.FinalProject.Persistance.Mapping
{
    public class UserMapp : ClassMapping<User>
    {
        public UserMapp()
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
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Surname, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Email, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.Password, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.CreationDate, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });
            Property(b => b.Role, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Bag(x => x.Products, c =>
            {
                c.Inverse(true);
                c.Key(k => k.Column("UserId"));
            }, r => r.OneToMany());
            Bag(x => x.Offers, c =>
            {
                c.Inverse(true);
                c.Key(k => k.Column("BuyerId"));
            }, r => r.OneToMany());

            Table("users");
        }
    }
}
