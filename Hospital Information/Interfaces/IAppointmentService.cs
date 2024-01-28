using Hospital_Information.Model;

namespace Hospital_Information.Interfaces;
public interface IAppointmentService
{
    List<Appointment> SearchAppointments(string keyword);
    List<Appointment> GetAppointmentsForDoctor(int doctorId);
    List<Appointment> GetAppointmentsForPatient(int patientId);
    Appointment GetAppointmentDetails(int appointmentId);
    Appointment ScheduleAppointment(Appointment newAppointment);
}

