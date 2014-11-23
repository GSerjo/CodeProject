using System;

namespace OptionSample.Data.Emails
{
    public abstract class Email
    {
        protected Email(EmailRequest request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public static Email From(EmailRequest request)
        {
            return new HappyEmail(request);
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, FirstName: {1}, LastName: {2}", typeof(Email).Name, FirstName, LastName);
        }
    }
}
