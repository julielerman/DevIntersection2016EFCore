using System;
using System.Collections.Generic;

namespace SamuraiApp.Domain
{
  public class Battle
  {
    public Battle() {
     
    }

    public Battle(string name, DateTime start, DateTime end) {
      Name = name;
      StartDate = start;
      EndDate = end;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public Location Location { get; set; }
    public List<SamuraiBattle> SamuraiBattles { get; set; }
  }
}