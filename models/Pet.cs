


namespace veterinarian.models;

public class Pet(Guid id, string petName, string sexo, int petAge, string raza, string owner) : Animal(petName, petAge, raza)
{
    public Guid ID { get; private set; } = id;
    public string Owner { get; private set; } = owner;
    public string Sexo { get; private set; } = sexo;



    public override void AnimalSound()
    {
        string sound = ToGetSoundAnimal();
        Console.WriteLine($"{PetName} ({Raza} to Make: {sound})");
    }

    private string ToGetSoundAnimal()
    {
        return Raza.ToLower() switch
        {
            "dog" => "WOW Wow",
            "cat" => "Miua Miau",
            "bird" => "Piua",
            "parrot" => "Hello World",
            _ => "Soundo Not Recognized"

        };
    }
    public override void ShowAnimals()
    {
        Console.WriteLine($"ID:{ID} Name:{PetName}, age:{PetAge}, Sexo: {Sexo}, Raza:{Raza} ");
        AnimalSound();
    }
}

