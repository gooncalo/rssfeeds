using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFeedsDomain.Interfaces;

namespace WebFeedsDomain.BL.MainPage
{
    public class PublicoMainPageParser
    {
        public PublicoMainPageParser()
        {

        }

        public string GetMainPageString(IMainPagePropertiesUrl mainPageProperties, string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return url;

            string result = string.Empty;

            Type t = mainPageProperties.GetType();
            result = url;
            int index1 = 0, index2 = 0;
            foreach(var prop in t.GetProperties())
            {
                index1 = url.IndexOf("{", index1);
                if (index1 == -1)
                    break;
                index2 = url.IndexOf("}", index1);
                if (index2 == -1)
                    break;
                
                index1++;
                string aux = url.Substring(index1, index2 - index1);
                if(prop.Name == aux)
                {
                   result = result.Replace("{" + aux + "}", (string)prop.GetValue(mainPageProperties));
                }
            }

            return result;
        }
    }
}
