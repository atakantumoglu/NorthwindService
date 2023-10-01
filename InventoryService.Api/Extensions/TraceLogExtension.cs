using Serilog;

namespace NorthwindService.Api.Extensions
{
    public class TraceLogExtension
    {
        private readonly RequestDelegate _next;

        public TraceLogExtension(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // İsteği okuma
            context.Request.EnableBuffering();

            var requestBodyStream = new MemoryStream();
            await context.Request.Body.CopyToAsync(requestBodyStream);
            requestBodyStream.Seek(0, SeekOrigin.Begin);

            var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

            // İsteği loglama
            Log.Information("Request log");
            requestBodyStream.Seek(0, SeekOrigin.Begin);
            context.Request.Body = requestBodyStream;

            var originalBodyStream = context.Response.Body;

            using (var responseBodyStream = new MemoryStream())
            {
                context.Response.Body = responseBodyStream;

                await _next(context);

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                var responseBodyText = await new StreamReader(responseBodyStream).ReadToEndAsync();

                // Yanıtı loglama
                _logger.LogInformation("Response log");

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                await responseBodyStream.CopyToAsync(originalBodyStream);
            }
        }
    }
}
