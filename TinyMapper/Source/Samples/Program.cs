using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Nelibur.ObjectMapper;
using Samples.Contracts;

namespace Samples
{
    internal class Program
    {
        private const int Iterations = 1000000;

        private static Person CreatePerson()
        {
            return new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "support@tinymapper.net",
                Address = "Wall Street",
                CreateTime = DateTime.Now,
                Nickname = "Object Mapper",
                Phone = "Call Me Maybe "
            };
        }

        private static void Main()
        {
            MapPerson();

            MapPersonComplex();

            MapPersonCustom();

            MeasureHandwritten();
            MeasureTinyMapper();
            MeasureAutoMapper();

            Console.ReadKey();
        }

        private static void MapPersonCustom()
        {
            throw new NotImplementedException();
        }

        private static PersonDto MapHandwritten(Person person)
        {
            var result = new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Address = person.Address,
                CreateTime = person.CreateTime,
                Nickname = person.Nickname,
                Phone = person.Phone
            };
            return result;
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
                config.Ignore(x => x.CreateTime);
                config.Ignore(x => x.Nickname);
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

        private static void MeasureAutoMapper()
        {
            Person person = CreatePerson();
            Mapper.CreateMap<Person, PersonDto>();

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Iterations; i++)
            {
                var personDto = Mapper.Map<PersonDto>(person);
            }
            stopwatch.Stop();
            Console.WriteLine("AutoMapper: {0}ms", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void MeasureHandwritten()
        {
            Person person = CreatePerson();

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Iterations; i++)
            {
                PersonDto personDto = MapHandwritten(person);
            }
            stopwatch.Stop();
            Console.WriteLine("Handwritten: {0}ms", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void MeasureTinyMapper()
        {
            Person person = CreatePerson();
            TinyMapper.Bind<Person, PersonDto>();

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Iterations; i++)
            {
                var personDto = TinyMapper.Map<PersonDto>(person);
            }

            stopwatch.Stop();
            Console.WriteLine("TinyMapper: {0}ms", stopwatch.Elapsed.TotalMilliseconds);
        }
    }
}
