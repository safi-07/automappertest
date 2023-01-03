using Microsoft.EntityFrameworkCore;

namespace AutoMapperWorker.Context
{
    public class ClientContext : ClientDbContext<Guid, Guid>
    {
        public ClientContext(DbContextOptions options) : base(options)
        {
        }
    }
}
