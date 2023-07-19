using API._Services.Interfaces;
using API._Services.Services;
using API.Extentions;
using API.hub;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddCors();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IWordServices, WordServices>();

//in-memory cache
builder.Services.AddMemoryCache();
builder.Services.AddSignalR();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AutoMapperDI();
builder.Services.AuthenticationDI(configuration);
builder.Services.RepositoryDI();
builder.Services.ServicesDI();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.SwaggerDI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseRouting();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.MapHub<SignalRHub>("/hub");

app.Run();
