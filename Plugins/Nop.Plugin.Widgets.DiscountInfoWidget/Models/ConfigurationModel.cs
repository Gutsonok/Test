using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.DiscountInfo.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.DiscountInfo.Caption")]
        public string Caption { get; set; }
        public bool Caption_OverrideForStore { get; set; }
    }
}
