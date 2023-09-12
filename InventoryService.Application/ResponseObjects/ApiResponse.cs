using System.Text.Json.Serialization;

namespace NorthwindService.Application.ResponseObjects
{
    public class ApiResponse
    {
        [JsonPropertyName("data")]
        public object Data { get; set; }
        [JsonPropertyName("errors")]
        public object Errors { get; set; }
        [JsonPropertyName("isSuccessful")]
        public bool IsSuccessful { get; set; }
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }
        [JsonPropertyName("totalItemCount")]
        public int TotalItemCount { get; set; }
    }
}
