using Hospital_Information.Model;

namespace Hospital_Information.Menu;
public class PatientMenu
{
    private PatientService patientService;
    private string gender;

    public object AnsiConsole { get; private set; }

    public PatientMenu(PatientService service)
    {
        patientService = service;
    }

    public void RunPatientMenu()
    {
        while (true)
        {
            Console.WriteLine("---- Patient Menu ----");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Get by id");
            Console.WriteLine("5. Get all");
            Console.WriteLine("6. Search");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    AddPatient();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.Clear();
                    UpdatePatient();
                    Console.WriteLine();
                    break;

                case "3":
                    Console.Clear();
                    RemovePatient();
                    Console.WriteLine();
                    break;

                case "4":
                    Console.Clear();
                    GetPatientDetails();
                    Console.WriteLine();
                    break;

                case "5":
                    Console.Clear();
                    ViewAllPatients();
                    Console.WriteLine();
                    break;

                case "6":
                    Console.Clear();
                    SearchPatients();
                    Console.WriteLine();
                    break;

                case "7":
                    Console.Clear();
                    Console.WriteLine("Exit.");
                    Console.WriteLine();
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine();
                    break;
            }
        }
    }
    // done
    private void AddPatient()
    {
        Console.WriteLine("Add a new patient");

        Console.Write("Enter patient name: ");
        string name = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(name))
        {
            Console.Write("Enter valid patient name: ");
            name = Console.ReadLine();
        }

        Console.Write("Enter patient age: ");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.Write("Enter valid patient age: ");
        }

        var genderChoices = new[] { "Male", "Female" };
        Console.Write("Select patient gender: \n");
        Console.Write("Enter patient contact information: ");
        string contactInformation = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(contactInformation))
        {
            Console.Write("Enter valid patient contact information: ");
            contactInformation = Console.ReadLine();
        }

        Console.Write("Enter patient medical history: ");
        string medicalHistory = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(medicalHistory))
        {
            Console.Write("Enter valid patient medical history: ");
            medicalHistory = Console.ReadLine();
        }

        Patient newPatient = new()
        {
            Age = age,
            Name = name,
            Gender = gender,
            ContactInformation = contactInformation,
            MedicalHistory = medicalHistory
        };

        patientService.AddPatient(newPatient);
        Console.WriteLine("Patient added successfully!");
    }
    // done
    private void UpdatePatient()
    {
        Console.Write("Enter patient ID to update: ");
        if (!int.TryParse(Console.ReadLine(), out int patientId))
        {
            Console.WriteLine("Invalid ID format. Please enter a valid number.");
        }
        Patient existingPatient = patientService.GetPatientDetails(patientId);

        if (existingPatient != null)
        {
            Patient updatedPatient = new()
            {
                Id = patientId
            };
            Console.Write("Enter patient name: ");
            updatedPatient.Name = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(updatedPatient.Name))
            {
                Console.Write("Enter valid patient name: ");
                updatedPatient.Name = Console.ReadLine();
            }

            Console.Write("Enter patient age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.Write("Enter valid patient age: ");
            }
            updatedPatient.Age = age;

            var genderChoices = new[] { "Male", "Female" };
            Console.Write("Enter patient contact information: ");
            updatedPatient.ContactInformation = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(updatedPatient.ContactInformation))
            {
                Console.Write("Enter valid patient contact information: ");
                updatedPatient.ContactInformation = Console.ReadLine();
            }

            Console.Write("Enter patient medical history: ");
            updatedPatient.MedicalHistory = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(updatedPatient.MedicalHistory))
            {
                Console.Write("Enter valid patient medical history: ");
                updatedPatient.MedicalHistory = Console.ReadLine();
            }

            if (patientService.UpdatePatient(updatedPatient))
            {
                Console.WriteLine("Patient updated successfully!");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }
    // done
    private void RemovePatient()
    {
        Console.Write("Enter patient ID to remove: ");
        if (!int.TryParse(Console.ReadLine(), out int patientId))
        {
            Console.WriteLine("Invalid ID format. Please enter a valid number.");
        }
        if (patientService.RemovePatient(patientId))
        {
            Console.WriteLine("Patient removed successfully!");
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }
    // done
    private void GetPatientDetails()
    {
        Console.Write("Enter patient ID to display details: ");
        if (!int.TryParse(Console.ReadLine(), out int patientId))
        {
            Console.WriteLine("Invalid ID format. Please enter a valid number.");
        }
        Patient patientDetails = patientService.GetPatientDetails(patientId);
        if (patientDetails != null)
        {
            Console.WriteLine($"Patient ID: {patientDetails.Id}");
            Console.WriteLine($"Name: {patientDetails.Name}");
            Console.WriteLine($"Age: {patientDetails.Age}");
            Console.WriteLine($"Gender: {patientDetails.Gender}");
            Console.WriteLine($"Contact Information: {patientDetails.ContactInformation}");
            Console.WriteLine($"Medical History: {patientDetails.MedicalHistory}");
        }
        else
        {
            Console.WriteLine("Patient not found.");
        }
    }
    // done
    private void ViewAllPatients()
    {
        List<Patient> allPatients = patientService.GetAllPatients();

        if (allPatients.Count > 0)
        {
            Console.WriteLine("All Patients:");
            foreach (var patient in allPatients)
            {
                Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}");
            }
        }
        else
        {
            Console.WriteLine("No patients found.");
        }
    }
    // done
    private void SearchPatients()
    {
        Console.Write("Enter any search keyword according to patients: ");
        string searchTerm = Console.ReadLine();

        List<Patient> searchResults = patientService.SearchPatients(searchTerm);

        if (searchResults.Count > 0)
        {
            Console.WriteLine("Search Results for Patients:");
            foreach (var patient in searchResults)
            {
                Console.WriteLine($"Patient ID: {patient.Id}, Name: {patient.Name}, Contact Information: {patient.ContactInformation}");
            }
        }
        else
        {
            Console.WriteLine("No patients found matching the search criteria.");
        }
    }
}