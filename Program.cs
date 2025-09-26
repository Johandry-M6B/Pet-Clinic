
using veterinarian.ui;
using veterinarian.models;
using veterinarian.service;

var patients = PatientService.ListPatients;
var paciente1 = new Patient(Guid.NewGuid(), "Johandry", 20, "Cancer");
paciente1.MonstraraInformacion();

Menu.ShowMenu();
