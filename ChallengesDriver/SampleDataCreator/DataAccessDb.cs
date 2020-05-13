using System.Collections.Generic;

namespace SampleDataCreator
{
    public class DataAccessDb : IDataAccessLayer
    {
        string _connectionString = "";
        List<string> IDataAccessLayer.GeLastNames()
        {
            List<string> _output = new List<string>();
            return _output;

        }

        List<string> IDataAccessLayer.GetFirstNames()
        {
            List<string> _output = new List<string>();
            return _output;
        }
    }

}


