

using veterinarian.interfaces;
using veterinarian.models;

namespace veterinarian.service;

public class VeterinarianService : IRegister, IToLookAfter
{
    public static List<Veterinarian> Veterinarians { get; set; } = [];
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
    
    public void RegisterPatientXPet()
    {
        throw new NotImplementedException();
    }

    public void RegisterPet()
    {
        throw new NotImplementedException();
    }

    public void ToLookAfter()
    {
        throw new NotImplementedException();
    }
}
