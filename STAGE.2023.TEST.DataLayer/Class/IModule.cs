using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.DataLayer
{
    public interface IModule
{
        IEnumerable<Entities.Module> GetAll(int id_project);
        Entities.Module GetOne(string module_name);


        bool Add(Entities.Module module);
        bool Update(Entities.Module module);
        bool Remove(Entities.Module module);
    }
}