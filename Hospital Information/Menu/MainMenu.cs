using Hospital_Information.Service;
using Hospital_Information.Services;
using Spectre.Console;
namespace Hospital_Information.Menu;
public class MainMenu
{
    private DoctorMenu doctorMenu;
    private PatientMenu patientMenu;
    private MedicalRecordMenu medicalRecordMenu;
    private AppointmentMenu appointmentMenu;

    public MainMenu()
    {
        DoctorService doctorService = new();
        doctorMenu = new DoctorMenu(doctorService);

        PatientService patientService = new();
        patientMenu = new PatientMenu(patientService);

        MedicalRecordService medicalRecordService = new();
        medicalRecordMenu = new MedicalRecordMenu(medicalRecordService, patientService);

        AppointmentService appointmentService = new();
        appointmentMenu = new AppointmentMenu(appointmentService, doctorService, patientService);
    }
    public void RunMainMenu()
    {
        AnsiConsole.Write(new Markup("[green] Hospital Information![/]\n"));
        while (true)
        {
            AnsiConsole.Write(new Markup("[yellow]---- Main Menu ----[/]\n"));
            AnsiConsole.Write(new Markup("1.[red] Doctor  Menu[/]\n"));
            AnsiConsole.Write(new Markup("2.[green] Patient  Menu[/]\n"));
            AnsiConsole.Write(new Markup("3.[yellow] Medical Record  Menu [/]\n"));
            AnsiConsole.Write(new Markup("4.[red] Appointment Menu[/]\n"));
            AnsiConsole.Write(new Markup("5.[green] Exit[/]\n"));
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    doctorMenu.RunDoctorMenu();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.Clear();
                    patientMenu.RunPatientMenu();
                    Console.WriteLine();
                    break;

                case "3":
                    Console.Clear();
                    medicalRecordMenu.RunMedicalRecordMenu();
                    Console.WriteLine();
                    break;

                case "4":
                    Console.Clear();
                    appointmentMenu.RunAppointmentMenu();
                    Console.WriteLine();
                    break;

                case "5":
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
}

