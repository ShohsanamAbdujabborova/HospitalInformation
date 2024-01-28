using Hospital_Information.Model;
using Hospital_Information.Service;

namespace Hospital_Information.Menu;
public class MedicalRecordMenu
{
    private MedicalRecordService medicalRecordService;
    private PatientService patientService;

    public MedicalRecordMenu(MedicalRecordService service, PatientService patientService)
    {
        medicalRecordService = service;
        this.patientService = patientService;

    }

    public void RunMedicalRecordMenu()
    {
        while (true)
        {
            Console.WriteLine("---- Medical Record  Menu (Tibbiy varaqasi,Karta) ----");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Get by id");
            Console.WriteLine("3. Get all");
            Console.WriteLine("4. Search");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    CreateMedicalRecord();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.Clear();
                    GetMedicalRecordDetails();
                    Console.WriteLine();
                    break;

                case "3":
                    Console.Clear();
                    ViewMedicalRecordsForPatient();
                    Console.WriteLine();
                    break;

                case "4":
                    Console.Clear();
                    SearchMedicalRecords();
                    Console.WriteLine();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("Exit");
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
    private void CreateMedicalRecord()
    {
        Console.WriteLine("Create a new medical record");
        MedicalRecord newMedicalRecord = new();

        Console.Write("Enter patient ID: ");
        int patientId;
        while (!int.TryParse(Console.ReadLine(), out patientId))
        {
            Console.Write("Enter valid patient ID: ");
        }
        if (patientService.GetPatientDetails(patientId) == null)
        {
            Console.WriteLine("Patient not found");
            return;
        }
        newMedicalRecord.PatientId = patientId;

        Console.Write("Enter medical conditions: ");
        newMedicalRecord.MedicalConditions = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(newMedicalRecord.MedicalConditions))
        {
            Console.Write("Enter medical conditions: ");
            newMedicalRecord.MedicalConditions = Console.ReadLine();
        }

        Console.Write("Enter medications: ");
        newMedicalRecord.Medications = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(newMedicalRecord.Medications))
        {
            Console.Write("Enter valid medications: ");
            newMedicalRecord.Medications = Console.ReadLine();
        }

        Console.Write("Enter test results: ");
        newMedicalRecord.TestResults = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(newMedicalRecord.TestResults))
        {
            Console.Write("Enter valid test results: ");
            newMedicalRecord.TestResults = Console.ReadLine();
        }
        medicalRecordService.CreateMedicalRecord(newMedicalRecord);
        Console.WriteLine("Medical record created successfully!");
    }
    private void GetMedicalRecordDetails()
    {
        Console.Write("Enter medical record ID: ");
        int medicalRecordId;
        while (!int.TryParse(Console.ReadLine(), out medicalRecordId))
        {
            Console.Write("Enter valid medical record ID: ");
        }
        MedicalRecord medicalRecordDetails = medicalRecordService.GetMedicalRecordDetails(medicalRecordId);

        if (medicalRecordDetails != null)
        {
            Console.WriteLine($"Medical Record ID: {medicalRecordDetails.Id}");
            Console.WriteLine($"Patient ID: {medicalRecordDetails.PatientId}");
            Console.WriteLine($"Medical Conditions: {medicalRecordDetails.MedicalConditions}");
            Console.WriteLine($"Medications: {medicalRecordDetails.Medications}");
            Console.WriteLine($"Test Results: {medicalRecordDetails.TestResults}");
        }
        else
        {
            Console.WriteLine("Medical record not found.");
        }
    }
    private void ViewMedicalRecordsForPatient()
    {
        Console.Write("Enter patient ID: ");
        int patientId;
        while (!int.TryParse(Console.ReadLine(), out patientId))
        {
            Console.Write("Enter valid patient ID: ");
        }

        List<MedicalRecord> patientMedicalRecords = medicalRecordService.GetMedicalRecordsForPatient(patientId);
        if (patientMedicalRecords.Count > 0)
        {
            Console.WriteLine($"Medical Records for Patient ID {patientId}:");
            foreach (var medicalRecord in patientMedicalRecords)
            {
                Console.WriteLine($"Medical Record ID: {medicalRecord.Id}, Conditions: {medicalRecord.MedicalConditions}");
            }
        }
        else
        {
            Console.WriteLine("No medical records found for the patient.");
        }
    }
    private void SearchMedicalRecords()
    {
        Console.Write("Enter any keyword to search: ");
        string keyword = Console.ReadLine();
        while (String.IsNullOrWhiteSpace(keyword))
        {
            Console.Write("Enter any valid keyword to search: ");
            keyword = Console.ReadLine();
        }
        List<MedicalRecord> searchResults = medicalRecordService.SearchMedicalRecords(keyword);

        if (searchResults.Count > 0)
        {
            Console.WriteLine($"Medical Records for this search word <<{keyword}>> of patient:");
            foreach (var medicalRecord in searchResults)
            {
                Console.WriteLine($"Medical Record ID: {medicalRecord.Id}, Conditions: {medicalRecord.MedicalConditions}, TestResults: {medicalRecord.TestResults}");
            }
        }
        else
        {
            Console.WriteLine("No medical records found for the patient.");
        }
    }
}

