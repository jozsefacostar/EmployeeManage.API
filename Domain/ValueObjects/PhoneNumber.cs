using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public partial record PhoneNumber
    {
        public const int DefaultLength = 8;
        public const string Pattern = @"^\d{8}$";
        private PhoneNumber(string value) => Value = value;
        public string Value { get; init; }


        public static PhoneNumber? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !PhoneNumberRegex().IsMatch(value) || value.Length != DefaultLength)
                return null;
            return new PhoneNumber(value);
        }

        [GeneratedRegex(Pattern)]
        private static partial Regex PhoneNumberRegex();
    }
}
