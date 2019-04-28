using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newspapers.Models
{
    [Table("Articles")]
    public class Article
    {
        private MongoClient client;
        private IMongoCollection<Article> articleCollection;

        public Article()
        {
            client = new MongoClient();
            var db = client.GetDatabase("PapersDB");
            articleCollection = db.GetCollection<Article>("Articles");
        }

        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public IEnumerable<Article> findAll()
        {
            return articleCollection.AsQueryable<Article>().ToList();
        }

    }
}
