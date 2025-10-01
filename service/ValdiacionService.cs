using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PetClinic.service
{
    public class ValdiacionService
    {
        public static bool ValidAge(int age)
        {
            return age > 0 && age < 50;
        }

        public static bool ValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.Length >= 2;
        }
    }
}