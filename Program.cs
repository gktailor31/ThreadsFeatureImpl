using Microsoft.EntityFrameworkCore;
using ThreadsFeature.Data;
using ThreadsFeature.IRepository;
using ThreadsFeature.IServices;
using ThreadsFeature.Repository;
using ThreadsFeature.Services;
using ThreadsFeature.utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ThreadsFeatureDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});


builder.Services.AddScoped<UserService, UserServiceImpl>();
builder.Services.AddScoped<ThreadService, ThreadServicesImpl>();
builder.Services.AddScoped<UserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<CommentRepository, CommentRepositoryImpl>();
builder.Services.AddScoped<LikeRepository, LikeRepositoryImpl>();
builder.Services.AddScoped<HelperService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
