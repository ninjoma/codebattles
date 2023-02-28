using Microsoft.EntityFrameworkCore;

namespace codebattle_api
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
    }
}
