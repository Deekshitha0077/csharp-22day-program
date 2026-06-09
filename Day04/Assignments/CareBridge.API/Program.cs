using CareBridge.EFCoreDemo.Models.Generated;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register EF Core DbContext.
// ASP.NET Core will automatically create and inject it when needed.
builder.Services.AddDbContext<CareBridgeScaffoldContext>();

// Add Swagger support.
// Swagger gives us a testing screen for APIs.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow Vue.js running on another port
// to call this API from the browser.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable Swagger.
app.UseSwagger();
app.UseSwaggerUI();

// Enable CORS.
app.UseCors();

// Simple health-check endpoint.
app.MapGet("/", () =>
{
    return "CareBridge API is running";
});

// Return first 20 patients.
// EF Core converts this LINQ query into SQL.
app.MapGet("/api/patients",
    (CareBridgeScaffoldContext db) =>
    {
        return db.Patients

                 // Select only columns we need.
                 .Select(p => new
                 {
                     p.PatientId,
                     p.FullName,
                     p.City,
                     p.IsActive
                 })

                 // Return only first 20 rows.
                 .Where(p=>p.IsActive)
                 .Where(p => p.City == "Pune")
                 .Take(20)

                 // Execute query.
                 .ToList();
    });

app.MapGet("/api/patients/search",
    (CareBridgeScaffoldContext db) =>
    {
        return db.Patients

                 // Select only columns we need.
                 .Select(p => new
                 {
                     p.PatientId,
                     p.FullName,
                     p.City,
                     p.IsActive
                 })

                 // Return only first 20 rows.
                 .Where(p => p.FullName.Contains("Rao"))
                 .Take(20)
                 

                 // Execute query.
                 .ToList();
    });

app.MapGet("/api/analytics/department-load",
    (CareBridgeScaffoldContext db) =>
    {
        
            return db.Encounters
      .Join(db.Departments,
            e => e.DepartmentId,
            dept => dept.DepartmentId,
            (e, dept) => new { dept.Name, e.EncounterType })
      .GroupBy(x => x.Name)
      .Select(g => new
      {
          DepartmentName = g.Key,
          InpatientCount = g.Count(x => x.EncounterType == "Inpatient"),
          OutpatientCount = g.Count(x => x.EncounterType == "Outpatient"),
          EDCount = g.Count(x => x.EncounterType == "ED"),
          TotalCount = g.Count(x => x.EncounterType == "Inpatient") + g.Count(x => x.EncounterType == "Outpatient")+ g.Count(x => x.EncounterType == "ED"),
      })
      .Take(10)
      .ToList();


    });

app.Run();

