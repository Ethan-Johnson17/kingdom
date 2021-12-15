namespace kingdom.Models
{
  public class Castle
  {
    public int Id { get; set; }
    public string Location { get; set; }
    public string Armaments { get; set; }
    public string Population { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
  }
}