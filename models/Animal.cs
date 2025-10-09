namespace veterinarian.models
{
    public abstract class Animal(string petName, int petAge, string raza)
    {
        public string PetName { get; private set; } = petName;
        public int PetAge { get; private set; } = petAge;
        public string Raza { get; private set; } = raza;

        public virtual void ShowAnimals()
        {
            Console.WriteLine($"Animal:{PetName}, Raza:{Raza}, Age:{PetAge}");
        }

        public virtual void AnimalSound()
        {
            Console.WriteLine($"{PetName} Makes a generated sound");
        }
    }

}