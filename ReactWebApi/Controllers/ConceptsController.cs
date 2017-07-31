using ReactWebApi.Models;
using ReactWebApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ReactWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ConceptsController : ApiController
    {
        private List<Concept> _concepts;

        public ConceptsController()
        {
            _concepts = new List<Concept>()
            {
                new Concept
                {
                    Name = "Tritone",
                    Description = "Cool sound",
                    Category = Category.Compositional
                },
                new Models.Concept
                {
                    Name = "Filter Sweept",
                    Description = "White Noise Filter Sweep",
                    Category = Category.Production
                },
                new Concept
                {
                    Name = "Reese Bass",
                    Description = "Distorted Sine Waves",
                    Category = Category.SoundDesign
                }
            };
        }

        [HttpGet]
        public IEnumerable<Concept> Concepts()
        {
            return _concepts;
        }
    }
}

