using CoreAPIBank3170.Models.ContextClasses;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<MyContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

//Cors (Cros Orgins Resource Server)

builder.Services.AddCors(cors =>
{
    cors.AddPolicy("YZL3170CorsPolicy", opt =>
    {
        opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        //opt.WithOrgins("www.metin.com","www.enis.com")
    });
});
 
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
