using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFluent
{
    public class PersonIdModel: PersonModel
    {
        public new int Id;  //hiding base model Id

    }
}
