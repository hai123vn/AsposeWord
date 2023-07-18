using API._Interface;
using API._Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IWordServices, WordServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
