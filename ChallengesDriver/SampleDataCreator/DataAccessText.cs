using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataCreator
{
    public class DataAccessText : IDataAccessLayer
    {
        private const string FIRSTNAMESFILENAME = @"Files\FirstNames.txt";
        private const string LASTNAMESFILENAME = @"Files\LastNames.txt";
        private const string STREETNAMESFILENAME = @"Files\StreetNames.txt";
        private const string CITYNAMESFILENAME = @"Files\CityNames.txt";
        private const string STATENAMESFILENAME = @"Files\StateNames.txt";




        public List<string> GetFirstNames()
        {
            List<string> _output = new List<string>();
            string _file = Path.Combine(Environment.CurrentDirectory, FIRSTNAMESFILENAME);

            if (File.Exists(_file))
                _output.AddRange(File.ReadAllLines(_file));

            return _output;
        }

        public List<string> GeLastNames()
        {
            List<string> _output = new List<string>();
            string _file = Path.Combine(Environment.CurrentDirectory, LASTNAMESFILENAME);

            if (File.Exists(_file))
                _output.AddRange(File.ReadAllLines(_file));

            return _output;
        }
        public List<string> GetStreetNames()
        {
            List<string> _output = new List<string>();
            string _file = Path.Combine(Environment.CurrentDirectory, STREETNAMESFILENAME);

            if (File.Exists(_file))
                _output.AddRange(File.ReadAllLines(_file));

            return _output;
        }

        //GetCityNames
        public List<string> GetCityNames()
        {
            List<string> _output = new List<string>();
            string _file = Path.Combine(Environment.CurrentDirectory, CITYNAMESFILENAME);

            if (File.Exists(_file))
                _output.AddRange(File.ReadAllLines(_file));

            return _output;
        }

        //GetStateNames
        public List<string> GetStateNames()
        {
            List<string> _output = new List<string>();
            string _file = Path.Combine(Environment.CurrentDirectory, STATENAMESFILENAME);

            if (File.Exists(_file))
                _output.AddRange(File.ReadAllLines(_file));

            return _output;
        }
    }

}


