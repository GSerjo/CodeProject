using System;
using System.Collections.Generic;
using Nelibur.Sword.DataStructures;
using Nelibur.Sword.Extensions;
using OptionSample.Data;
using OptionSample.Data.Emails;

namespace OptionSample
{
    internal class Program
    {
        private static void DoSample()
        {
            GetEmailRequest()
                .ToOption()
                .Do(x => ExecuteAction(x));
        }

        private static void DoWithWhereSample()
        {
            GetEmailRequest()
                .ToOption()
                .Where(x => x.IsValid())
                .Do(x => ExecuteAction(x));
        }

        private static void ExecuteAction(EmailRequest request)
        {
            Console.WriteLine("EmailRequest for {0}", request.Recipient);
        }

        private static void ExecuteAction(Email email)
        {
            Console.WriteLine("Email for {0}", email.Recipient);
        }

        private static void ExecuteLuckyAction(Email email)
        {
            Console.WriteLine("Email for lucky {0}", email.Recipient);
        }

        private static EmailRequest GetEmailRequest()
        {
            return new EmailRequest { Recipient = "John Doe" };
        }

        private static bool IsLuckyRecipient(string recipient)
        {
            return string.Equals(recipient, "John Doy", StringComparison.OrdinalIgnoreCase);
        }

        private static void Main()
        {
            var samples = new List<Action>
            {
                WhereSample,
                DoSample,
                WhereSample,
                DoWithWhereSample,
                MapSample,
                MapOnEmptySample,
                MatchSample,
                MatchTypeSample,
            };

            samples.Iter(action =>
            {
                Console.WriteLine(action.Method.Name);
                action();
                Console.WriteLine(Environment.NewLine);
            });
            Console.ReadKey();
        }

        private static void MapOnEmptySample()
        {
            Option<EmailRequest>.Empty
                                .DoOnEmpty(() => Console.WriteLine("Empty"))
                                .MapOnEmpty(() => GetEmailRequest())
                                .Do(x => ExecuteAction(x));
        }

        private static void MapSample()
        {
            GetEmailRequest()
                .ToOption()
                .Where(x => x.IsValid())
                .Map(x => Email.From(x))
                .Do(x => ExecuteAction(x));
        }

        private static void MatchSample()
        {
            GetEmailRequest()
                .ToOption()
                .Where(x => x.IsValid())
                .Map(x => Email.From(x))
                .Match(x => IsLuckyRecipient(x.Recipient), x => ExecuteLuckyAction(x))
                .Do(x => ExecuteAction(x));
        }

        private static void MatchTypeSample()
        {
            GetEmailRequest()
                .ToOption()
                .Where(x => x.IsValid())
                .Map(x => Email.From(x))
                .MatchType<HappyEmail>(x => Console.WriteLine("Happy"))
                .MatchType<QuickEmail>(x => Console.WriteLine("Quick"))
                .Do(x => Console.WriteLine(x));
        }

        private static void WhereSample()
        {
            Option<EmailRequest> request = GetEmailRequest()
                .ToOption()
                .Where(x => x.IsValid());
            if (request.HasValue)
            {
                Console.WriteLine(request.Value);
            }
        }
    }
}
