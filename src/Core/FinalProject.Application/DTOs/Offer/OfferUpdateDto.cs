using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.DTOs.Offer
{
    public class OfferUpdateDto
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public int OfferPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
