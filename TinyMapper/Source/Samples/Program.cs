using System;
using Nelibur.ObjectMapper;
using Samples.Contracts;

namespace Samples
{
    internal class Program
    {
        private static void Main()
        {
        }

private static void MapPerson()
{
    TinyMapper.Bind<Person, PersonDto>();

    var person = new Person
    {
        Id = Guid.NewGuid(),
        FirstName = "John",
        LastName = "Doe",
        Email = "support@tinymapper.net",
        Address = "Wall Street"
    };

    var personDto = TinyMapper.Map<PersonDto>(person);
}
    }
}
