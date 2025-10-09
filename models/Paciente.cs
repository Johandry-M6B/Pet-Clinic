
namespace veterinarian.models;


public class Patient(Guid id, string name, int age, string phone, string adrress):Person(name,age)
{
    public Guid ID { get; private set; } = id;
    public string Phone { get; private set; } = phone;
    public string Adrress { get; private set; } = adrress;
    public List<Pet> Pets { get; private set; } = [];
    public static int Count { get; internal set; }

    public override void ShowInformacion()
    {
        Console.WriteLine($"ID:{ID} Name:{Name}, age:{Age}, Phone: {Phone}, Adrres:{Adrress} ");
        ShowPets();
    }

    public void ShowPets()
    {
        if (Pets.Count == 0)
        {
            Console.WriteLine("No haves Pets Register");
        }
        else
        {
            Console.WriteLine($"----- PETS({Pets.Count}-----)");
            foreach (var pet in Pets)
            {
                Console.WriteLine("  ");
                pet.ShowAnimals();

            }
        }
    }

    public void AddPet(Pet pet)
    {
        Pets.Add(pet);
    }
    public bool DeletePet(Guid PetId)
    {
        var pet = Pets.FirstOrDefault(p => p.ID == PetId);
        if (pet != null)
        {
            return Pets.Remove(pet);
        }
        return false;
    }
}
