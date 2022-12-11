using Core.DataAccess.MongoDb.MongoSettings;
using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [BsonCollection("course")]
    public class Course : IEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public ObjectId _id;
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string UserId { get; set; }
        public string Raiting { get; set; }
        public string Duration { get; set; }
        public decimal Price { get; set; }
        public List<CourseContent> CourseContents { get; set; }


    }
}
