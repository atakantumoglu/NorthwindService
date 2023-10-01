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
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path} {requestBodyText}");

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
                Console.WriteLine($"Response: {context.Response.StatusCode} {responseBodyText}");

                responseBodyStream.Seek(0, SeekOrigin.Begin);
                await responseBodyStream.CopyToAsync(originalBodyStream);
            }
        }
    }
}
