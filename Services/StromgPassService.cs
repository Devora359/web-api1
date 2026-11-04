using System;
using System.Collections.Generic;
using System.Text;
using Zxcvbn;

namespace Services
{
    public class StromgPassService : IStromgPassService
    {
        public int GetStrongPass(string password)
        {




            return Zxcvbn.Core.EvaluatePassword(password).Score;


        }


    }
}
