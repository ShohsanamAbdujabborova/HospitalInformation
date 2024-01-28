using Hospital_Information.Model;

namespace Hospital_Information.Interfaces;
public interface IMedicalRecordService
{
        List<MedicalRecord> SearchMedicalRecords(string name);
        List<MedicalRecord> GetMedicalRecordsForPatient(int patientId);
        MedicalRecord GetMedicalRecordDetails(int medicalRecordId);
        MedicalRecord CreateMedicalRecord(MedicalRecord newMedicalRecord);
    }
