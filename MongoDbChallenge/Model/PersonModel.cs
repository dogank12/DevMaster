using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Model
{
    public class PersonModel : NameModel
    {
        //[BsonId]
        //public Guid Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public AddressModel Address { get; set; }
        [BsonElement("Dob")]
        public DateTime DateOfBirth { get; set; }

    }


}
