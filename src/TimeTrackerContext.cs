using System;
using System.Drawing;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeTracker.Model;

namespace TimeTracker;

public sealed class TimeTrackerContext : DbContext
{
    public string DatabasePath { get; }

    public DbSet<Project> Projects { get; set; }

    public TimeTrackerContext()
    {
        string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        string databasePath = System.IO.Path.Join(appDataDirectory, "TimeTracker");

        if (!Path.Exists(databasePath))
        {
            Directory.CreateDirectory(databasePath);
        }

        DatabasePath = Path.Join(databasePath, "TimeTracker.db");
    }

    protected sealed override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DatabasePath}");

    protected sealed override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ValueConverter<Color, string> colorConverter = new(
            color => ColorTranslator.ToHtml(color),
            html => ColorTranslator.FromHtml(html)
        );

        modelBuilder.Entity<Project>().Property(p => p.Color).HasConversion(colorConverter);
    }
}
