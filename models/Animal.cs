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

        protected static void ValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El name no puede estar vacío");
        }

        protected static void ValidaAge(int petAge)
        {
            if (petAge < 0 || petAge > 100)
                throw new ArgumentException("La age debe estar entre 0 y 100 años");
        }

        protected static void ValidarSpecie(string raza)
        {
            if (string.IsNullOrWhiteSpace(raza))
                throw new ArgumentException("La raza no puede estar vacía");
        }




    }

}