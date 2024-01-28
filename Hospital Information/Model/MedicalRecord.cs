namespace Hospital_Information.Model;
public class MedicalRecord
{
    private static int id;
    public MedicalRecord()
    {
        Id = ++id;
    }
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string MedicalConditions { get; set; }
    public string Medications { get; set; }
    public string TestResults { get; set; }
}
