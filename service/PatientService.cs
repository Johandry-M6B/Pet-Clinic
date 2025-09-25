using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using veterinarian.models;

namespace veterinarian.service
{
    public class PatientService
    {
        public  static List<Patient> Patients { get; set; } = new List<Patient>();

        public static Patient RegisterPatient()
        {
            Console.WriteLine("Enter Patient's name");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Patient's name");
            int age = int.Parse(Console.ReadLine() ?? "");
            Console.WriteLine("Enter Patient's name");
            string symptom = Console.ReadLine() ?? "";

            Guid id = Guid.NewGuid();
            var patient = new Patient(id, name, age, symptom);
            Patients.Add(patient);
            return patient;
        }
    }
}