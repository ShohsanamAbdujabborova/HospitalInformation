using Hospital_Information.Model;

namespace Hospital_Information.Interfaces;
public interface IDoctorService
{
        List<Doctor> SearchDoctors(string searchTerm);
        List<Doctor> GetAllDoctors();
        Doctor GetDoctorDetails(int doctorId);
        bool RemoveDoctor(int doctorId);
        bool UpdateDoctor(Doctor updatedDoctor);
        Doctor AddDoctor(Doctor newDoctor);

    }

