using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veterinarian.models;

public class Veterinarian(Guid id,string name, int age, string major,string phone) : Person(name, age)
{
    public Guid ID { get; set; } = id;
    public string Major { get; set; } = major;
    public string Phone { get; set; } = phone;
    public override void ShowInformacion()
    {
        Console.WriteLine($"Name:{Name} Age:{Age} Major:{Major} Phone:{Phone}");
    }


}
