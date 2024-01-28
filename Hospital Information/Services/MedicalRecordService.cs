using Hospital_Information.Interfaces;
using Hospital_Information.Model;

namespace Hospital_Information.Service;

public class MedicalRecordService : IMedicalRecordService
{
    private List<MedicalRecord> medicalRecords;
    public MedicalRecordService()
    {
        medicalRecords = new List<MedicalRecord>();
    }
    public MedicalRecord CreateMedicalRecord(MedicalRecord newMedicalRecord)
    {
        medicalRecords.Add(newMedicalRecord);
        return newMedicalRecord;
    }

    public MedicalRecord GetMedicalRecordDetails(int medicalRecordId)
    {
        return medicalRecords.FirstOrDefault(mr => mr.Id == medicalRecordId);
    }

    public List<MedicalRecord> GetMedicalRecordsForPatient(int patientId)
    {
        return medicalRecords.Where(mr => mr.PatientId == patientId).ToList();
    }

   public List<MedicalRecord> SearchMedicalRecords(string name)
    {
        List<MedicalRecord> searchResults = new List<MedicalRecord>();
            return searchResults;
        }
    }





   
