﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LibraryIceTaskCloud.Data;
using LibraryIceTaskCloud.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LibraryIceTaskCloudContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryIceTaskCloudContext") ?? throw new InvalidOperationException("Connection string 'LibraryIceTaskCloudContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
