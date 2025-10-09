using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veterinarian.interfaces;

namespace veterinarian.service
{
    public class Vaccination(string typeVa, string dose, decimal cost, string laboratory) : IToLookAfter
    {
        public string TypeVa { get; set; } = typeVa;
        public string Dose { get; set; } = dose;
        public decimal Cost { get; set; } = cost;
        public string Laboratory { get; set; } = laboratory;

        public void ToLookAfter()
        {
            Console.WriteLine($" starting vaccination process:");
            Console.WriteLine($" Preparing Vaccine: {TypeVa}");
            Console.WriteLine($" Dose applied: {dose}");
            Console.WriteLine($" Laboratory: {Laboratory}");
            Console.WriteLine($" Disinfecting application area...");
            Console.WriteLine($" applying vaccine...");
            Console.WriteLine($" Cost: ${Cost}");
            Console.WriteLine($" ✅ Vaccination '{TypeVa}' applied correctly");
            Console.WriteLine($" Reminder: Next dose in 1 year");
        }

        public string GetDescription()
        {
            return $"Vaccination - {TypeVa} ({Dose}) - {Laboratory}";
        }

        public decimal GetCost()
        {
            return Cost;
        }
    }
}