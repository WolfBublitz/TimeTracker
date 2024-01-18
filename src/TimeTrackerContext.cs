using System;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Model;

namespace TimeTracker;

public sealed class TimeTrackerContext : DbContext
{
    public string DatabasePath { get; }

    public DbSet<Project> Projects { get; set; }

    public TimeTrackerContext()
    {
        string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        DatabasePath = System.IO.Path.Join(appDataDirectory, "TimeTracker", "TimeTracker.db");
    }

    protected sealed override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DatabasePath}");
}