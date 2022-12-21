using System.Text.Json.Serialization;
using api.Data;
using api.Extensions;
using api.Helpers;
using core.Interfaces;
using infrastructure.Database.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDataBaseServices(builder.Configuration);
builder.Services.AddCloudServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerService();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
               options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
            });


builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try{
    var unitOfWork = services.GetRequiredService<IUnitOfWork>();
    
    await Seed.SeedProjects(unitOfWork);
    await Seed.SeedProposal(unitOfWork);
    await Seed.SeedAgencies(unitOfWork);
    await Seed.SeedConstraints(unitOfWork);
}
catch(Exception ex)
{

}
app.Run();
