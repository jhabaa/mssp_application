using MongoDB.Bson;
namespace mssp_application.Models
{
    public class Service
    {
        public BsonObjectId Id { get; set; } // Unique identifier for the service

        public string Name { get; set; } // Name of the service

        public string Description { get; set; } // Description of the service

        public string Description_full { get; set; } // Full description of the service, if available

        public string Link { get; set; } // Link to more information or the service itself

        public string ImageName { get; set; } // URL of the image associated with the service

        public BsonArray Images { get; set; } // List of illustrations associated with the service
}
}