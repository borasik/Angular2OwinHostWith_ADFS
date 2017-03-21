using System;
using System.CodeDom;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.WsFederation;
using Microsoft.AspNet.Identity;


namespace Angular2OwinHost
{
    [Authorize]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("api/test")]
        [AllowAnonymous]
        public HttpResponseMessage Test()
        {
            var provider = "Nighthawk ADFS";
            var ctx = Request.GetOwinContext();
            var result = ctx.Authentication.AuthenticateAsync("ExternalCookie").Result;
            ctx.Authentication.SignOut("ExternalCookie");

            if (result != null)
            {
                var claims = result.Identity.Claims.ToList();
                claims.Add(new Claim(ClaimTypes.AuthenticationMethod, provider));

                var ci = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                ctx.Authentication.SignIn(ci);
            }
            Console.WriteLine("api/values POST");
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = new Uri("http://localhost:12345/homePage.html");
            return response;
        }

        // GET api/values        
     
        public HttpResponseMessage Get()
        {
            return null;
        }

        // GET api/values/5 

        public string Get(int id)
        {
            return "value";
        }



        // POST api/values 
       
        public HttpResponseMessage Post([FromBody]string value)
        {
            return null;
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}