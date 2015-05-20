using Microsoft.AspNet.Builder;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using System.Diagnostics;

namespace ResponseTimer
{
    public class ResponseTimerMiddleware
    {
        private readonly RequestDelegate next;        

        public ResponseTimerMiddleware(RequestDelegate next, IHostingEnvironment hostingEnv)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {            
            var sw = Stopwatch.StartNew();
            context.Response.OnSendingHeaders((state) =>
            {                
                sw.Stop();
                context.Response.Headers.Add("X-Response-Time", new string[] { sw.ElapsedMilliseconds.ToString() + "ms" });
            }, null);
            return next(context);
        }

    }
}
