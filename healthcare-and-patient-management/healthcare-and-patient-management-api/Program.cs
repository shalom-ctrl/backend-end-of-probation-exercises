using healthcare_and_patient_management_api.Data;
using healthcare_and_patient_management_api.Interface;
using healthcare_and_patient_management_api.Models;
using healthcare_and_patient_management_api.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("HealthcareDb"));
builder.Services.AddScoped<IHealthcareService, HealthCareService>();

var app = builder.Build();
using(var scope =  app.ApplicationServices.GetRequiredService<ApplicationDbContext>())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<IHealthcareService>;
    if(!dbcontext.Any())
    {
        var doctor1 = new Doctor
        {
            DoctorId = 1,
            Speciality = healthcare_and_patient_management_api.Enums.Speciality.Radiology,
            FirstName = John,
            LastName = Doe,
            DateAdded = DateTime.Now,
        };
       
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
