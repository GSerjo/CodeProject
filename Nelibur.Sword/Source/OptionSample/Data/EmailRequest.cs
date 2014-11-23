using System;

namespace OptionSample.Data
{
    public sealed class EmailRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, FirstName: {1}, LastName: {2}", typeof(EmailRequest).Name, FirstName, LastName);
        }
    }
}
