using System;
using System.Collections.Generic;

namespace Mail
{
    public interface IMailer
    {
        void Send(Tuple<string, string> From, List<Tuple<string, string>> Recipients, List<Tuple<string, string>> CarbonCopyees, List<Tuple<string, string>> BlindCarbonCopyees, string SubjectText, string BodyText);
    }
}