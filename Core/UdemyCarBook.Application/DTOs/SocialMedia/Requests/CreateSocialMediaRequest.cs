using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.DTOs.SocialMedia.Requests
{
    public class CreateSocialMediaRequest
    {
       
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
