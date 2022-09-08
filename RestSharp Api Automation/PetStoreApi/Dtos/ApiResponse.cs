
namespace RestSharp_Api_Automation.PetStoreApi.Dtos
{
    public class ApiResponse
    {
        // Status code of response
        public int Code { get; set; }

        // Type of response
        public string? Type { get; set; }

        // Message of response
        public string? Message { get; set; }
    }
}