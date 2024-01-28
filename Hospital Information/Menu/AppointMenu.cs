using Hospital_Information.Model;
using Hospital_Information.Services;

namespace Hospital_Information.Menu;
public class AppointmentMenu
{
    private AppointmentService appointmentService;
    private DoctorService doctorService;
    private PatientService patientService;
    public AppointmentMenu(AppointmentService service, DoctorService doctorService, PatientService patientService)
    {
        appointmentService = service;
        this.doctorService = doctorService;
        this.patientService = patientService;
    }

    public void RunAppointmentMenu()
    {
        while (true)
        {
            Console.WriteLine("---- Appointment (Uchrashuv) ----");
            Console.WriteLine("1. Schedule a new appointment");
            Console.WriteLine("2. Get by id");
            Console.WriteLine("3. Show appointments for a patient");
            Console.WriteLine("4. Show appointments for a doctor");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    ScheduleAppointment();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.Clear();
                    GetAppointmentDetails();
                    Console.WriteLine();
                    break;

                case "3":
                    Console.Clear();
                    ViewAppointmentsForPatient();
                    Console.WriteLine();
                    break;

                case "4":
                    Console.Clear();
                    ViewAppointmentsForDoctor();
                    Console.WriteLine();
                    break;

                case "5":
                    Console.Clear();
                    SearchAppointments();
                    Console.WriteLine();
                    break;

                case "6":
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
    private void ScheduleAppointment()
    {
        Console.WriteLine("Schedule a new appointment");
        Appointment newAppointment = new();

        Console.Write("Enter patient ID: ");
        int patientId;
        while (!int.TryParse(Console.ReadLine(), out patientId))
        {
            Console.Write("Enter valid patient ID.");
        }
        var patientDetails = patientService.GetPatientDetails(patientId);

        if (patientDetails == null)
        {
            Console.WriteLine("This patient is not in the list");
            return;
        }

        int doctorId;
        Console.Write("Enter doctor ID: ");
        while (!int.TryParse(Console.ReadLine(), out doctorId))
        {
            Console.Write("Enter valid doctor ID.");
        }
        var doctorDetails = doctorService.GetDoctorDetails(doctorId);

        if (doctorDetails == null)
        {
            Console.WriteLine("This doctor is not in the list");
            return;
        }
        Console.Write("Enter appointment date and time (YYYY-MM-DD): ");
        DateTime date;
        while (!DateTime.TryParse(Console.ReadLine(), out date))
        {
            Console.Write("Enter valid appointment date and time (YYYY-MM-DD): ");
        }
        newAppointment.DoctorId = doctorId;
        newAppointment.Date = date;
        newAppointment.PatientId = patientId;
        appointmentService.ScheduleAppointment(newAppointment);
        Console.WriteLine("Appointment scheduled successfully!");

    }
    private void SearchAppointments()
    {
        Console.Write("Enter keyword: ");
        string keyword = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(keyword))
        {
            Console.Write("Enter valid keyword: ");
            keyword = Console.ReadLine();
        }

        List<Appointment> searchResults = appointmentService.SearchAppointments(keyword);

        if (searchResults.Count > 0)
        {
            Console.WriteLine($"Appointments for Patient you searched are: ");
            foreach (var appointment in searchResults)
            {
                Console.WriteLine($"Appointment ID: {appointment.Id}, Date: {appointment.Date}");
            }
        }
        else
        {
            Console.WriteLine("No appointments found for the specified criteria.");
        }
    }
    private void GetAppointmentDetails()
    {
        Console.Write("Enter appointment ID: ");
        int appointmentId;
        while (!int.TryParse(Console.ReadLine(), out appointmentId))
        {
            Console.Write("Enter valid appointment ID: ");
        }

        Appointment appointmentDetails = appointmentService.GetAppointmentDetails(appointmentId);
        if (appointmentDetails != null)
        {
            Console.WriteLine($"Appointment ID: {appointmentDetails.Id}");
            Console.WriteLine($"Patient ID: {appointmentDetails.PatientId}");
            Console.WriteLine($"Doctor ID: {appointmentDetails.DoctorId}");
            Console.WriteLine($"Date: {appointmentDetails.Date}");
        }
        else
        {
            Console.WriteLine("Appointment not found.");
        }
    }
    private void ViewAppointmentsForPatient()
    {
        Console.Write("Enter patient ID: ");
        int patientId;
        while (!int.TryParse(Console.ReadLine(), out patientId))
        {
            Console.Write("Enter valid patient ID: ");
        }

        List<Appointment> patientAppointments = appointmentService.GetAppointmentsForPatient(patientId);
        if (patientAppointments.Count > 0)
        {
            Console.WriteLine($"Appointments for Patient ID {patientId}:");
            foreach (var appointment in patientAppointments)
            {
                Console.WriteLine($"Appointment ID: {appointment.Id}, Doctor ID: {appointment.DoctorId}, Date: {appointment.Date}");
            }
        }
        else
        {
            Console.WriteLine("No appointments found for the patient.");
        }
    }
    private void ViewAppointmentsForDoctor()
    {
        Console.Write("Enter doctor ID: ");
        int doctorId;
        while (!int.TryParse(Console.ReadLine(), out doctorId))
        {
            Console.Write("Enter valid doctor ID: ");
        }
        List<Appointment> doctorAppointments = appointmentService.GetAppointmentsForDoctor(doctorId);
        if (doctorAppointments.Count > 0)
        {
            Console.WriteLine($"Appointments for Doctor ID {doctorId}:");
            foreach (var appointment in doctorAppointments)
            {
                Console.WriteLine($"Appointment ID: {appointment.Id}, Patient ID: {appointment.PatientId}, Date: {appointment.Date}");
            }
        }
        else
        {
            Console.WriteLine("No appointments found for the doctor.");
        }
    }
}