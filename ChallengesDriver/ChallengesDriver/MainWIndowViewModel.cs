using SampleDataCreator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilities.Commands;

namespace ChallengesDriver
{
    class MainWIndowViewModel : ViewModelBase

    {
        #region //CONSTANTS
        const string NAME = "Name";
        const string PHONE = "Phone";
        const string ZIP = "ZipCode";
        const string SSN = "SSN";
        const string ACTIVE = "Active";
        const string VAL = "SomeDouble";
        #endregion
        //CONSTANTS



        #region //NOTIFY PROPERTIES

        private DataTable _people;

        public DataTable People
        {
            get { return _people; ; }
            set { _people = value; }
        }
        #endregion
        //NOTIFY PROPERTIES



        #region //EVENTS-COMMAND
        public ICommand GernerateCommand { get { return new RelayCommand(x => GeneratePerson()); } }

        public void GeneratePerson()
        {
            GenerateAddRandomPerson();
        }
        #endregion
        //EVENTS-COMMAND


        public MainWIndowViewModel()
        {
            People = PeopleInit();
            AddPeople("Janice MacCrayzee", "(713) 758-9140", "45607-2515", "895-12-3100", true, 1.23d);
            for (int i = 0; i < 10; i++)
                GenerateAddRandomPerson();
        }


        #region //METHODS
        private DataTable PeopleInit()
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add(ACTIVE, typeof(bool));
            _dt.Columns.Add(NAME, typeof(string));
            _dt.Columns.Add(PHONE, typeof(string));
            _dt.Columns.Add(ZIP, typeof(string));
            _dt.Columns.Add(SSN, typeof(string));
            _dt.Columns.Add(VAL, typeof(double));
            return _dt;
        }

        private bool AddPeople(string Name, string Phone, string Zip, string Ssn, bool IsActive, double Val)
        {
            var _row = People.NewRow();
            _row[NAME] = Name;
            _row[PHONE] = Phone;
            _row[ZIP] = Zip;
            _row[SSN] = Ssn;
            _row[ACTIVE] = IsActive;
            _row[VAL]= Val;
            People.Rows.Add(_row);

            return true;
        }

        const string FORMATSSN = "{0}-{1}-{2}";
        const char PADCHAR = '0';
        private bool GenerateAddRandomPerson()
        {
            string _ssn = Generate.RandomFormat(FORMATSSN,
                new string[] { Generate.RandomInteger(1, 1000).ToString().PadLeft(3, PADCHAR)
                             , Generate.RandomInteger(1, 100).ToString().PadLeft(2, PADCHAR)
                             , Generate.RandomInteger(1, 10000).ToString().PadLeft(4, PADCHAR) });

            AddPeople(
              Generate.RandomFullName()
            , Generate.RandomPhone()
            , Generate.RandomZip()
            , _ssn
            , Generate.RandomBoolean()
            , Generate.RandomDouble(15,45)
            );

            return true;
        }

        #endregion
        //METHODS

    }
}
