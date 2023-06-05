using Microsoft.EntityFrameworkCore;
using TecnologyRepair.Shared.Entities;

namespace TecnologyRepair.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ToRepair> ToRepairs { get; set; }
    }
}