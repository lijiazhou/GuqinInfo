using System;
using System.Collections.Generic;
using System.Linq;

namespace Guqin.Info.Data.Configuration.ConfigurationModel.CfgMenuModel
{
    public sealed class MenuConfig : List<MenuItem>
    {
        private MenuConfig() : base()
        {
        }

        public static MenuConfig Create(Int32 projectID, ConfigurationEntities ConfigurationEntities)
        {
            
            return Create(ConfigurationEntities
                .projects
                .Where(x => x.idProject == projectID)
                .First()
                .menus);
        }

        private static MenuConfig Create(IEnumerable<menu> menus, Boolean isSub = false)
        {
            MenuConfig menuConfig = null;
            if ( menus != null && menus.Count() > 0)
            {
                var items = menus.Where(x=>x.submenu.HasValue == isSub).Select(
                    x => new MenuItem
                    {
                        Action = x.actionName,
                        Class = x.@class,
                        Controller = x.controllerName,
                        Name = x.menuName,
                        Order = x.itemOrder,
                        SubMenu = Create(menus.Where(y => y.idMenu == x.submenu && x.submenu.HasValue), true)
                    });

                menuConfig = new MenuConfig();
                menuConfig.AddRange(items.OrderBy(x=>x.Order));
            }

            return menuConfig;
        }
    }
}
