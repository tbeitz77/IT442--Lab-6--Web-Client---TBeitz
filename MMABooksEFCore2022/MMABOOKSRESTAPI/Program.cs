using MMABooksEFClasses.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add Cors Policy - In a Production APP lock this Down!
builder.Services.AddCors(options => { 
    options.AddDefaultPolicy(
        builder => {
            builder.AllowAnyOrigin()
            .WithMethods("POST", "PUT", "DELETE", "GET", "OPTIONS")
            .AllowAnyHeader();
        });
    
});
//Adding the DBContext to service
builder.Services.AddDbContext<MMABooksContext>();

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

//In a production APP you would want to turn this BACK ON!
//app.UseHttpsRedirection();

//Enablbes the CORS Policy
app.UseCors();


app.UseAuthorization();

app.MapControllers();

app.Run();
