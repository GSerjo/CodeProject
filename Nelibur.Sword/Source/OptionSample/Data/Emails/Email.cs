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
            return new HappyEmail(request);
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, FirstName: {1}", typeof(Email).Name, Recipient);
        }
    }
}
