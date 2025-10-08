using veterinarian.models;
using veterinarian.interfaces;

namespace veterinarian.service;

public class PatientService : IRegister
{
    public static List<Patient> Patients { get; set; } = [];
    public static List<Pet> AllPets { get; set; } = [];

    bool IRegister.Register()
    {
        try
        {
            string name = "";
            bool validName = false;

            while (!validName)
            {
                Console.WriteLine("Enter Patient's Name:");
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
                    Console.WriteLine("Patient Years Entered:");
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

            Console.WriteLine("Enter Patient's Phone:");
            string phone = Console.ReadLine() ?? "";

            Console.WriteLine("Enter Patient's Address:");
            string adrress = Console.ReadLine() ?? "";

            Guid id = Guid.NewGuid();
            var patient = new Patient(id, name, age, phone, adrress);
            Patients.Add(patient);

            Console.WriteLine($"\n Patient '{name}' registered successfully!");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error register patient: {ex.Message}");
            return false;
        }
    }
    void IRegister.RegisterPatientXPet()

    {
        if (Patients.Count == 0)
        {
            Console.WriteLine("No patients registered. Please register a patient first.");
            return;
        }

        Console.WriteLine("\n--- REGISTER PET FOR PATIENT ---");


        Console.WriteLine("\nAvailable Patients:");
        foreach (var patient in Patients)
        {
            Console.WriteLine($"- {patient.Name} (Age: {patient.Age})");
        }

        string patientName = "";
        Patient? selectedPatient = null;

        while (selectedPatient == null)
        {
            Console.WriteLine("\nEnter patient NAME to add pet:");
            patientName = Console.ReadLine() ?? "";

            if (!ValdiacionService.ValidName(patientName))
            {
                Console.WriteLine("Invalid patient name. Try again.");
                continue;
            }

            selectedPatient = Patients.FirstOrDefault(p =>
                p.Name.ToLower().Contains(patientName.ToLower()));

            if (selectedPatient == null)
            {
                Console.WriteLine("Patient not found. Available patients:");
                foreach (var patient in Patients)
                {
                    Console.WriteLine($"- {patient.Name}");
                }
            }
        }


        RegisterPetForPatient(selectedPatient);
    }

    void IRegister.RegisterPet()
    {
        if (Patients.Count == 0)
        {
            Console.WriteLine("No patient resgister. please a patient first");
            return;
        }
        Console.WriteLine("----------REGISTER PETS---------------");

        Console.WriteLine("avaible Patients");
        foreach (var patient in Patients)
        {
            Console.WriteLine($"-{patient.Name}");
        }
        Patient? selectedPatient = null;
        while (selectedPatient == null)
        {
            Console.WriteLine("Enter Patient NAME for the pet");
            string patientName = Console.ReadLine() ?? "";

            if (!ValdiacionService.ValidName(patientName))
            {
                Console.WriteLine("Invalide Patient name. try again");
                continue;
            }
            selectedPatient = Patients.FirstOrDefault(p =>
            p.Name.ToLower().Contains(patientName.ToLower()));

            if (selectedPatient == null)
            {
                Console.WriteLine("Patient not found. try again.");
            }
        }
        RegisterPetForPatient(selectedPatient);
    }
    private static void RegisterPetForPatient(Patient patient)
    {
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
        var pet = new Pet(petId, petName, sexo, petAge, raza, patient.Name);

        patient.AddPet(pet);
        AllPets.Add(pet);

        Console.WriteLine($"\n✅ Pet '{petName}' registered successfully for patient '{patient.Name}'!");
    }
    public static void ShowPetsOfSpecificPatient()
    {
        if (Patients.Count == 0)
        {
            Console.WriteLine("No Patients Registered");
            return;
        }

        Console.WriteLine("\n--- SHOW PETS OF SPECIFIC PATIENT ---");

        // Mostrar lista de pacientes
        Console.WriteLine("\nAvailable Patients:");
        foreach (var patient in Patients)
        {
            Console.WriteLine($"- {patient.Name} ({patient.Pets.Count} pets)");
        }

        string patientName = "";
        Patient? selectedPatient = null;

        while (selectedPatient == null)
        {
            Console.WriteLine("\nEnter patient NAME to view pets:");
            patientName = Console.ReadLine() ?? "";

            if (!ValdiacionService.ValidName(patientName))
            {
                Console.WriteLine("Invalid patient name. Try again.");
                continue;
            }

            // Buscar paciente por nombre
            selectedPatient = Patients.FirstOrDefault(p =>
                p.Name.ToLower().Contains(patientName.ToLower()));

            if (selectedPatient == null)
            {
                Console.WriteLine("Patient not found. Available patients:");
                foreach (var patient in Patients)
                {
                    Console.WriteLine($"- {patient.Name}");
                }
            }
        }

        Console.WriteLine($"\n--- PETS OF PATIENT: {selectedPatient.Name} ---");
        selectedPatient.ShowPets();
    }
    public static void PooPets()
    {
        if (AllPets.Count == 0)
        {
            Console.WriteLine("No pets Register to demonstrate polymorphism.");
            return;
        }
        Console.WriteLine("\n🎭 POLYMORPHISM DEMONSTRATION WITH PETS");
        Console.WriteLine("=======================================");

        foreach (var pet in AllPets)
        {
            Console.WriteLine($"\n--- {pet.PetName} ({pet.Raza})");
            pet.AnimalSound();
        }

    }
    public static void SearchPetXSpecie()
    {
        if (AllPets.Count == 0)
        {
            Console.WriteLine("No pets register");
            return;
        }
        Console.WriteLine("Enter specie to search(Dog,Cat or Parrot.)");
        string raza = Console.ReadLine() ?? "";

        var petsFilter = AllPets
         .Where(p => p.Raza.Equals(raza, StringComparison.OrdinalIgnoreCase))
         .ToList();

        if (!petsFilter.Any())
        {
            Console.WriteLine($"No pets found of specie:{raza}");
            return;

        }
        Console.WriteLine($"PETS OF SPECIES: {raza.ToUpper()} ({petsFilter.Count})");

        foreach (var pet in petsFilter)
        {
            pet.ShowAnimals();
        }
    }


    public static void ShowPatientWithPets()
    {
        if (Patients.Count == 0)
        {
            Console.WriteLine("No Patients Registered");
            return;
        }

        Console.WriteLine("\n--- ALL PATIENTS WITH THEIR PETS ---");
        foreach (var patient in Patients)
        {
            patient.ShowInformacion();
            Console.WriteLine(); // Línea en blanco para separar
        }
    }

    public static void PrintAllPatients()
    {
        if (Patients.Count == 0)
        {
            Console.WriteLine("No Patients Registered");
            return;
        }

        Console.WriteLine($"\n--- LIST OF PATIENTS ({Patients.Count}) ---");
        foreach (var patient in Patients)
        {
            Console.WriteLine($"Name: {patient.Name}, Age: {patient.Age}, Pets: {patient.Pets.Count}");
        }
    }

    public static void SearchXName()
    {
        if (Patients.Count == 0)
        {
            Console.WriteLine("No Patients Registered");
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
            patient.ShowInformacion();
        }
    }  
}
