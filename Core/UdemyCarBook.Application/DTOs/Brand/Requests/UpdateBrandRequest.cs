﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.DTOs.Brand.Requests
{
    public class UpdateBrandRequest
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
