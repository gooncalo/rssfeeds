using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFeedsDomain.Interfaces;

namespace WebFeedsDomain.BL.MainPage
{
    public class PublicoMainPage : IMainPagePropertiesUrl
    {
        public string DateSepartedBySlash { get; set; }
        public string DateNoSeparator { get; set; }

        public PublicoMainPage(DateTime dateTime)
        {
            DateNoSeparator = string.Format("{0}{1:00}{2:00}", dateTime.Year, dateTime.Month, dateTime.Day);
            DateSepartedBySlash = string.Format("{0}/{1:00}/{2:00}", dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public Enums.MainPageParserType MainPageType
        {
            get
            {
                return Enums.MainPageParserType.DateTimeParser;
            }            
        }
    }
}
