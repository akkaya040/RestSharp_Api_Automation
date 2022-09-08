using System;

namespace RestSharp_Api_Automation.PetStoreApi.Dtos
{
    public class User
    {
        // Id of user
        public Int64? id { get; set; }

        // Username
        public string? username { get; set; }

        // First name of user
        public string? firstName { get; set; }

        // Last name of user
        public string? lastName { get; set; }

        // Email of user
        public string? email { get; set; }

        // User password
        public string? password { get; set; }

        // User phone number
        public string? phone { get; set; }

        // User status
        public int? userStatus { get; set; }
    }
}