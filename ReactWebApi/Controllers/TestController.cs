using ReactWebApi.Providers;
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
    //[RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private MyTestProvider _myTestProvider;

        public TestController(MyTestProvider myTestProvider)
        {
            _myTestProvider = myTestProvider;
        }

        //[Route("")]
        [HttpGet]
        public HttpResponseMessage TestRoute()
        {
            var autofacWorking = false;

            autofacWorking = _myTestProvider.AutofacWorking();
            if (autofacWorking) return new HttpResponseMessage(HttpStatusCode.OK);

            return new HttpResponseMessage(HttpStatusCode.Ambiguous);
        }
    }
}
