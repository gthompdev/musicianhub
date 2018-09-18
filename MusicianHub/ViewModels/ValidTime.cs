using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MusicianHub.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)// 'value' is the time property
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), 
                "HH:mm", 
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, 
                out dateTime);

            return (isValid);
        }
    }
}