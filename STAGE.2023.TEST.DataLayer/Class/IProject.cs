using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.DataLayer
{
    public interface IProject
{
        IEnumerable<Entities.Project> GetAll();

        Entities.Project Getone(int id_project);

        bool Add(Entities.Project project);
        bool Update(Entities.Project project);
        bool Remove(Entities.Project project);
    }
}
