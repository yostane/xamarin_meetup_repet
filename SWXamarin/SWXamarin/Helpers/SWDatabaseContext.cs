using System;
using Microsoft.EntityFrameworkCore;
using SharpTrooper.Entities;
using Xamarin.Forms;
using System.IO;
namespace SWXamarin.Helpers
{
    public class SWDatabaseContext : DbContext
    {
        public DbSet<People> People { get; set; }

        private const string databaseName = "database.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var databasePath = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName); ;
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            optionsBuilder.UseSqlite("database.db");
        }
    }
}
