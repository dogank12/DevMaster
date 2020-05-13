using SampleDataCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherDriver
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Begin");

            for (int i = 0; i < 10; i++)
                GenerateAddRandomPerson();


            Console.ReadKey();
        }


        public static bool GenerateAddRandomPerson()
        {
            const string FORMATSSN = "{0}-{1}-{2}";
            const char PADCHAR = '0';

            string _ssn = Generate.RandomFormat(FORMATSSN,
                new string[] { Generate.RandomInteger(1, 1000).ToString().PadLeft(3, PADCHAR)
                             , Generate.RandomInteger(1, 100).ToString().PadLeft(2, PADCHAR)
                             , Generate.RandomInteger(1, 10000).ToString().PadLeft(4, PADCHAR) });

            string _output = string.Format("{0,-25} {1,-15} {2,10} {3,15} {4,6} {5,9}",
              Generate.RandomFullName()
            , Generate.RandomPhone()
            , Generate.RandomZip()
            , _ssn
            , Generate.RandomBoolean()
            , Generate.RandomDouble(15, 45)
            );

            Console.WriteLine(_output);
            return true;
        }

    }
}
