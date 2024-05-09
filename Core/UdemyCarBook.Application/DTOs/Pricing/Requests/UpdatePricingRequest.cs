using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.DTOs.Pricing.Requests
{
    public class UpdatePricingRequest
    {
        public int PricingId { get; set; }
        public string Name { get; set; }
    }
}
