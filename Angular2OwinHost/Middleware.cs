using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;

using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Angular2OwinHost
{
    public class CustomMiddleware
    {
       
            private AppFunc next;

            public CustomMiddleware(AppFunc next)
            {
                this.next = next;
            }

            public async Task Invoke(IDictionary<string, object> environment)
            {
                Console.WriteLine("Begin Request");
                await next.Invoke(environment);
                Console.WriteLine("End Request");
            }
    }
}
