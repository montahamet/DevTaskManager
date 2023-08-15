using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.DataLayer
{
    public interface IDevTask
{
        IEnumerable<Entities.DevTask> GetAll(int dev_task_id);
        Entities.DevTask GetOneByID(int dev_task_id);
        Entities.DevTask GetOneByProjectName(string project_name);


        bool Add(Entities.DevTask devTask);
        bool Update(Entities.DevTask devTask);
        bool Remove(Entities.DevTask devTask);
    }
}
