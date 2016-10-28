namespace SamuraiApp.Domain
{
  public class Sword
  {
    public int Id { get; set; }
    public int WeightGrams { get; set; }
    public int MakerId { get; set; }
    public Maker Maker { get; set; }
    public int SamuraiId { get; set; }
  }
}