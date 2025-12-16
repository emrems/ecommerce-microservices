using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Brand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]// bu şekilde mongo buranın unique olduğunu anlıyor
        public string BrandID { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
    }
}
