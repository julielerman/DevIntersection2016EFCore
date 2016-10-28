using System;

namespace SamuraiApp.Domain
{
  public class SamuraiBattle
  {
    public int Id { get; set; }
    public int SamuraiId { get; set; }
    public int BattleId { get; set; }
    public DateTime DateJoined { get; set; }
    
  }
}