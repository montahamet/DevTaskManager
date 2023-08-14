using STAGE._2023.TEST.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.DataLayer
{
    public interface IConfig
{
        #region TypeDev

        IEnumerable<Entities.TypeDev> GetAllTypeDevs();
        public TypeDev TypeDevGetOne(int id_TypeDev);

        bool TypeDevAdd(Entities.TypeDev type);
        bool TypeDevUpdate(Entities.TypeDev type);
        bool TypeDevRemove(Entities.TypeDev type);

        #endregion

        #region PriorityDev

        IEnumerable<Entities.PriorityDev> GetAllPriorityDevs();
        public PriorityDev PriorityDevGetOne(int id_PriorityDev);

        bool PriorityDevAdd(Entities.PriorityDev priority);
        bool PriorityDevUpdate(Entities.PriorityDev priority);
        bool PriorityDevRemove(Entities.PriorityDev priority);

        #endregion

        #region StatusDev

        IEnumerable<Entities.StatusDev> GetAllStatusDevs();
        public StatusDev StatusDevGetOne(int id_StatusDev);

        bool StatusDevAdd(Entities.StatusDev status);
        bool StatusDevUpdate(Entities.StatusDev status);
        bool StatusDevRemove(Entities.StatusDev status);

        #endregion

        #region StatusProject

        IEnumerable<StatusProject> GetAllStatusProject();
        public StatusProject StatusProjectGetOne(int id_StatusProject);

        bool StatusProjectAdd(Entities.StatusProject status_p);
        bool StatusProjectUpdate(Entities.StatusProject status_p);
        bool StatusProjectRemove(Entities.StatusProject status_p);

        #endregion
    }
}
