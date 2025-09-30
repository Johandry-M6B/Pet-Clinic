
namespace veterinarian.models;


public class Patient(Guid id, string name, int age, string symptom)
{
    public Guid ID { get; set; } = id;
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public string Symptom { get; set; } = symptom;
    public List<Pet> Pets { get; set; } = new List<Pet>();


    public void MonstraraInformacion()
    {
        Console.WriteLine($"ID:{ID} Name:{Name}, age:{Age}, Symptom: {Symptom} ");
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
                pet.ShowPets();

            }
        }
    }

    public void AddPet(Pet pet)
    {
        Pets.Add(pet);
    }
    public void DeletePet(Guid PetId)
    {
        var pet = Pets.FirstOrDefault(p => p.ID == PetId);
        if (pet != null)
        {
            Pets.Remove(pet);
        }

    }
}
