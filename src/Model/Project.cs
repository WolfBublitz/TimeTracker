using System.Drawing;

namespace TimeTracker.Model;

public sealed class Project
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Color? Color { get; set; }
}
