using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFeedsDomain.Enums;

namespace WebFeedsDomain.Interfaces
{
    public interface IMainPagePropertiesUrl
    {
        MainPageParserType MainPageType { get; }
    }
}
