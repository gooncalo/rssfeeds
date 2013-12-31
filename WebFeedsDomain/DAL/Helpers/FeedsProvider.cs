using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFeedsDomain.BL.MainPage;
using WebFeedsDomain.Enums;
using WebFeedsDomain.Interfaces;

namespace WebFeedsDomain.DAL
{
    public partial class FeedsProvider
    {
        public Domain.FeedsProvider ToFeedsProvider()
        {
            Domain.FeedsProvider result = new Domain.FeedsProvider()
            {
                ID = this.Id,
                Name = this.Name,
                Type = (Enums.FeedType)this.FeedsType,
                Url = this.Url
            };

            if(this.ProviderMainPages != null)
            {
                int dayOfWeek = (int)DateTime.Now.DayOfWeek + 1;
                var image = this.ProviderMainPages.FirstOrDefault(i => i.FeedsProviderID == this.Id && i.WeekDay == dayOfWeek);
                if (image != null)
                {
                    if (image.MainPageParserType.HasValue)
                    {
                        IMainPagePropertiesUrl properties = null;
                        if(((MainPageParserType)image.MainPageParserType.Value) == MainPageParserType.DateTimeParser)
                        {
                            properties = new PublicoMainPage(DateTime.Now);
                        }
                        
                        PublicoMainPageParser parser = new PublicoMainPageParser();
                        result.MainPageImgUrl = parser.GetMainPageString(properties, image.ImageUrl);
                    }
                    else
                    {
                        result.MainPageImgUrl = image.ImageUrl;
                    }
                
                }
            }

            return result;
        }
    }
}
