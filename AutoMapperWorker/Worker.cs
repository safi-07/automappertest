using AutoMapper;
using AutoMapperWorker.Context;
using AutoMapperWorker.ViewModels;
using Microsoft
    .EntityFrameworkCore;

namespace AutoMapperWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetService<ClientContext>();
                    var seedService = scope.ServiceProvider.GetService<ISeedService>();
                    var _mapper = scope.ServiceProvider.GetService<IMapper>();
                    await seedService.Seed();
                    var tenants = await dbContext.Tenants.ToListAsync();
                    var items = _mapper.Map<List<TenantVM<Guid>>>(tenants);
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(100000, stoppingToken);
                }

            }
        }
    }
}