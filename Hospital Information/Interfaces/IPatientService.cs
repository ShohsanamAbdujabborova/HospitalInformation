using Hospital_Information.Model;

namespace Hospital_Information.Interfaces;
public interface IPatientService
{
        List<Patient> SearchPatients(string search);
        List<Patient> GetAllPatients();
        Patient GetPatientDetails(int patientId);
        bool RemovePatient(int patientId);
        Patient AddPatient(Patient newPatient);
        bool UpdatePatient(Patient updatedPatient);
    }


