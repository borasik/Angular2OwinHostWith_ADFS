using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin.Security.WsFederation;

namespace Angular2OwinHost
{
    public partial class Startup
    {        
        public void ConfigureAuth(IAppBuilder app)
        {                 
            app.Properties["Microsoft.Owin.Security.Constants.DefaultSignInAsAuthenticationType"] = "ExternalCookie";
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ExternalCookie",
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Passive,
                CookieName = CookieAuthenticationDefaults.CookiePrefix + "CSLP_External",
                ExpireTimeSpan = TimeSpan.FromMinutes(5)                
            });

            var nighthawkAdfs = new WsFederationAuthenticationOptions
            {
                MetadataAddress = "https://nhadfs.eastus.cloudapp.azure.com/FederationMetadata/2007-06/FederationMetadata.xml",
                AuthenticationType = "Nighthawk ADFS",
                //Wreply = string.Concat(rootUrl,"LoginCallbackNighthawkAdfs"),
                //Wtrealm = string.Concat(rootUrl, "LoginCallbackNighthawkAdfs"),
                Wreply = "https://localhost:12345/api/values",
                Wtrealm = "https://localhost:12345/api/values",
                BackchannelCertificateValidator = null,
                SignInAsAuthenticationType = WsFederationAuthenticationDefaults.AuthenticationType
            };

            app.UseWsFederationAuthentication(nighthawkAdfs);                   
        }
    }
}