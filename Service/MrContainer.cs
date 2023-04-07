using MrMeeseeks.DIE.Configuration.Attributes;

namespace AddressBook;

[ImplementationChoice(typeof(ILogger<>), typeof(Logger<>))]
[ImplementationChoice(typeof(ILoggerFactory), typeof(LoggerFactory))]
[ConstructorChoice(typeof(DbContextOptionsBuilder))]
[ConstructorChoice(typeof(LoggerFactory))]
[CreateFunction(typeof(MyCustomControllerActivator), "CreateActivator")]
public partial class MrContainer
{
    private readonly WebApplicationBuilder _builder;
    private MrContainer(WebApplicationBuilder builder)
    {
        _builder = builder;
    }

    private DbContextOptions DIE_Factory_CreateDbContextOptions(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_builder.Configuration.GetConnectionString("Database"));
        return optionsBuilder.Options;
    }
}
