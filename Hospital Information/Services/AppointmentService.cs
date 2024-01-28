using Hospital_Information.Interfaces;
using Hospital_Information.Model;

namespace Hospital_Information.Services;
public class AppointmentService : IAppointmentService
{
    private List<Appointment> appointments;

    public AppointmentService()
    {
        appointments = new List<Appointment>();
    }
    public Appointment ScheduleAppointment(Appointment newAppointment)
    {
        appointments.Add(newAppointment);
        return newAppointment;
    }
    public Appointment GetAppointmentDetails(int appointmentId)
    {
        return appointments.FirstOrDefault(appointment => appointment.Id == appointmentId);
    }
    public List<Appointment> GetAppointmentsForPatient(int patientId)
    {
        return appointments.Where(appointment => appointment.PatientId == patientId).ToList();
    }
    public List<Appointment> GetAppointmentsForDoctor(int doctorId)
    {
        return appointments.Where(appointment => appointment.DoctorId == doctorId).ToList();
    }
    public List<Appointment> SearchAppointments(string keyword)
    {
        List<Appointment> searchResults = new List<Appointment>();

        foreach (Appointment appointment in appointments)
        {
            if (appointment.PatientId.ToString() == keyword || appointment.DoctorId.ToString() == keyword)
                searchResults.Add(appointment);
        }

        return searchResults;
    }
}



