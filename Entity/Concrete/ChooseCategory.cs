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
    [BsonCollection("chouse_category")]
    public class ChooseCategory : IEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public ObjectId _id;

        public string Icon { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
}
