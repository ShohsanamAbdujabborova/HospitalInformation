namespace Hospital_Information.Model;
public class Doctor
{
    private static int id { get; set; }
    public Doctor()
    {
        Id = ++id;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public string ContactInformation { get; set; }
    public string Schedule { get; set; }
}
