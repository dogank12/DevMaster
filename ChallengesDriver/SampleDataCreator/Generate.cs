using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataCreator
{
    public static class Generate
    {
        // create a class library for creating sample data
        // √ random boolean
        // √ random integers within a range 
        // √ random names 
        // BONUS
        // _  random doubles in a range, not starting at 0
        // √ random phone number (123) 555-1212
        // √ random zip code 44501-5464
        // √ support other numeric style with out additional methods, e.g., ss#: 123-45-6789




        private static List<string> FirstNames = null;
        private static List<string> LastNames = null;
        private static List<string> StreetNames = null;
        private static List<string> CityNames = null;
        private static List<string> StateNames = null;

        private static readonly Random _random = new Random();
        private const char PADCHAR = '0';
        private const string MINMAXEXCEPTION = "Min value cannot be greater that the max value. Min: {0}; Max: {1}";


        #region //BUILDING BLOCKS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Min">Start inclusive</param>
        /// <param name="Max">Stop exclusive</param>
        /// <returns></returns>
        public static int RandomInteger(int Min, int Max)
        {
            if (Min > Max)
                throw new Exception(string.Format(MINMAXEXCEPTION, Min, Max));
            int _output;
            lock (_random)
            {
                _output = _random.Next(Min, Max);
            }
            return _output;
        }

        public static bool RandomBoolean()
        {
            bool _output = RandomInteger(0, 2) == 1 ? true : false;
            return _output;
        }


        public static double RandomDouble(double Min, double Max)    //as a bonus
        {
            if (Min > Max)
                throw new Exception(string.Format(MINMAXEXCEPTION, Min, Max));

            double _scale = 0.0d;
            lock (_random)
            {
                _scale = _random.NextDouble();
            }
            double _output = Min + ((Max - Min) * _scale);

            return _output;

            /*
            string _characteristic = RandomInteger(Start, Stop).ToString(); 
            string _mantissa = RandomInteger(0, Int32.MaxValue).ToString();

            string _format = "{0}.{1}";

            double _output = Convert.ToDouble(RandomFormat(_format, new string[] { _characteristic, _mantissa }));
            if (_output > Stop) _output = Stop;

            return _output;
            */
        }
        #endregion
        //BUILDING BLOCKS


        #region //FORMATTING METHODS

        public static string RandomFirstName()
        {
            if (null == FirstNames || FirstNames.Count == 0)
            {
                DataAccessText _dal = new DataAccessText();
                FirstNames = _dal.GetFirstNames();
            }
            string _output = FirstNames[RandomInteger(0, FirstNames.Count - 1)];
            return _output;

        }
        public static string RandomLastName()
        {
            if (null == LastNames || LastNames.Count == 0)
            {
                DataAccessText _dal = new DataAccessText();
                LastNames = _dal.GeLastNames();
            }

            string _output = LastNames[RandomInteger(0, LastNames.Count - 1)];
            return _output;

        }
        public static string RandomFullName()
        {
            string _format = "{0} {1}";
            string _output = string.Format(_format, RandomFirstName(), RandomLastName());
            return _output;
        }


        public static string RandomAddress()
        {
            return  RandomFormat("{0}", new string[] { RandomInteger(1, 9999).ToString() }) + " " +  RandomStreetName();
        }
        public static string RandomStreetName()
        {
            if (null == StreetNames || StreetNames.Count == 0)
            {
                DataAccessText _dal = new DataAccessText();
                StreetNames = _dal.GetStreetNames();
            }

            string _output = StreetNames[RandomInteger(0, StreetNames.Count - 1)];
            return _output;
        }
        public static string RandomCityName()
        {
            if (null == CityNames || CityNames.Count == 0)
            {
                DataAccessText _dal = new DataAccessText();
                CityNames = _dal.GetCityNames();
            }

            string _output = CityNames[RandomInteger(0, CityNames.Count - 1)];
            return _output;
        }
        //State
        public static string RandomStateName()
        {
            if (null == StateNames || StateNames.Count == 0)
            {
                DataAccessText _dal = new DataAccessText();
                StateNames = _dal.GetStateNames();
            }

            string _output = StateNames[RandomInteger(0, StateNames.Count - 1)];
            return _output;
        }

        //public static string RandomSsn() // THIS ONE SHOULD NOT BE A SPECIAL METHOD
        //{
        //    string _format = "{0}-{1}-{2}";
        //    string _output = RandomFormat(_format,
        //        new string[] { RandomInteger(1, 1000).ToString().PadLeft(3, PADCHAR), RandomInteger(1, 100).ToString().PadLeft(2, PADCHAR), RandomInteger(1, 10000).ToString().PadLeft(4, PADCHAR) });

        //    return _output;
        //}

        public static string RandomZip()
        {
            string _format = "{0}-{1}";
            string _output = RandomFormat(_format,
                new string[] { RandomInteger(1, 100000).ToString().PadLeft(5, PADCHAR)
                             , RandomInteger(1,   1000).ToString().PadLeft(4, PADCHAR) });
            return _output;
        }

        public static string RandomPhone()
        {
            string _format = "({0}) {1}-{2}";
            string _output = RandomFormat(_format,
                new string[]{ RandomInteger(200, 1000).ToString().PadLeft(3, PADCHAR)
                            , RandomInteger(200, 1000).ToString().PadLeft(3, PADCHAR)
                            , RandomInteger(0, 10000).ToString().PadLeft(4, PADCHAR) });

            return _output;
        }

        public static DateTime RandomDate(int MinYear, int MaxYear)
        {
            int _year = Generate.RandomInteger(MinYear, MaxYear);
            int _month = Generate.RandomInteger(1, 12);
            int _maxDays = DateTime.DaysInMonth(_year, _month);


            DateTime _output = new DateTime(_year , _month , Generate.RandomInteger(1, _maxDays)
                , 0, 0, 0, DateTimeKind.Utc);

            return _output;
        }

        public static string RandomFormat(string Format, string[] Formatees)
        {
            string _output = string.Format(Format, Formatees);
            return _output;
        }
        #endregion
        //FORMATTING METHODS

    }
}
