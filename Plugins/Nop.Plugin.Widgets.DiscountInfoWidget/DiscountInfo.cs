using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Web.Framework.Infrastructure;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.DiscountInfo
{
    public class DiscountInfo : BasePlugin, IWidgetPlugin
    {
        #region Fields

        private readonly IWebHelper _webHelper;
        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public DiscountInfo(IWebHelper webHelper,
            ISettingService settingService)
        {
            this._webHelper = webHelper;
            this._settingService = settingService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { PublicWidgetZones.ProductDetailsTop };
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "WidgetsDiscountInfo";
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/WidgetsDiscountInfo/Configure";
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            base.Uninstall();
        }

        #endregion
    }
}
