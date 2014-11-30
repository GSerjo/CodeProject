using System;

namespace OptionSample.Data.Emails
{
    public abstract class Email
    {
        protected Email(EmailRequest request)
        {
            Recipient = request.Recipient;
        }

        public string Recipient { get; private set; }

        public static Email From(EmailRequest request)
        {
            int randomValue = new Random().Next(1000);
            if (randomValue % 2 == 0)
            {
                return new HappyEmail(request);
            }
            return new QuickEmail(request);
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, FirstName: {1}", typeof(Email).Name, Recipient);
        }
    }
}
