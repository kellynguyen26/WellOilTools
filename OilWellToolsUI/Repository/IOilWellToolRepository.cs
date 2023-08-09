using OilWellToolsUI.Models;

namespace OilWellToolsUI.Repository;

public interface IOilWellToolRepository
{
    IEnumerable<OilWellTool> GetTools();
    OilWellTool? GetToolByID (int id);
    void InsertTool(OilWellTool tool);
    void DeleteTool(int id);
    void UpdateTool(OilWellTool tool);
    void Save();
}
