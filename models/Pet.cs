


namespace veterinarian.models;

public class Pet(Guid id, string petName, string sexo, int petAge, string raza)
{
    public Guid ID { get; set; } = id;
    public string PetName { get; set; } = petName;
    public string Sexo { get; set; } = sexo;
    public int PetAge { get; set; } = petAge;
    public string Raza { get; set; } = raza;


public void ShowPets()
{
    Console.WriteLine($"ID:{ID} Name:{PetName}, age:{PetAge}, Sexo: {Sexo}, Raza:{Raza} ");
}

}

