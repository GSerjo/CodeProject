using System;
using System.Diagnostics;
using AutoMapper;
using Nelibur.ObjectMapper;
using Samples.Contracts.Sources;
using Samples.Contracts.Targets;

namespace Samples
{
    public static class Measurements
    {
        private const int Iterations = 1000000;

        public static void Mesuare()
        {
            MeasureHandwritten();
            MeasureTinyMapper();
            MeasureAutoMapper();
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

        private static void MeasureAutoMapper()
        {
            Person person = Person.Create();
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
            Person person = Person.Create();

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
            Person person = Person.Create();
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
