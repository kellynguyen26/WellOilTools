using Microsoft.EntityFrameworkCore;
using OilWellToolsUI.Models;

namespace OilWellToolsUI.DbContexts;

public class OilWellToolContext : DbContext
{
    public DbSet<OilWellTool> Tools { get; set; }

    public OilWellToolContext(DbContextOptions<OilWellToolContext> options) : base(options)
    {
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<OilWellTool>().HasData(
    //        new OilWellTool
    //        {
    //            Id = 4,
    //            AssetType = ToolType.OpenHole.ToString(),
    //            Weight = 10,
    //            Length = 10,
    //            Diameter = 10,
    //            ServiceDueDate = DateTime.UtcNow,
    //            Location = "Houston, TX"
    //        },
    //        new OilWellTool
    //        {
    //            Id = 5,
    //            AssetType = ToolType.CasedHole.ToString(),
    //            Weight = 20,
    //            Length = 20,
    //            Diameter = 20,
    //            ServiceDueDate = DateTime.UtcNow,
    //            Location = "Dallas, TX"
    //        },
    //        new OilWellTool
    //        {
    //            Id = 6,
    //            AssetType = ToolType.OpenHole.ToString(),
    //            Weight = 30,
    //            Length = 30,
    //            Diameter = 30,
    //            ServiceDueDate = DateTime.UtcNow,
    //            Location = "Austin, TX"
    //        }
    //    ); 
    //}
}
