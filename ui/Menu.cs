

using veterinarian.interfaces;
using veterinarian.models;
using veterinarian.service;

namespace veterinarian.ui;

public class Menu
{
    public static void ShowMenu()
    {
        IRegister obte = new PatientService();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("===================Menu===================");
            Console.WriteLine("1.Register Patient");
            Console.WriteLine("2.Register Pet forPatient");
            Console.WriteLine("3.Show all Patients with Pets");
            Console.WriteLine("4.Show Pets of specific patient");
            Console.WriteLine("5.Searche patient by name");
            Console.WriteLine("6.Poly");
            Console.WriteLine("7.Search pets by species");
            Console.WriteLine("8.Add medical record to Pet");
            Console.WriteLine("9.EXIT");
            string option = Console.ReadLine() ?? "";
            switch (option)
            {
                case "1":
                    obte.Register();
                    Console.WriteLine("Patient Register Succefull");
                    Console.ReadKey();
                    break;
                case "2":
                    obte.RegisterPatientXPet();
                    Console.WriteLine("===================");
                    Console.ReadKey();
                    break;
                case "3":
                    PatientService.ShowPatientWithPets();
                    Console.WriteLine("====================");
                    Console.ReadKey();
                    break;
                case "4":
                    PatientService.ShowPetsOfSpecificPatient();
                    Console.ReadKey();
                    break;
                case "5":
                    PatientService.SearchXName();
                    Console.ReadKey();
                    break;
                case "6":
                    PatientService.PooPets();
                    Console.ReadKey();
                    break;
                case "7":
                    PatientService.ShowPetsOfSpecificPatient();
                    Console.ReadKey();
                    break;
                case "8":
                    obte.Register();
                    Console.ReadKey();
                    break;
                case "9":
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
