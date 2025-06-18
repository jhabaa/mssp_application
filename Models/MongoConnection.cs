using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.VisualBasic;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Net;
using mssp_application.Models;

public class MongoConnection
{
    private IMongoCollection<BsonDocument> _activitiesCollection;
    private readonly IConfiguration _configuration;// Default MongoDB connection URL
    public MongoClient _client { get; private set; }

    public List<ActivityCard> Activities { get; set; } = new List<ActivityCard>();
    public MongoConnection(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        // This method can be used to initialize or test the MongoDB connection
        // using the configuration settings provided.
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        var dbPassword = _configuration["MONGODB_PASSWORD"]
            ?? Environment.GetEnvironmentVariable("MONGODB_PASSWORD")
            ?? throw new ArgumentNullException("MONGODB_PASSWORD", "MongoDB password is not set in configuration or environment variables.");

        var dbName = _configuration["MONGODB_NAME"]
            ?? Environment.GetEnvironmentVariable("MONGODB_NAME")
            ?? throw new ArgumentNullException("MONGODB_NAME", "MongoDB name is not set in configuration or environment variables.");

        var connectionURL = $"mongodb+srv://jhubertmillenium:{dbPassword}@heanlab.crq428n.mongodb.net/?retryWrites=true&w=majority&appName=Heanlab";
        // Here you would typically set up your MongoDB client and connect to the database
        // using the dbPassword and other connection details from the configuration.

        var settings = MongoClientSettings.FromConnectionString(connectionURL);

        // Set the ServerAPI field of the settings object to set the API version
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);

        // Create a new client and connect to the database
        _client = new MongoClient(settings);
        _configuration = configuration;
        

        var db = _client.GetDatabase(dbName);

        //Loading activities from the database
        _activitiesCollection = db.GetCollection<BsonDocument>("activities");
        
    }
    
    public async Task LoadActivitiesAsync()
    {
        // This method can be used to load activities from the MongoDB collection asynchronously.
        // It will fetch all documents from the "activities" collection and populate the Activities list.
        var filter = Builders<BsonDocument>.Filter.Empty; // Adjust the filter as needed
        var documents = await _activitiesCollection.Find(filter).ToListAsync(); // Fetch documents from the collection

        foreach (var doc in documents)
        {
            Activities.Add(new ActivityCard
            {
                Id = doc["_id"].AsObjectId,
                Title = doc["title"].AsString,
                Description = doc["description"].AsString,
                Link = doc["link"].AsString,
                ImageUrl = doc["image"].AsString
            });
        }
    }
}