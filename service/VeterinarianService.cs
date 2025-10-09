

using System.Security.Cryptography.X509Certificates;
using veterinarian.interfaces;
using veterinarian.models;

namespace veterinarian.service;

public class VeterinarianService() : IRegister, IToLookAfter
{
    private static List<Patient> Patients => PatientService.Patients;
    private static List<Pet> AllPets => PatientService.AllPets;
    public static List<IToLookAfter> ServiveReally { get; set; } = [];
    public static List<Veterinarian> Veterinarians { get; set; } = [];

    public decimal GetCost()
    {
        return 0;
    }

    public string GetDescription()
    {
        return " Service of Management Veterianrian";
    }

    public bool Register()
    {
        try
        {
            string name = "";
            bool validName = false;

            while (!validName)
            {
                Console.WriteLine("Enter Veterianrian's Name:");
                name = Console.ReadLine() ?? "";
                validName = ValdiacionService.ValidName(name);

                if (!validName)
                    Console.WriteLine("Invalid name, Name Cannot be empty. Try again");
            }

            int age = 0;
            bool validAge = false;

            while (!validAge)
            {
                try
                {
                    Console.WriteLine("Entered Years Veterianrian's:");
                    age = int.Parse(Console.ReadLine() ?? "");
                    validAge = ValdiacionService.ValidAge(age);
                    if (!validAge)
                        Console.WriteLine("Age must be positive. Try Again");
                }
                catch
                {
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("Enter Veterinarian's Phone");
            string phone = Console.ReadLine() ?? "";

            Console.WriteLine("Enter Veterianrian's Major");
            string major = Console.ReadLine() ?? "";
            Guid id = Guid.NewGuid();
            var veterinarian = new Veterinarian(id, name, age, phone, major);
            Veterinarians.Add(veterinarian);

            Console.WriteLine($"\n Veterianrian '{name}' registered successfully!");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error Register veterianrian: {ex.Message}");
            return false;
        }
    }
    public void ToLookAfter()
    {
        try
        {
            Console.WriteLine("\n--- VETERINARY SERVICES AVAILABLE ---");
            Console.WriteLine("1. General Inquiry ($50)");
            Console.WriteLine("2. Triple Vaccination ($30)");
            Console.WriteLine("3. Rabies vaccination ($25)");
            Console.WriteLine("4. Sterilization surgery ($200)");
            Console.WriteLine("5. Major surgery ($500)");
            Console.WriteLine("6. Bathroom and Aesthetic Cut ($40)");
            Console.WriteLine("7. Dental Cleaning ($80)");

            Console.WriteLine("Select Option:");
            string option = Console.ReadLine() ?? "";

            IToLookAfter service = CreateService(option);

            Console.WriteLine($"Service Staring:{service.GetDescription()} Service");
            service.ToLookAfter();

            ServiveReally.Add(service);
            Console.WriteLine($"Service Register of the system. Total:{ServiveReally.Count} Service");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
        }
    }
    private static IToLookAfter CreateService(string option)
    {
        return option switch
        {
            "1" => new GeneralQuery("Annual Check", "Complete Health Review", 50.00m, 30),
            "2" => new Vaccination("Triple Felina", "1 Dose", 30.00m, "Zoetis"),
            "3" => new Vaccination("antirabies", "1 doses", 25.00m, "Merial"),
            "4" => new Surgery("Sterilization", "Routine", 200.00m, 2),
            "5" => new Surgery("Tumor Extraction", "Complex", 500.00m, 4),
            "6" => new Aesthetics("Bath and Cut", "Haircut and Hygienic Bath", 40.00m),
            "7" => new GeneralQuery("Dental Cleaning", "Complete Dental Prophylaxis", 80.00m, 45),
            _ => new GeneralQuery("Basic Consultation", "Standard Service", 35.00m, 20)

        };


    }
    public static void ShowSeriviceFulfilled(){
        if (ServiveReally.Count == 0)
        {
            Console.WriteLine("No services have been performed yet.");
            return;
        }

        Console.WriteLine("---- HISTORY OF SERVICE FULFILLLED");
        decimal totalEntry = 0;

        for (int i = 0; i < ServiveReally.Count; i++)
        {
            var service = ServiveReally[i];
            Console.WriteLine($"{i + 1}. {service.GetDescription()} - ${service.GetCost()}");
            totalEntry += service.GetCost();
        }

        Console.WriteLine($"TOTAL OF ENTRY: ${totalEntry}");
        Console.WriteLine($"TOTAL OF SERVICE: {ServiveReally.Count}");
    }
}
