using DatasourceLayer;
using Model;
using MongoWebUI.Models;
using SampleDataCreator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoWebUI.Controllers
{
    public class PersonController : Controller
    {
        string Output = "";

        DataTable _datatable = new DataTable();
        // GET: Person
        public ActionResult Index()
        {
            //   return View();

            //var _persons = from p in GetPersonList()
            //               orderby p.Id
            //               select p;
            //return View(_persons);

            var _persons = from p in PersonList
                           orderby p.Id
                           select p;
            return View(_persons);


        }
        public string List(int id = -1)
        {
            Output = "";
            MongoCRUD _db = new MongoCRUD("AddressBook");

            Output += "Deleting existing records.<br /><br />";
            var _personRecs = _db.LoadRecords<PersonModel>("Users");
            Guid _guid = new Guid("20A9A798-FE9D-4D00-836B-2186A01A6691");
            foreach (var _rec in _personRecs)
            {
                _guid = _rec.Id;
                _db.DeleteRecord<PersonModel>("Users", _guid);
            }
            Output += "All are deleted.<br /><br />";


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
                    //  DateOfBirth = new DateTime(Generate.RandomInteger(1950, 2012), Generate.RandomInteger(1, 2), Generate.RandomInteger(1, 30), 0, 0, 0, DateTimeKind.Utc)
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
                Output += "<br />";
            }
            var _person = _db.LoadRecordById<PersonModel>("Users", _guid);
            OutputPerson(_person);
            Output += "<br />";

            _person.DateOfBirth = Generate.RandomDate(1950, 2012); // new DateTime(Generate.RandomInteger(1950,2012), 1, 1, 0, 0, 0, DateTimeKind.Utc);
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

            return Output;
        }

        private void OutputPerson(PersonModel Person)
        {
            //Console.WriteLine($"{Person.Id}\n{ Person.FirstName} {Person.LastName}");
            OutputName(Person);
            if (Person.Address != null)
                Output += $"{Person.Address.StreetAddress}<br />{ Person.Address.City} {Person.Address.State} {Person.Address.ZipCode}<br />";
            if (Person.DateOfBirth != null)
                Output += $"{Person.DateOfBirth.ToString("yyyy.MM.dd")} <br />";
        }
        private void OutputName(NameModel Person)
        {
            Output += $"{Person.Id}<br />{ Person.FirstName} {Person.LastName}<br />";
        }



        public ActionResult Search(string name)
        {
            var _input = Server.HtmlEncode(name);
            return Content(_input);

        }
        [HttpGet]
        public ActionResult Search()
        {
            var _input = "HttpGet Search";
            return Content(_input);

        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Person/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    try
        //    {
        //        //TODO: Add insert locic here
        //        PersonLocal _newPerson = new PersonLocal();
        //        _newPerson.Name = formCollection["Name"];
        //        DateTime _joinDate;
        //        DateTime.TryParse(formCollection["JoiningDate"], out _joinDate);
        //        _newPerson.JoiningDate = _joinDate;
        //        string _age = formCollection["Age"];
        //        _newPerson.Age = Int32.Parse(_age);
        //        PersonList.Add(_newPerson);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonLocal NewPerson)
        {
            try
            {
                PersonList.Add(NewPerson);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            //   return View();

            List<PersonLocal> _personList = GetPersonList();
            var _person = _personList.Single(m => m.Id == id);
            return View(_person);
        }

        //POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //// TODO: Add update logic here
                //return RedirectToAction("Index");

                var _person = PersonList.Single(m => m.Id == id);
                if (TryUpdateModel(_person))
                {
                    //TODO: database code
                    return RedirectToAction("Index");
                }
                return View(_person);

            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }




        public static List<PersonLocal> PersonList =
            new List<PersonLocal>
            {
                new PersonLocal{Id=1, Name="Altan", JoiningDate=DateTime.Parse(DateTime.Today.ToString()), Age=57},
                new PersonLocal{Id=2, Name="Orhan", JoiningDate=DateTime.Parse(DateTime.Today.ToString()), Age=47},
                new PersonLocal{Id=3, Name="Dogan", JoiningDate=DateTime.Parse(DateTime.Today.ToString()), Age=37},
                new PersonLocal{Id=4, Name="Suzan", JoiningDate=DateTime.Parse(DateTime.Today.ToString()), Age=27},
                new PersonLocal{Id=5, Name="Armagan", JoiningDate=DateTime.Parse(DateTime.Today.ToString()), Age=17}

            };

        [NonAction]
        public List<PersonLocal> GetPersonList()
        {
            return PersonList;

        }
    }
}