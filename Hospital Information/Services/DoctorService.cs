using Hospital_Information.Interfaces;
using Hospital_Information.Model;

namespace Hospital_Information.Services;
public class DoctorService : IDoctorService
{
    private List<Doctor> doctors;
    public DoctorService()
    {
        doctors = new List<Doctor>();
    }
    public Doctor AddDoctor(Doctor newDoctor)
    {
        doctors.Add(newDoctor);
        return newDoctor;
    }
    public bool UpdateDoctor(Doctor updatedDoctor)
    {
        Doctor doctorToUpdate = doctors.FirstOrDefault(d => d.Id == updatedDoctor.Id);
        if (doctorToUpdate != null)
        {
            doctorToUpdate.Name = updatedDoctor.Name;
            doctorToUpdate.Specialization = updatedDoctor.Specialization;
            doctorToUpdate.ContactInformation = updatedDoctor.ContactInformation;
            doctorToUpdate.Schedule = updatedDoctor.Schedule;
            return true; // Updated successfully
        }
        return false; // Doctor not found
    }
    public bool RemoveDoctor(int doctorId)
    {
        Doctor doctorToRemove = doctors.FirstOrDefault(d => d.Id == doctorId);
        if (doctorToRemove != null)
        {
            doctors.Remove(doctorToRemove);
            return true; // Removed successfully
        }
        return false; // Doctor not found
    }
    public Doctor GetDoctorDetails(int doctorId)
    {
        return doctors.FirstOrDefault(d => d.Id == doctorId);
    }
    public List<Doctor> GetAllDoctors()
    {
        return doctors;
    }
    public List<Doctor> SearchDoctors(string searchTerm)
    {
        List<Doctor> searchResults = new List<Doctor>();

        foreach (Doctor doctor in doctors)
        {
            if (doctor.Name.Contains(searchTerm))
                doctor.Specialization.Contains(searchTerm);
            doctor.ContactInformation.Contains(searchTerm);
            {
                searchResults.Add(doctor);
            }
        }

        return searchResults;
    }
}

