using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;

namespace TAC.Utils.Search
{
    public class UrlComputedField:AbstractComputedIndexField
    {
        public override object ComputeFieldValue(IIndexable indexable)
        {
            Item item = indexable as SitecoreIndexableItem;
            if (item == null)
            {
                return null;
            }
            UrlOptions defaultUrlOptions = LinkManager.GetDefaultUrlOptions();
            defaultUrlOptions.SiteResolving = true;

            var calculateUrl = LinkManager.GetItemUrl(item, defaultUrlOptions);
            return calculateUrl;
        }
    }
}
