using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.DiscountInfo.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.DiscountInfo.Components
{
    [ViewComponent(Name = "WidgetsDiscountInfo")]
    public class WidgetsDiscountInfoViewComponent : NopViewComponent
    {
        #region Fields

        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        #endregion

        #region ctor

        public WidgetsDiscountInfoViewComponent(IStoreContext storeContext,
            ISettingService settingService)
        {
            this._storeContext = storeContext;
            this._settingService = settingService;
        }

        #endregion

        #region Methods

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var discountInfoSettings = _settingService.LoadSetting<DiscountInfoSettings>(_storeContext.CurrentStore.Id);

            var model = new PublicInfoModel
            {
                Caption = discountInfoSettings.Caption
            };

            return View("~/Plugins/Widgets.DiscountInfo/Views/PublicInfo.cshtml", model);
        }

        #endregion
    }
}
