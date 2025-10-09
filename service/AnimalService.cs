using veterinarian.interfaces;
using veterinarian.models;
using veterinarian.service;

namespace veterinarian.service
{
    public class AnimalService : IRegister
    {
        private static List<Patient> Patients => PatientService.Patients;
        private static List<Pet> AllPets => PatientService.AllPets;
        
        bool IRegister.Register()
        { 
            
            if (Patients.Count == 0)
            {
                Console.WriteLine("No patient registered. Please register a patient first");
                return false;
            }

            Console.WriteLine("----------REGISTER PET (Direct Method)---------------");

            Console.WriteLine("Available Patients:");
            foreach (var patient in Patients)
            {
                Console.WriteLine($"- {patient.Name}");
            }
            
            Patient? selectedPatient = null;
            while (selectedPatient == null)
            {
                Console.WriteLine("Enter Patient NAME for the pet:");
                string patientName = Console.ReadLine() ?? "";

                if (!ValdiacionService.ValidName(patientName))
                {
                    Console.WriteLine("Invalid Patient name. Try again");
                    continue;
                }
                
                selectedPatient = Patients.FirstOrDefault(p =>
                    p.Name.ToLower().Contains(patientName.ToLower()));

                if (selectedPatient == null)
                {
                    Console.WriteLine("Patient not found. Try again.");
                }
            }

            
            string petName = "";
            bool validPetName = false;

            while (!validPetName)
            {
                Console.WriteLine("Enter Pet's Name:");
                petName = Console.ReadLine() ?? "";
                validPetName = ValdiacionService.ValidName(petName);

                if (!validPetName)
                    Console.WriteLine("Invalid pet name. Try again.");
            }

            string sexo = "";
            bool validSex = false;

            while (!validSex)
            {
                Console.WriteLine("Enter Pet's Sex (Macho/Hembra):");
                sexo = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(sexo) &&
                    (sexo.ToLower() == "macho" || sexo.ToLower() == "hembra"))
                {
                    validSex = true;
                }
                else
                {
                    Console.WriteLine("Invalid sex. Please enter 'Macho' or 'Hembra'.");
                }
            }

            int petAge = 0;
            bool validPetAge = false;

            while (!validPetAge)
            {
                try
                {
                    Console.WriteLine("Enter Pet's Age:");
                    petAge = int.Parse(Console.ReadLine() ?? "");
                    validPetAge = ValdiacionService.ValidAge(petAge);

                    if (!validPetAge)
                        Console.WriteLine("Pet age must be positive. Try again.");
                }
                catch
                {
                    Console.WriteLine("Invalid number. Try again.");
                }
            }

            Console.WriteLine("Enter Pet's Breed:");
            string raza = Console.ReadLine() ?? "";

            Guid petId = Guid.NewGuid();
            var pet = new Pet(petId, petName, sexo, petAge, raza, selectedPatient.Name);

            selectedPatient.AddPet(pet);
            AllPets.Add(pet);

            Console.WriteLine($"\n✅ Pet '{petName}' registered successfully for patient '{selectedPatient.Name}'!");
            return true;
        }
    }
}