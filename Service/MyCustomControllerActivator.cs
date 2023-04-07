using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace AddressBook;

public class MyCustomControllerActivator : IControllerActivator
{
    private readonly Func<ContactsController> _contactsControllerFactory;

    public MyCustomControllerActivator(
        Func<ContactsController> contactsControllerFactory)
    {
        _contactsControllerFactory = contactsControllerFactory;
    }

    public object Create(ControllerContext context) => _contactsControllerFactory();

    public void Release(ControllerContext context, object controller)
    {
    }
}
