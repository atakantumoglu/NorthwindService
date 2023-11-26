using Serilog;

namespace NorthwindService.Api.Middlewares
{
    public class TraceLogMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            // İsteği okuma
            context.Request.EnableBuffering();

            var requestBodyStream = new MemoryStream();
            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

            // İsteği loglama
            Log.Information("Request: {0}", requestBodyText);
            requestBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requestBodyStream;

            var originalBodyStream = context.Response.Body;

            using (var responseBodyStream = new MemoryStream())
            {
                context.Response.Body = responseBodyStream;

                await next(context);

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                var responseBodyText = await new StreamReader(responseBodyStream).ReadToEndAsync();

                // Yanıtı loglama
                Log.Information("Response: {0} ", responseBodyText);

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                await responseBodyStream.CopyToAsync(originalBodyStream);
            }
        }
    }
}
