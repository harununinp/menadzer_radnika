using API.Database;
using API.Services.DepartmentService;
using API.Services.ProjectService;
using API.Services.WorkerService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureDatabase(builder.Services, builder.Configuration);
ConfigureServices(builder.Services);
ConfigureApplication(builder);

void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContextPool<DataContext>(options =>
    {
        options.UseMySQL(configuration.GetConnectionString("MySqlDatabase"));
    });
}

static void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Register the IDepartmentService
    services.AddScoped<IDepartmentService, DepartmentService>();
    services.AddScoped<IProjectService, ProjectService>();
    services.AddScoped<IWorkerService, WorkerService>();


}

static void ConfigureApplication(WebApplicationBuilder builder)
{
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
