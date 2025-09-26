

using veterinarian.models;
using veterinarian.service;

namespace veterinarian.ui;

public class Menu
{
    public static void ShowMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("===================Menu===================");
            Console.WriteLine("1.Register Patient");
            Console.WriteLine("2.List Patient");
            Console.WriteLine("3.Patient Search");
            Console.WriteLine("4.EXIT");
            string option = Console.ReadLine() ?? "";
            switch (option)
            {
                case "1":
                    PatientService.RegisterPatient();
                    Console.WriteLine("Patient Register Succefull");
                    Console.ReadKey();
                    break;
                case "2":
                    PatientService.PrintAllPatients();
                    Console.WriteLine("===================");
                     Console.ReadKey();
                    break;
                case "3":
                    PatientService.SearchXName();
                    Console.WriteLine("====================");
                     Console.ReadKey();
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Leaving the menu");
                   Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Option Not Valid");
                     Console.ReadKey();
                    break;
                    


            }
        }
    }

}
