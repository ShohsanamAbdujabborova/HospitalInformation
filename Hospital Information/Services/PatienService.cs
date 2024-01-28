using Hospital_Information.Interfaces;
using Hospital_Information.Model;

namespace Hospital_Information;
public class PatientService : IPatientService
{
    private List<Patient> patients;
    public PatientService()
    {
        patients = new List<Patient>();
    }
    // done
    public Patient AddPatient(Patient newPatient)
    {
        patients.Add(newPatient);
        return newPatient;
    }
    // done
    public bool UpdatePatient(Patient updatedPatient)
    {
        Patient patientToUpdate = patients.FirstOrDefault(p => p.Id == updatedPatient.Id);
        if (patientToUpdate != null)
        {
            patientToUpdate.Name = updatedPatient.Name;
            patientToUpdate.Age = updatedPatient.Age;
            patientToUpdate.Gender = updatedPatient.Gender;
            patientToUpdate.ContactInformation = updatedPatient.ContactInformation;
            patientToUpdate.MedicalHistory = updatedPatient.MedicalHistory;
            return true; // Updated successfully
        }
        return false; // Patient not found
    }
    // done
    public bool RemovePatient(int patientId)
    {
        Patient patientToRemove = patients.FirstOrDefault(p => p.Id == patientId);
        if (patientToRemove != null)
        {
            patients.Remove(patientToRemove);
            return true; // Removed successfully
        }
        return false; // Patient not found
    }
    public Patient GetPatientDetails(int patientId)
    {
        return patients.FirstOrDefault(p => p.Id == patientId);
    }
    public List<Patient> GetAllPatients()
    {
        return patients;
    }
    // 
    public List<Patient> SearchPatients(string search)
    {
        List<Patient> searchResults = new List<Patient>();
        return searchResults;
    }
}