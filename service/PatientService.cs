
using veterinarian.models;

namespace veterinarian.service
{
    public class PatientService
    {
        public  static List<Patient> Patients { get; set; } = new List<Patient>();

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
    }
}