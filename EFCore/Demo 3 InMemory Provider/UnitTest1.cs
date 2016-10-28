using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Demo_3_InMemory_Provider
{
  [TestClass]
  public class InMemoryTests
  {
    [TestMethod]
    public void Same_DbSetAddAndAddRangeOnSingleObjects() {
      var builder=new DbContextOptionsBuilder<SamuraiContext>();
      builder.UseInMemoryDatabase();
      using (var context = new SamuraiContext(builder.Options)) {
        context.Samurais.AddRange(
          new Samurai {Name="Julie"}, 
          new Samurai {Name="Sampson"}, 
          new Samurai {Name = "Charlie"});
        context.SaveChanges();
        Assert.AreEqual(3, context.Samurais.Count());
        Debug.WriteLine(context.Samurais.Where(s=>s.Name=="Sampson").FirstOrDefault().Id);
      }
    }
  }
}