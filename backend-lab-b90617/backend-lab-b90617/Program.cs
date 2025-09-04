var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyectar repositorio
builder.Services.AddScoped<backend_lab_b90617.Repositories.CountryRepository>(sp =>
    new backend_lab_b90617.Repositories.CountryRepository(
        builder.Configuration.GetConnectionString("CountryContext"))
);

// Inyectar servicio
builder.Services.AddScoped<backend_lab_b90617.Services.CountryService>();




var app = builder.Build();

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
