using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.DiscountInfo.Models;
using Nop.Services.Configuration;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.DiscountInfo.Controllers
{
    [Area(AreaNames.Admin)]
    [AuthorizeAdmin]
    [AdminAntiForgery]
    public class WidgetsDiscountInfoController : BasePluginController
    {
        #region Fields

        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;
        private readonly IPermissionService _permissionService;

        #endregion

        #region Ctor

        public WidgetsDiscountInfoController(IStoreContext storeContext,
            ISettingService settingService,
            IPermissionService permissionService)
        {
            this._storeContext = storeContext;
            this._settingService = settingService;
            this._permissionService = permissionService;
        }

        #endregion

        #region Methods

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var discountInfoSettings = _settingService.LoadSetting<DiscountInfoSettings>(storeScope);

            var model = new ConfigurationModel
            {
                Caption = discountInfoSettings.Caption
            };

            if (storeScope > 0)
            {
                model.Caption_OverrideForStore = _settingService.SettingExists(discountInfoSettings, x => x.Caption, storeScope);
            }

            return View("~/Plugins/Widgets.DiscountInfo/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var discountInfoSettings = _settingService.LoadSetting<DiscountInfoSettings>(storeScope);

            discountInfoSettings.Caption = model.Caption;
            
            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            _settingService.SaveSettingOverridablePerStore(discountInfoSettings, x => x.Caption, model.Caption_OverrideForStore, storeScope, false);
            
            //now clear settings cache
            _settingService.ClearCache();

            SuccessNotification("Admin.Plugins.Saved");

            return Configure();
        }

        #endregion
    }
}
