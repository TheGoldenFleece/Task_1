using Microsoft.EntityFrameworkCore;
using Task_1.Model;

namespace Task_1.Models {
    public class ExplorerContext : DbContext {
        public DbSet<Folder> Folders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=data/Explorer.db");
    }
}
