using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Mapping;
using ToDoApi.Data;
using ToDoApi.Repositories;
using ToDoApi.Services;
using ToDoApi.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure JSON to serialize enums as strings
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Configure SQLite in-memory database
builder.Services.AddDbContext<ToDoDbContext>(options =>
{
    var connectionString = "DataSource=todoapi.db";
    options.UseSqlite(connectionString);
});

// Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

// Services
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


// Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ToDoDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/categories", async (ICategoryService service) =>
{
    try
    {
        var categories = await service.GetAllAsync();

        return Results.Ok(categories);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("GetAllCategories").WithOpenApi();

app.MapGet("/categories/{id}", async (ICategoryService service, int id) =>
{
    try
    {
        var categorie = await service.GetByIdAsync(id);

        if (categorie is null) return Results.NotFound();

        return Results.Ok(categorie);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("GetCategoryById").WithOpenApi();

app.MapPost("/categories", async (ICategoryService service, CategoryCreateDto categoryDto) =>
{
    try
    {
        var createdCategory = await service.CreateAsync(categoryDto);

        return Results.Created($"/categories/{createdCategory.CategoryId}", createdCategory);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("CreateCategory").WithOpenApi();

app.MapPut("/categories/{id}", async (ICategoryService service, int id, CategoryUpdateDto categoryDto) =>
{
    try
    {
        var updatedCategory = await service.UpdateAsync(categoryDto, id);

        return updatedCategory is null ? Results.NotFound() : Results.Ok(updatedCategory);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("UpdateCategory").WithOpenApi();

app.MapDelete("/categories/{id}", async (ICategoryService service, int id) =>
{
    try
    {
        await service.DeleteAsync(id);

        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("DeleteCategory").WithOpenApi();

app.Run();
