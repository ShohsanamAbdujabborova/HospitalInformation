namespace Hospital_Information.Model;
public class Patient
{
    private static int id { get; set; }
    public Patient()
    {
        Id = ++id;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string ContactInformation { get; set; }
    public string MedicalHistory { get; set; }
}
