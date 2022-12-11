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
    [BsonCollection("chouse")]
    public class Choose : IEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public ObjectId _id;

        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public List<ChooseCategory> ChooseCategories { get; set; }
    }
}
