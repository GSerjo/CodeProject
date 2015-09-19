using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using Nelibur.ObjectMapper;
using Samples.Contracts;
using Samples.Contracts.Sources;
using Samples.Contracts.Targets;

namespace Samples
{
    internal class Program
    {
        private const int Iterations = 1000000;

        private static PersonSource CreatePerson()
        {
            return new PersonSource
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
            TinyMapperMapPerson();
            TinyMapperMapPersonComplex();
            TinyMapperMapPersonCustom();

            MeasureHandwritten();
            MeasureTinyMapper();
            MeasureAutoMapper();

            Console.ReadKey();
        }

        private static PersonTarget MapHandwritten(PersonSource person)
        {
            var result = new PersonTarget
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

        private static void MeasureAutoMapper()
        {
            PersonSource person = CreatePerson();
            Mapper.CreateMap<PersonSource, PersonTarget>();

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Iterations; i++)
            {
                var personDto = Mapper.Map<PersonTarget>(person);
            }
            stopwatch.Stop();
            Console.WriteLine("AutoMapper: {0}ms", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void MeasureHandwritten()
        {
            PersonSource person = CreatePerson();

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Iterations; i++)
            {
                PersonTarget personDto = MapHandwritten(person);
            }
            stopwatch.Stop();
            Console.WriteLine("Handwritten: {0}ms", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void MeasureTinyMapper()
        {
            PersonSource person = CreatePerson();
            TinyMapper.Bind<PersonSource, PersonTarget>();

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Iterations; i++)
            {
                var personDto = TinyMapper.Map<PersonTarget>(person);
            }

            stopwatch.Stop();
            Console.WriteLine("TinyMapper: {0}ms", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void TinyMapperMapPerson()
        {
            TinyMapper.Bind<PersonSource, PersonTarget>();

            var person = new PersonSource
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

            var personDto = TinyMapper.Map<PersonTarget>(person);
        }

        private static void TinyMapperMapPersonComplex()
        {
            TinyMapper.Bind<PersonSourceComplex, PersonTargetComplex>(config =>
            {
                config.Ignore(source => source.CreateTime);
                config.Ignore(source => source.Nickname);
                config.Bind(source => source.LastName, target => target.Surname);
                config.Bind(target => target.Emails, typeof(List<string>));
            });

            var person = new PersonSourceComplex
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

            var personDto = TinyMapper.Map<PersonTargetComplex>(person);
        }

        private static void TinyMapperMapPersonCustom()
        {
            TinyMapper.Bind<PersonSourceCustom, PersonTargetCustom>();
            var source = new PersonSourceCustom
            {
                FirstName = "John",
                LastName = "Doe",
                Emails = new List<string> { "home@tinymapper.com", "work@nelibur.com" }
            };

            var result = TinyMapper.Map<PersonTargetCustom>(source);
        }
    }
}
