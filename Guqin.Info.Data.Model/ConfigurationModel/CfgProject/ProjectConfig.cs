using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

	

	
namespace Guqin.Info.Data.Configuration.ConfigurationModel.CfgProject
{
    public sealed class ProjectConfig
    {
        public String ProjectName { private set; get; }

        public Int32 ProjectID { private set; get; }

        private ProjectConfig()
        {
        }

        public static ProjectConfig Create(Int32 projectID, ConfigurationEntities configurationEntities)
        {
            return configurationEntities
                .projects
                .Where(x => x.idProject == projectID)
                .Select(x => new ProjectConfig()
                {
                    ProjectID = x.idProject,
                    ProjectName = x.projectName
                }).First();
        }
    }
}
