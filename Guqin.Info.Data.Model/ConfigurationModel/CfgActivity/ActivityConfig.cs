using System;
using System.Linq;

namespace Guqin.Info.Data.Configuration.ConfigurationModel.CfgActivity
{
    public class ActivityConfig
    {
        public String ActivityName { get; set; }
        public Int32 ActivityID { get; set; }

        private ActivityConfig()
        {
        }

        public static ActivityConfig Create(Int32 projectID, Int32 activityID, ConfigurationEntities configurationEntities)
        {
            return configurationEntities
                .activities
                .Where(x => x.idActivities == activityID && x.idProject == projectID)
                .Select(x => new ActivityConfig()
                {
                    ActivityID = x.idActivities,
                    ActivityName = x.name
                })
                .First();
        }
    }
}
