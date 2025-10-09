using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veterinarian.interfaces;

namespace veterinarian.service
{
    public class Surgery(string TypeSurgery, string complexity, decimal cost, int duration) : IToLookAfter
    {
        public string TypeSurgery { get; } = TypeSurgery;
        public string Complexity { get; } = complexity;
        public decimal Cost { get; } = cost;
        public int Duration { get; } = duration;

        public void ToLookAfter()
        {
            Console.WriteLine($" Starting Surgical Procedure:");
            Console.WriteLine($" Type: {TypeSurgery}");
            Console.WriteLine($" ⚠ Complexity: {Complexity}");
            Console.WriteLine($" ⏱ Estimated duration: {Duration} hours");
            Console.WriteLine($" applying anesthesia...");
            Console.WriteLine($" performing procedure...");
            Console.WriteLine($" Suturando...");
            Console.WriteLine($" Cost: ${Cost}");
            Console.WriteLine($" ✅ Surgery '{TypeSurgery}' successfully completed");
        }

        public string GetDescription()
        {
            return $"Surgery - {TypeSurgery} ({Complexity}) - {Duration} Hours ";
        }

        public decimal GetCost()
        {
            return Cost;
        }
    }
}