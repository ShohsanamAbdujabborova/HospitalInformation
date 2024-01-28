namespace Hospital_Information.Model;
public class Appointment
{
    private static int id;
    public Appointment()
    {
        Id = ++id;
    }
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime Date { get; set; }
}

