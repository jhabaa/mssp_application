using System;

namespace mssp_application.Models
{
    public class ActivityCard
    {
        public int Id { get; set; } // Unique identifier for the activity card

        public string Title { get; set; } // Title of the activity card

        public string Description { get; set; } // Description of the activity

        public string Link { get; set; } // Link to more information or the activity itself

        public string ImageUrl { get; set; } // URL of the image associated with the activity

    }
}