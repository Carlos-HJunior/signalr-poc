using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using signalr_poc.Controllers;
using signalr_poc.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add signalr to application
builder.Services.AddSignalR();

// database
var connectionString = builder.Configuration.GetConnectionString("mssql");
builder.Services.AddDbContext<PocDbContext>(opt => opt.UseSqlServer(connectionString!));

builder.Services.Configure<JsonOptions>(o =>
{
    o.SerializerOptions.WriteIndented = true;
});

var app = builder.Build();
app.MapHub<SimpleHub>("/simple");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    var factory = app.Services.GetService<IServiceScopeFactory>();
    using var scope = factory!.CreateScope();
    var context = scope.ServiceProvider.GetService<PocDbContext>();

    context!.Database.Migrate();
    context.SaveChanges();
    
    DbSeedData.Seed(context);
    context.SaveChanges();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();