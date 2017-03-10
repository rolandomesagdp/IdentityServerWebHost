using IdentityServer3.AccessTokenValidation;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace IdentityServerWebHost.ClientWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var authenticationOptions = new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44344/identity",
                RequiredScopes = new[] { "sampleApi" }
            };
            app.UseIdentityServerBearerTokenAuthentication(authenticationOptions);


            var configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();

            app.UseWebApi(configuration);
        }
    }
}