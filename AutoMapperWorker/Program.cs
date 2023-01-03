using AutoMapper;
using AutoMapperWorker;
using AutoMapperWorker.Context;
using AutoMapperWorker.Mapper;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddDbContext<ClientContext>
        (o => o.UseInMemoryDatabase("MyDatabase"));
        services.AddAutoMapper(typeof(Mapping));
        services.AddScoped(typeof(ISeedService), typeof(SeedService));
    })
    .Build();

host.Run();
