using System;

namespace Guqin.Info.Data.Configuration.ConfigurationModel.CfgMenuModel
{
    public sealed class MenuItem
    {
        public String Name { get; set; }
        public String Action { get; set; }
        public String Controller { get; set; }
        public Int32 Order { get; set; }
        public String Class { get; set; }
        public MenuConfig SubMenu { get; set; }

    }
}
