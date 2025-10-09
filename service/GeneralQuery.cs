using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veterinarian.interfaces;

namespace veterinarian.service
{
    public class GeneralQuery(string type, string description, decimal cost, int duration) : IToLookAfter
    {
        public string Type { get; set; } = type;
        public string Description { get; set; } = description;

        public decimal Cost { get; set; } = cost;
        public int Duration { get; set; } = duration;

        public void ToLookAfter()
        {
            Console.WriteLine($" Starting General Query: {Type}");
            Console.WriteLine($" performing complete physical exam...");
            Console.WriteLine($" checking vital signs...");
            Console.WriteLine($" documenting observations...");
            Console.WriteLine($" ⏱ Duration: {Duration} Minutes");
            Console.WriteLine($" Cost: ${Cost}");
            Console.WriteLine($" ✅ general query '{type}' successfully completed");
        }

        public string GetDescription()
        {
            return $"General Query - {Type}: {Description} ({Duration} Mim)";
        }

        public decimal GetCost()
        {
            return Cost;
        }
    }
}