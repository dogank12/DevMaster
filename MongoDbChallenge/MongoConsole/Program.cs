using DatasourceLayer;
using Model;
using MongoDB.Bson.Serialization.Attributes;
using SampleDataCreator;
using System;

namespace MongoConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            MongoCRUD _db = new MongoCRUD("AddressBook");

            Console.WriteLine("Deleting existing records.\n\n");
            var _personRecs = _db.LoadRecords<PersonModel>("Users");
            Guid _guid = new Guid("20A9A798-FE9D-4D00-836B-2186A01A6691");
            foreach (var _rec in _personRecs)
            {
                _guid = _rec.Id;
                _db.DeleteRecord<PersonModel>("Users", _guid);
            }
            Console.WriteLine("All are deleted.\n\n");

            
            #region //commented out

            //_db.InsertRecord("Users" , new PersonModel { FirstName = "Doğan", LastName = "Kartaltepe" });
            //_db.InsertRecord("Users", new PersonModel { FirstName = "Terrence", LastName = "Ritzman" });

            //PersonModel _personNew = new PersonModel
            //{
            //    FirstName = "Justin",
            //    LastName = "Kloetzer",
            //    Address = new AddressModel
            //    {
            //        StreetAddress = "123 Main Street"   ,
            //        City = "Austin"        ,
            //        State = "Texas"   ,
            //        ZipCode = "76055",
            //        AddressType = "Primary"
            //    }
            //};
            //_db.InsertRecord("Users", _personNew);
            #endregion

            for (int i = 0; i <= 15; i++)
            {
                var _p = new PersonModel()
                {
                    FirstName = Generate.RandomFirstName(),
                    LastName = Generate.RandomLastName(),
                    Address = new AddressModel()
                    {
                        StreetAddress = Generate.RandomAddress(),
                        City = Generate.RandomCityName(),
                        State = Generate.RandomStateName(),
                        ZipCode = Generate.RandomZip(),
                        AddressType = "Primary"
                    },
                    DateOfBirth = Generate.RandomDate(1950, 2012)

                };
                _db.InsertRecord("Users", _p);
            }

            #region //PERSONMODEL
            _personRecs = _db.LoadRecords<PersonModel>("Users");
            foreach (var _rec in _personRecs)
            {
                _guid = _rec.Id;
                OutputPerson(_rec);
                Console.WriteLine("\n");
            }
            var _person = _db.LoadRecordById<PersonModel>("Users", _guid);
            OutputPerson(_person);
            Console.WriteLine("");

            _person.DateOfBirth = Generate.RandomDate(1950, 2012);
            _db.UpsertRecord("Users", _person.Id, _person);
            OutputPerson(_person);
            #endregion
            //PERSONMODEL

            #region //NAMEMODEL
            //var _recsName = _db.LoadRecords<NameModel>("Users");
            //foreach (var _rec in _recsName)
            //{
            //    _guid = _rec.Id;
            //    OutputName(_rec);
            //    Console.WriteLine("\n");

            //}
            //var _name = _db.LoadRecordById<NameModel>("Users", _guid);
            #endregion
            //NAMEMODEL

            Console.WriteLine("\n\nPress the any key");
            Console.ReadLine();
        }

        private static void OutputPerson(PersonModel Person)
        {
            //Console.WriteLine($"{Person.Id}\n{ Person.FirstName} {Person.LastName}");
            OutputName(Person);
            if (Person.Address != null)
                Console.WriteLine($"{Person.Address.StreetAddress} \n{ Person.Address.City} {Person.Address.State} {Person.Address.ZipCode}");
            if (Person.DateOfBirth != null)
                Console.WriteLine(Person.DateOfBirth.ToString("yyyy.MM.dd"));
        }
        private static void OutputName(NameModel Person)
        {
            Console.WriteLine($"{Person.Id}\n{ Person.FirstName} {Person.LastName}");
        }
    }
    //public class NameModel
    //{
    //    [BsonId]
    //    public Guid Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //}

    //public class PersonModel : NameModel
    //{
    //    //[BsonId]
    //    //public Guid Id { get; set; }
    //    //public string FirstName { get; set; }
    //    //public string LastName { get; set; }
    //    public AddressModel Address { get; set; }
    //    [BsonElement("Dob")]
    //    public DateTime DateOfBirth { get; set; }

    //}

    //public class AddressModel
    //{
    //    public string StreetAddress { get; set; }
    //    public string City { get; set; }
    //    public string State { get; set; }
    //    public string ZipCode { get; set; }
    //    public string AddressType { get; set; }

    //}
}
