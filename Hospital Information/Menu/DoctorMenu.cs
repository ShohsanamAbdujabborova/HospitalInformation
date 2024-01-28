using Hospital_Information.Model;
using Hospital_Information.Services;

namespace Hospital_Information.Menu;
public class DoctorMenu
{
    private DoctorService doctorService;

    public DoctorMenu(DoctorService service)
    {
        doctorService = service;
    }

    public void RunDoctorMenu()
    {
        while (true)
        {
            Console.WriteLine("---- Doctor Menu ----");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Get by id");
            Console.WriteLine("5. Get all");
            Console.WriteLine("6. Search");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice (1-7): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    AddDoctor();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.Clear();
                    UpdateDoctor();
                    Console.WriteLine();
                    break;

                case "3":
                    Console.Clear();
                    RemoveDoctor();
                    Console.WriteLine();
                    break;

                case "4":
                    Console.Clear();
                    GetDoctorDetails();
                    Console.WriteLine();
                    break;

                case "5":
                    Console.Clear();
                    ViewAllDoctors();
                    Console.WriteLine();
                    break;

                case "6":
                    Console.Clear();
                    SearchDoctors();
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
    private void AddDoctor()
    {
        Console.WriteLine("Create a new doctor");
        Doctor newDoctor = new();

        Console.Write("Enter doctor name: ");
        newDoctor.Name = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(newDoctor.Name))
        {
            Console.Write("Enter valid doctor name: ");
            newDoctor.Name = Console.ReadLine();
        }

        Console.Write("Enter doctor specialization: ");
        newDoctor.Specialization = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(newDoctor.Specialization))
        {
            Console.Write("Enter valid doctor specialization: ");
            newDoctor.Specialization = Console.ReadLine();
        }

        Console.Write("Enter doctor contact information: ");
        newDoctor.ContactInformation = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(newDoctor.ContactInformation))
        {
            Console.Write("Enter valid doctor contact information: ");
            newDoctor.ContactInformation = Console.ReadLine();
        }
        doctorService.AddDoctor(newDoctor);
        Console.WriteLine("Doctor added successfully!");
    }
    private void UpdateDoctor()
    {
        Console.Write("Enter doctor ID to update: ");
        int doctorId;
        while (!int.TryParse(Console.ReadLine(), out doctorId))
        {
            Console.Write("Enter valid doctor ID to update: ");
        }
        Doctor existingDoctor = doctorService.GetDoctorDetails(doctorId);

        if (existingDoctor != null)
        {
            Doctor updatedDoctor = new()
            {
                Id = doctorId
            };

            Console.Write("Enter new doctor name: ");
            updatedDoctor.Name = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(updatedDoctor.Name))
            {
                Console.Write("Enter valid doctor name: ");
                updatedDoctor.Name = Console.ReadLine();
            }

            Console.Write("Enter new doctor specialization: ");
            updatedDoctor.Specialization = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(updatedDoctor.Specialization))
            {
                Console.Write("Enter valid doctor specialization: ");
                updatedDoctor.Specialization = Console.ReadLine();
            }

            Console.Write("Enter new doctor contact information: ");
            updatedDoctor.ContactInformation = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(updatedDoctor.ContactInformation))
            {
                Console.Write("Enter valid doctor contact information: ");
                updatedDoctor.ContactInformation = Console.ReadLine();
            }

            if (doctorService.UpdateDoctor(updatedDoctor))
            {
                Console.WriteLine("Doctor updated successfully!");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }
        else
        {
            Console.WriteLine("Doctor not found.");
        }
    }
    private void RemoveDoctor()
    {
        Console.Write("Enter doctor ID to remove: ");
        int doctorId;
        while (!int.TryParse(Console.ReadLine(), out doctorId))
        {
            Console.Write("Enter valid doctor ID to remove: ");
        }
        if (doctorService.RemoveDoctor(doctorId))
        {
            Console.WriteLine("Doctor removed successfully!");
        }
        else
        {
            Console.WriteLine("Doctor not found.");
        }
    }
    private void GetDoctorDetails()
    {
        Console.Write("Enter doctor ID to display details: ");
        int doctorId;
        while (!int.TryParse(Console.ReadLine(), out doctorId))
        {
            Console.Write("Enter valid doctor ID to display details: ");
        }
        Doctor doctorDetails = doctorService.GetDoctorDetails(doctorId);
        if (doctorDetails != null)
        {
            Console.WriteLine($"Doctor ID: {doctorDetails.Id}");
            Console.WriteLine($"Name: {doctorDetails.Name}");
            Console.WriteLine($"Specialization: {doctorDetails.Specialization}");
            Console.WriteLine($"Contact Information: {doctorDetails.ContactInformation}");
            Console.WriteLine($"Schedule: {doctorDetails.Schedule}");
        }
        else
        {
            Console.WriteLine("Doctor not found.");
        }
    }
    private void ViewAllDoctors()
    {
        List<Doctor> allDoctors = doctorService.GetAllDoctors();

        if (allDoctors.Count > 0)
        {
            Console.WriteLine("All Doctors:");
            foreach (var doctor in allDoctors)
            {
                Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}");
            }
        }
        else
        {
            Console.WriteLine("No doctors found.");
        }
    }
    private void SearchDoctors()
    {
        Console.Write("Enter any search keyword for doctors: ");
        string searchTerm = Console.ReadLine();

        List<Doctor> searchResults = doctorService.SearchDoctors(searchTerm);

        if (searchResults.Count > 0)
        {
            Console.WriteLine("Search Results for Doctors:");
            foreach (var doctor in searchResults)
            {
                Console.WriteLine($"Doctor ID: {doctor.Id}, Name: {doctor.Name}, Specialization: {doctor.Specialization}, Contact Information: {doctor.ContactInformation}");
            }
        }
        else
        {
            Console.WriteLine("No doctors found matching the search criteria.");
        }
    }
}
