using veterinarian.models;
using veterinarian.interfaces;
using PetClinic.interfaces;

namespace veterinarian.service;

public class PatientService : IRegister, INotificion
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
    public void SendNotificion(string patientName)
    {
        if (Patient.Count == 0)
        {
            Console.WriteLine("No Patients Registered");
            return;
        }
        var patient = Patients.FirstOrDefault(p =>
        p.Name.ToLower().Contains(patientName.ToLower()));

        if (patient == null)
        {
            Console.WriteLine($"Patient '{patientName}' Not found.");
            return;
        }
        ;
        Console.WriteLine($"Specific notification for: {patient.Name.ToLower()}");
        Console.WriteLine($"Phone:{patient.Phone}");
        Console.WriteLine($"Address: {patient.Adrress}");
        Console.WriteLine($"Import: your pet's  annual chekup is due");
        Console.WriteLine($"Register pets:{patient.Pets.Count}");

        if (patient.Pets.Count > 0)
        {
            Console.WriteLine("Pets requiring attention:");
            foreach (var pet in patient.Pets)
            {
                Console.WriteLine($"---{pet.PetName} ({pet.Raza}) - {pet.PetAge} years");
                    //Se puede agregar mas especialidades

                if (pet.PetAge > 7)
                {
                    Console.WriteLine("Senior pet - may require additional care");

                }
            }
        }
    }


}
