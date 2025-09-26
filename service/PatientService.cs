
using veterinarian.models;

namespace veterinarian.service
{
    public class PatientService
    {
        public static List<Patient> Patients { get; set; } = new();

        public static Patient RegisterPatient()
        {
            Console.WriteLine("Enter Patient's Name");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine("Patient Years Entered");
            int age = int.Parse(Console.ReadLine() ?? "");
            Console.WriteLine("Patient Symptoms Entered");
            string symptom = Console.ReadLine() ?? "";

            Guid id = Guid.NewGuid();
            var patient = new Patient(id, name, age, symptom);
            Patients.Add(patient);
            return patient;
        }
        public static List<Patient> ListPatients => Patients;

        public static void PrintAllPatients()
        {
            if (Patients.Count == 0)
            {
                Console.WriteLine("Not Patients Registers");
                return;
            }
            foreach (var patient in Patients)
            {
                patient.MonstraraInformacion();
            }

        }
        public static void SearchXName()
        {
            if (Patients.Count == 0)
            {
                Console.WriteLine("Not Patients Registers");
                return;
            }
            Console.WriteLine("Enter Name Search:");
            string NameSearch = Console.ReadLine() ?? "";

            var foundPatients = Patients.Where(patient => patient.Name == NameSearch);
            if (!foundPatients.Any())
            {
                Console.WriteLine("No Patient found with than name.");
                return;
            }
            foreach (var patient in foundPatients)
            {
                patient.MonstraraInformacion();

            }
        }


    }
}