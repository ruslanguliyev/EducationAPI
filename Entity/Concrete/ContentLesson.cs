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
    [BsonCollection("content_lesson")]
    public class ContentLesson : IEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public ObjectId _id;

        public string LessonName { get; set; }
        public string VideoUrl { get; set; }

    }
}
