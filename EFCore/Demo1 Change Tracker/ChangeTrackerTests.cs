using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System.Linq;

namespace Demo1_Change_Tracker
{
  [TestClass]
  public class ChangeTrackerTests

  {
    [TestMethod]
    public void Same_DbSetAddAndAddRangeOnSingleObjects() {
      using (var context = new SamuraiContext()) {
        context.Samurais.Add(new Samurai());
        context.Samurais.AddRange(new Samurai(), new Samurai(), new Samurai());
        Assert.AreEqual(4, context.Samurais.Local.Count());
      }
    }

    [TestMethod]
    public void New_CanUpdate() {
      using (var context = new SamuraiContext()) {
        var samurai = new Samurai();
        context.Samurais.Update(samurai);

        Assert.AreEqual(EntityState.Modified, context.Entry(samurai).State);
      }
    }

    [TestMethod]
    public void New_DbContextRepositoryMethods_DetectsType() {
      using (var context = new SamuraiContext()) {
        context.Add(new Samurai());

        Assert.AreEqual(1, context.Samurais.Local.Count());
      }
    }

    [TestMethod]
    public void New_DbContextDetectsMultipleTypes() {
      using (var context = new SamuraiContext()) {
        context.AddRange(new Samurai(), new Quote());

        Assert.AreEqual(1, context.Samurais.Local.Count);
        Assert.AreEqual(1, context.Quotes.Local.Count());
      }
    }

    [TestMethod]
    public void Same_AddGraphOfUntrackedObjects_MarksAllAdded() {
      using (var context = new SamuraiContext()) {
        var samuraiWithQuote = new Samurai();
        samuraiWithQuote.Quotes.Add(new Quote());
        context.Samurais.Add(samuraiWithQuote);
        Assert.AreEqual(2, context.ChangeTracker.Entries().Count(e => e.State == EntityState.Added));
      }
    }

    

    [TestMethod]
    public void Changed_EntryStateTouchesRootOnly() {
      var samurai = new Samurai();
      samurai.Quotes.Add(new Quote());
      using (var context = new SamuraiContext()) {
        context.Entry(samurai).State = EntityState.Added;
        Assert.AreEqual(1, context.ChangeTracker.Entries().Count());
      }
    }

    

    [TestMethod]
    public void New_TrackGraphFollowsSameRulesAboutNonRootObjectState_AsRepoMethods() {
      using (var context = new SamuraiContext()) {
        var oldSamurai = new Samurai();
        context.Samurais.Attach(oldSamurai);

        //oldSamurai is now known and Unchanged
        var quote = new Quote();
        oldSamurai.Quotes.Add(quote);
        context.ChangeTracker.TrackGraph(quote, e => e.Entry.State = EntityState.Added);
        Assert.AreEqual(EntityState.Unchanged, context.Entry(oldSamurai).State);

        Assert.AreEqual(EntityState.Added, context.Entry(quote).State);
      }
    }

    [TestMethod]
    public void New_TrackGraphMethodAppliesCustomFunctionToAllObjectsInGraph() {
      var samurai = new Samurai { Id = 1 };
      var quote = new Quote();
      samurai.Quotes.Add(quote);
      using (var context = new SamuraiContext()) {
        context.ChangeTracker.TrackGraph(samurai, e => ApplyStateUsingIsKeySet(e.Entry));
        Assert.AreEqual(EntityState.Unchanged, context.Entry(samurai).State);
        Assert.AreEqual(EntityState.Added, context.Entry(quote).State);
      }
    }

    private void ApplyStateUsingIsKeySet(EntityEntry entry) {
      if (entry.IsKeySet) {
        entry.State = EntityState.Unchanged;
      }
      else {
        entry.State = EntityState.Added;
      }
    }
  }
}