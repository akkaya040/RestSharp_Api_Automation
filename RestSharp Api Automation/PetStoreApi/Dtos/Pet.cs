using System;
using System.Collections.Generic;

namespace RestSharp_Api_Automation.PetStoreApi.Dtos
{
    public class Pet
    {
        // Id of pet
        public Int64? Id { get; set; }
        // Object containing pet category informations
        public PetCategory? Category { get; set; }
        // Pet name
        public string? Name { get; set; }
        // List of photo urls
        public IList<string>? PhotoUrls {get; set;}
        // List of tag objects
        public IList<PetTag>? Tags { get; set; }
        // Status of pet
        public string? Status { get; set; }
    }
}