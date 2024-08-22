using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using MinimalShoppingListApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase("ShoppingListApi"));

var app = builder.Build();

app.MapGet("/shoppinglist", async (ApiDbContext db) => await db.Groceries.ToListAsync());

app.MapGet("/shoppinglist/{id}", async (int id, ApiDbContext db) =>
{
    var grocery = await db.Groceries.FindAsync(id);

    return grocery != null ? Results.Ok(grocery) : Results.NotFound();
});

app.MapPost("/shoppinglist", async (Grocery grocery, ApiDbContext db) =>
{
    db.Groceries.Add(grocery);

    await db.SaveChangesAsync();

    return Results.Created($"/shoppinglist/{grocery.Id}", grocery);
});

app.MapDelete("/shoppinglist/{id}", async (int id, ApiDbContext db) =>
{
    var grocery = await db.Groceries.FindAsync(id);

    if(grocery != null)
    {
        db.Groceries.Remove(grocery);

        await db.SaveChangesAsync();

        return Results.NoContent();
    }

    return Results.NotFound();
});

app.MapPut("/shoppinglist/{id}", async (int id, Grocery grocery, ApiDbContext db) =>
{
    var groceryInDb = await db.Groceries.FindAsync(id);

    if (groceryInDb != null)
    {
        groceryInDb.Name = grocery.Name;
        groceryInDb.Purchased = grocery.Purchased;

        await db.SaveChangesAsync();

        return Results.Ok(groceryInDb);
    }

    return Results.NotFound();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();