using FluentFiles.Core.Conversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Converters
{
    public class StringWithImpliedDecimalConverter : IFieldValueConverter
    {
        public bool CanFormat(Type from)
        {
            return(from == typeof(decimal));
        }

        public bool CanParse(Type to)
        {
            return (to == typeof(string));  
        }
        public decimal Convert(string value)
        {

            if (string.IsNullOrEmpty(value))
                return 0m;

            var retVal = decimal.Parse(value) / 100;
            return retVal;
            

            
        }

        public string ConvertBack(object value)
        {
            if (value is decimal val)
            {
                return (val * 100).ToString();
            }
            throw new InvalidCastException("Value is not a decimal.");
        }

        public string Format(in FieldFormattingContext context)
        {
            return ConvertBack(context.Source);
        }

        public object Parse(in FieldParsingContext context)
        {
             return Convert(context.Source.ToString());
        }
    }
}
