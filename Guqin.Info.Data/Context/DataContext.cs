using Guqin.Info.Data.Configuration;
using Guqin.Info.Data.Production;

namespace Guqin.Info.Data.Context
{
    public class DataContext
    {
        private ProductionEntities _productionEntities;

        private ConfigurationEntities _configurationEntities;

        public ProductionEntities ProductionEntities { get { return _productionEntities; } }

        public ConfigurationEntities ConfigurationEntities { get { return _configurationEntities; } }

        public DataContext()
        {
            _configurationEntities = new ConfigurationEntities();
            _productionEntities = new ProductionEntities();        
        }
    }
}
