using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.DTOs.Location.Requests
{
    public class UpdateLocationRequest
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }
}
