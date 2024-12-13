using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PaymentAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


#region database

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<PaymentDetailDBContext>(options =>
options.UseSqlServer(ConnectionString));

#endregion



#region

builder.Services.AddCors(options=>options.AddPolicy("CustomPolicy",builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

#endregion

builder.Services.AddControllers();
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

app.UseCors("CustomPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
