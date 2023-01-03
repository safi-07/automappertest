using AutoMapperWorker.Context;

namespace AutoMapper
{
    public interface ISeedService
    {
        Task Seed();
    }
    public class SeedService : ISeedService
    {
        private readonly ClientContext _db;

        public SeedService(ClientContext db)
        {
            _db = db;
        }


        public async Task Seed()
        {
            try
            {
                var clientId = Guid.NewGuid();
                _db.Add(new Client<Guid>()
                {
                    ClientId = clientId,
                    Name = "Test CLient"
                });
                _db.Add(new Tenant<Guid>()
                {
                    TenantId = Guid.NewGuid(),
                    ClientId = clientId,
                    Name = "Test Tenant"
                });
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }

    }
}
