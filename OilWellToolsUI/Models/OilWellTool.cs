namespace OilWellToolsUI.Models;
public enum ToolType { OpenHole, CasedHole};
public class OilWellTool
{
    public int Id { get; set; }
    public string AssetType { get; set; } = string.Empty;
    public double Weight { get; set; }
    public double Length { get; set; }
    public double Diameter { get; set; }
    public DateTime ServiceDueDate { get; set; }
    public string Location { get; set; } = string.Empty;
}
