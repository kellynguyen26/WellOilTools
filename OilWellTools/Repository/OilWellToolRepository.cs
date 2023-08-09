using OilWellToolsMicroservice.DbContexts;
using OilWellToolsMicroservice.Models;

namespace OilWellToolsMicroservice.Repository
{
    public class OilWellToolRepository : IOilWellToolRepository
    {
        private readonly OilWellToolContext _dbContext;

        public OilWellToolRepository(OilWellToolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteTool(int id)
        {
            OilWellTool? tool = _dbContext.Tools.Find(id);
            if (tool != null)
            {
                _dbContext.Tools.Remove(tool);
                Save();
            }
        }

        public OilWellTool? GetToolByID(int id)
        {
            return _dbContext.Tools.Find(id);
        }

        public IEnumerable<OilWellTool> GetTools()
        {
            return _dbContext.Tools.ToList();
        }

        public void InsertTool(OilWellTool tool)
        {
            _dbContext.Tools.Add(tool);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateTool(OilWellTool tool)
        {
            _dbContext.Entry(tool).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
