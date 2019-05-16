using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HomeWork1.DataTypeAttributes
{
    public sealed class MobilePhoneAttribute : DataTypeAttribute
    {
        const String MobilePhoneReg = @"\d{4}-\d{6}";

        private static Regex _regex = new Regex(MobilePhoneReg, RegexOptions.IgnoreCase);

        public MobilePhoneAttribute() : base(DataType.PhoneNumber)
        {
            ErrorMessage = "Phone 格式有誤 d4-d6 ";
        }

        public override bool IsValid(object value)
        {
            if (value == null) { return true; }
            string valueAsString = value as string; return valueAsString != null && _regex.Match(valueAsString).Length > 0;
        }
    }
}