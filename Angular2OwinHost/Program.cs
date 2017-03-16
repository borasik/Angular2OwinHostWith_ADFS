using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using System.Diagnostics;


namespace Angular2OwinHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "http://localhost:12345/";
            WebApp.Start<Startup>(new StartOptions(baseUrl)
            {
                ServerFactory = "Microsoft.Owin.Host.HttpListener"
            });

            // Launch default browser
            Process.Start(baseUrl);

            // Kick off other program logic
            // ...

            // In my case wait for ENTER to close app
            Console.ReadLine();
        }
    }
}
