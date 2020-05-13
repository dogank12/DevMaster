using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoWebUI.Models
{
    public class PersonLocal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }
        public int Age { get; set; }
    }
}