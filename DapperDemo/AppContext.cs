using Microsoft.EntityFrameworkCore;

namespace DapperDemo
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
    }
}
