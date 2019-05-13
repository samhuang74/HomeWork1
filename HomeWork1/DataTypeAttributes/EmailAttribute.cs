using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HomeWork1.DataTypeAttributes
{
    public sealed class EmailAttribute : DataTypeAttribute
    {
        const String EmailReg = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        private static Regex _regex = new Regex(EmailReg, RegexOptions.IgnoreCase);

        public EmailAttribute() : base(DataType.EmailAddress)
        {
            ErrorMessage = "Email 格式有誤";
        }

        public override bool IsValid(object value)
        {
            if (value == null) { return true; }
            string valueAsString = value as string; return valueAsString != null && _regex.Match(valueAsString).Length > 0;
        }
    }
}