using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorControl.Data;

namespace MongoDBLink
{
    public static class MongoDBConnection
    {
        public static void AddToDataBase(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlazorControlZaripov");
            var collection = database.GetCollection<User>("UserCollection");
            collection.InsertOne(user);
        }

        public static User FindById(string id)
        {
            var client = new MongoClient("mongodb://localhost");
            var filter = Builders<User>.Filter.Eq("_id", ObjectId.Parse(id));
            var database = client.GetDatabase("BlazorControlZaripov");
            var collection = database.GetCollection<User>("UserCollection");
            return collection.Find(filter).FirstOrDefault();
        }


        public static IMongoCollection<User> GetCollection()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("BlazorControlZaripov");

            return  database.GetCollection<User>("UserCollection");
        }
    }
}
