namespace Mappings
{
  public class Quote
  {
    internal static Quote Create(string text, int samuraiId)
    {
      return new Quote(text, samuraiId);
    }

    private Quote(string text, int samuraiId)
    {
      Text = text;
      SamuraiId = samuraiId;

    }
    private Quote()
    {
      
    }
    public int Id { get; set; }
    public string Text { get; set; }

    //public Samurai Samurai { get; set; }
    public int SamuraiId { get; set; }
  }
}