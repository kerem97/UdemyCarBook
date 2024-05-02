using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.DTOs.Feature.Requests
{
    public class UpdateFeatureRequest
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
    }
}
