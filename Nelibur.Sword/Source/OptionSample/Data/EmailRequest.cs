using System;

namespace OptionSample.Data
{
    public sealed class EmailRequest
    {
        public string Recipient { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Recipient))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Recipient: {1}", typeof(EmailRequest).Name, Recipient);
        }
    }
}
