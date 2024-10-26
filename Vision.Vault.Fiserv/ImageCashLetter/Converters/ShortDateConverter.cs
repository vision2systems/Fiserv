using FluentFiles.Core.Conversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Vision.Vault.Fiserv.ImageCashLetter.Converters
{
   
    public class ShortDateConverter : IFieldValueConverter
        {
            private const string DateFormat = "yyMMdd"; // Ensure 'HH' is for 24-hour format

            public bool CanFormat(Type from)
            {
                return (from == typeof(string);
            }

            public bool CanParse(Type to)
            {
                return (to == typeof(DateTime) || to == typeof(DateTime?));
            }

            public object Convert(string value)
            {
                if (String.IsNullOrEmpty(value)) return default(DateTime?);

                if (DateTime.TryParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }

                throw new FormatException($"The value '{value}' is not in the expected format '{DateFormat}'.");
            }

            public string ConvertBack(object value)
            {
                if (value is DateTime dateTime)
                {
                    return dateTime.ToString(DateFormat);
                }
                throw new InvalidCastException("Value is not a DateTime.");
            }

            public string Format(in FieldFormattingContext context)
            {
                return ConvertBack(context.Source);
            }

            public object Parse(in FieldParsingContext context)
            {
                throw new NotImplementedException();
            }
        }
    
}
