using System.Collections.Generic;

namespace SamuraiApp.Domain
{
  public class Samurai
  {
    public Samurai() {
      Quotes = new List<Quote>();
      SamuraiBattles = new List<SamuraiBattle>();
      Swords = new List<Sword>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public List<SamuraiBattle> SamuraiBattles { get; set; }  //explicit join entities
    public List<Quote> Quotes { get; set; }
    public List<Sword> Swords { get; set; }
    public SecretIdentity SecretIdentity { get; set; }
  }
}