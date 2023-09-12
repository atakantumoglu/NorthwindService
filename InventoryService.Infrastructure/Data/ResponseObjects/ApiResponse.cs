using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Data.ResponseObjects
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
