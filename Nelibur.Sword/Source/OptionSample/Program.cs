using System;
using Nelibur.Sword.DataStructures;
using Nelibur.Sword.Extensions;
using OptionSample.Data;
using OptionSample.Data.Emails;

namespace OptionSample
{
    internal class Program
    {
        private static bool CustomEmailRequestValidation(EmailRequest request)
        {
            return true;
        }

        private static void DoSample()
        {
            GetEmailRequest()
                .ToOption()
                .Where(x => x.IsValid())
                .Where(x => CustomEmailRequestValidation(x))
                .Do(x => Console.WriteLine(x));
        }

        private static EmailRequest GetEmailRequest()
        {
            return new EmailRequest { FirstName = "John", LastName = "Doe" };
        }

        private static void Main()
        {
            WhereSample();
            DoSample();

            MapSample();
            MapOnEmptySample();

            MatchSample();
            MatchTypeSample();

            Console.ReadKey();
        }

        private static void MapOnEmptySample()
        {
            ((EmailRequest)null)
                .ToOption()
                .DoOnEmpty(() => Console.WriteLine("Empty"))
                .MapOnEmpty(() => GetEmailRequest())
                .Map(x => Email.From(x))
                .Do(x => Console.WriteLine(x));
        }

        private static void MapSample()
        {
            GetEmailRequest()
                .ToOption()
                .Where(x => x.IsValid())
                .Where(x => CustomEmailRequestValidation(x))
                .Map(x => Email.From(x))
                .Do(x => Console.WriteLine(x));
        }

        private static void MatchSample()
        {
            GetEmailRequest()
                .ToOption()
                .Where(x => x.IsValid())
                .Where(x => CustomEmailRequestValidation(x))
                .Map(x => Email.From(x))
                .Match(x => x.FirstName == "John", x => Console.WriteLine("Hello {0}", x.FirstName))
                .Match(x => x.LastName == "Doe", x => Console.WriteLine("Hello {0}", x.LastName))
                .Do(x => Console.WriteLine(x));
        }

        private static void MatchTypeSample()
        {
            GetEmailRequest()
                .ToOption()
                .Where(x => x.IsValid())
                .Where(x => CustomEmailRequestValidation(x))
                .Map(x => Email.From(x))
                .MatchType<HappyEmail>(x => Console.WriteLine("Happy"))
                .Do(x => Console.WriteLine(x));
        }

        private static void WhereSample()
        {
            Option<EmailRequest> request = GetEmailRequest()
                .ToOption()
                .Where(x => x.IsValid())
                .Where(x => CustomEmailRequestValidation(x));
            if (request.HasValue)
            {
                Console.WriteLine(request.Value);
            }
        }
    }
}
