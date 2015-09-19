using System;
using System.Collections.Generic;
using Nelibur.ObjectMapper;
using Samples.Contracts;
using Samples.Contracts.Sources;
using Samples.Contracts.Targets;

namespace Samples
{
    internal class Program
    {
        private static void Main()
        {
            MapPerson();
            MapPersonComplex();
            MapPersonCustom();

            Measurements.Mesuare();

            Console.ReadKey();
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
                Address = "Wall Street",
                CreateTime = DateTime.Now,
                Nickname = "Object Mapper",
                Phone = "Call Me Maybe"
            };

            var personDto = TinyMapper.Map<PersonDto>(person);
        }

        private static void MapPersonComplex()
        {
            TinyMapper.Bind<PersonComplex, PersonDtoComplex>(config =>
            {
                config.Ignore(source => source.CreateTime);
                config.Ignore(source => source.Nickname);
                config.Bind(source => source.LastName, target => target.Surname);
                config.Bind(target => target.Emails, typeof(List<string>));
            });

            var person = new PersonComplex
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Address = new Address
                {
                    Phone = "Call Me Maybe",
                    Street = "Wall Street",
                    ZipCode = "101000"
                },
                CreateTime = DateTime.Now,
                Nickname = "Object Mapper",
                Emails = new List<string>
                {
                    "help@tinymapper.net",
                    "john@tinymapper.net"
                }
            };

            var personDto = TinyMapper.Map<PersonDtoComplex>(person);
        }

        private static void MapPersonCustom()
        {
            TinyMapper.Bind<PersonCustom, PersonDtoCustom>();
            var source = new PersonCustom
            {
                FirstName = "John",
                LastName = "Doe",
                Emails = new List<string> { "home@tinymapper.com", "work@nelibur.com" }
            };

            var result = TinyMapper.Map<PersonDtoCustom>(source);
        }
    }
}
