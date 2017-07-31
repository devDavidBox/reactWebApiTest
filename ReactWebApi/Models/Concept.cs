using ReactWebApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReactWebApi.Models
{
    public class Concept
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
    }
}