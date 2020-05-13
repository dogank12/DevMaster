using System.Collections.Generic;

namespace SampleDataCreator
{
    public interface IDataAccessLayer
    {
        List<string> GeLastNames();
        List<string> GetFirstNames();
    }
}