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
        var category = await service.GetByIdAsync(id);

        if (category is null) return Results.NotFound();

        return Results.Ok(category);
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
        bool deleted = await service.DeleteAsync(id);

        return deleted ? Results.NoContent() : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("DeleteCategory").WithOpenApi();

app.MapGet("/todos", async (IToDoService service) =>
{
    try
    {
        var todos = await service.GetAllAsync();

        return Results.Ok(todos);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("GetAllToDos").WithOpenApi();

app.MapGet("/todos/{id}", async (IToDoService service, int id) =>
{
    try
    {
        var todo = await service.GetByIdAsync(id);

        if (todo is null) return Results.NotFound();

        return Results.Ok(todo);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("GetToDoById").WithOpenApi();

app.MapPost("/todos", async (IToDoService service, ToDoCreateDto dto) =>
{
    try
    {
        var createdToDo = await service.CreateAsync(dto);

        return Results.Created($"/todos/{createdToDo.ToDoId}", createdToDo);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("CreateToDo").WithOpenApi();

app.MapPut("/todos/{id}", async (IToDoService service, int id, ToDoUpdateDto dto) =>
{
    try
    {
        var updatedTodo = await service.UpdateAsync(dto, id);

        return updatedTodo is null ? Results.NotFound() : Results.Ok(updatedTodo);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("UpdateToDo").WithOpenApi();

app.MapDelete("/todos/{id}", async (IToDoService service, int id) =>
{
    try
    {
        bool deleted = await service.DeleteAsync(id);

        return deleted ? Results.NoContent() : Results.NotFound();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
}).WithName("DeleteToDo").WithOpenApi();

app.Run();
