using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PetClinic.service
{
    public class ValdiacionService
    {
        public bool ValidAge(int age)
        {
            if (age > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool ValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}