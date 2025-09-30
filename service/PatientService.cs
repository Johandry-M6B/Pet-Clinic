using veterinarian.models;
using PetClinic.service; // Añadir este using

namespace veterinarian.service
{
    public class PatientService
    {
        public static List<Patient> Patients { get; set; } = [];
        public static List<Pet> Pets { get; set; } = [];

        public static Patient RegisterPatient()
        {
            string name = "";
            bool validName = false;

            
            while (!validName)
            {
                Console.WriteLine("Enter Patient's Name");
                name = Console.ReadLine() ?? "";
                validName = ValdiacionService.ValidName(name);
                
                if (!validName)
                    Console.WriteLine("Invalid name. Name cannot be empty. Try again.");
            }

            int age = 0;
            bool validAge = false;

            
            while (!validAge)
            {
                try
                {
                    Console.WriteLine("Patient Years Entered");
                    age = int.Parse(Console.ReadLine() ?? "");
                    validAge = ValdiacionService.ValidAge(age);

                    if (!validAge)
                        Console.WriteLine("Age must be positive. Try again.");
                }
                catch
                {
                    Console.WriteLine("Invalid number. Try again.");
                }
            }

            Console.WriteLine("Patient Symptoms Entered");
            string symptom = Console.ReadLine() ?? "";

            Guid id = Guid.NewGuid();
            var patient = new Patient(id, name, age, symptom);
            Patients.Add(patient);
            
            Console.WriteLine($"Patient '{name}' registered successfully!");
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
            
            Console.WriteLine($"\n--- LIST OF PATIENTS ({Patients.Count}) ---");
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

            
            if (!ValdiacionService.ValidName(NameSearch))
            {
                Console.WriteLine("Search name cannot be empty.");
                return;
            }

            var foundPatients = Patients.Where(patient => 
                patient.Name.ToLower().Contains(NameSearch.ToLower())).ToList();
                
            if (!foundPatients.Any())
            {
                Console.WriteLine("No Patient found with that name.");
                return;
            }
            
            Console.WriteLine($"\n--- FOUND PATIENTS ({foundPatients.Count}) ---");
            foreach (var patient in foundPatients)
            {
                patient.MonstraraInformacion();
            }
        }

        
        public static void DeletePatient()
        {
            if (Patients.Count == 0)
            {
                Console.WriteLine("No Patients Registered");
                return;
            }

            Console.WriteLine("Enter Patient Name to Delete:");
            string nameToDelete = Console.ReadLine() ?? "";

            if (!ValdiacionService.ValidName(nameToDelete))
            {
                Console.WriteLine("Invalid patient name.");
                return;
            }

            var patientsToDelete = Patients.Where(p => 
                p.Name.ToLower() == nameToDelete.ToLower()).ToList();

            if (patientsToDelete.Count == 0)
            {
                Console.WriteLine("No patient found with that name.");
                return;
            }

            if (patientsToDelete.Count > 1)
            {
                Console.WriteLine($"Multiple patients found with name '{nameToDelete}'. Please use ID to specify.");
                
                return;
            }

            Patients.Remove(patientsToDelete[0]);
            Console.WriteLine($"Patient '{nameToDelete}' deleted successfully!");
        }
    }
}