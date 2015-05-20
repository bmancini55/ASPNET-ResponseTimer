using ResponseTimer;

namespace Microsoft.AspNet.Builder
{
    public static class ResponseTimeExtensions
    {
        public static IApplicationBuilder UseResponseTimer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseTimerMiddleware>();
        }
    }
}
