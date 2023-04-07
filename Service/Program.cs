using AddressBook;
using Microsoft.AspNetCore.Mvc.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<AddressBookDbContext>(opts => opts.UseSqlite(builder.Configuration.GetConnectionString("Database")))
    .AddScoped<IContactsService, ContactsService>()
    .AddRestApi();

var dieCreateContainer = MrContainer.DIE_CreateContainer(builder);

builder.Services.AddSingleton<IControllerActivator>(_ => dieCreateContainer.CreateActivator());

var app = builder.Build();
app.UseRestApi();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<AddressBookDbContext>())
    context.Database.EnsureCreated();

app.Run();
