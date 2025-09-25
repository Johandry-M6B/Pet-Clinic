
namespace veterinarian.models;


public class Patient(Guid id, string name, int age, string symptom)
{
    public Guid ID { get; set; } = id;
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public string Symptom { get; set; } = symptom;


    public void MonstraraInformacion()
    {
        Console.WriteLine($"ID:{ID} Name:{Name}, age:{Age}, Symptom: {Symptom} ");
    }
}
