using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veterinarian.interfaces;

namespace veterinarian.service
{
    public class Aesthetics(string service, string description, decimal cost) : IToLookAfter
    {
        public string Service { get; set; } = service;
        public string Description { get; set; } = description;
        public decimal Cost { get; set; } = cost;

        public void ToLookAfter()
        {
            Console.WriteLine($"✨ Starting Aesthetics Service:");
            Console.WriteLine($"   ✂️  Service: {Service}");
            Console.WriteLine($"   📋 {Description}");
            Console.WriteLine($"   🛁 Bath and drying...");
            Console.WriteLine($"   ✂️  Haircut...");
            Console.WriteLine($"   ✨ Aesthetic cleaning...");
            Console.WriteLine($"   💰 Cost: ${Cost}");
            Console.WriteLine($"   ✅ Aesthetics service '{Service}' completed");
        }

        public string GetDescription()
        {
            return $"Aesthetics - {Service}: {Description}";
        }

        public decimal GetCost()
        {
            return Cost;
        }
    }
}
