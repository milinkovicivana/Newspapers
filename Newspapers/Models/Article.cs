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

        public Article find(string id)
        {
            var articleId = new ObjectId(id);
            return articleCollection.AsQueryable<Article>().SingleOrDefault(a => a.Id == articleId);
        }

        public void create(Article article)
        {
            articleCollection.InsertOne(article);
        }

        public void update(Article article)
        {
            articleCollection.UpdateOne(
                Builders<Article>.Filter.Eq("_id", article.Id),
                Builders<Article>.Update.Set("Title", article.Title)
                                        .Set("Body", article.Body)
            );
        }

        public void delete(string id)
        {
            articleCollection.DeleteOne(Builders<Article>.Filter.Eq("_id", ObjectId.Parse(id)));
        }

    }
}
