using Prometheus;
using SocialPlatformApp.Business.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDependencies(builder.Configuration);
builder.Services.AddCors(ops =>
{
    ops.AddPolicy("DevCors", opts =>
    {
        opts.AllowAnyHeader();
        opts.AllowAnyMethod();
        opts.AllowCredentials();
        opts.WithOrigins("http://localhost:4200");
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting(); //for the metrics

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapMetrics(); // Exposes metrics at /metrics endpoint
});

app.Run();
