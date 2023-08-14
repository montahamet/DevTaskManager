using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
    public class UserRole
    {
        #region Constructors

        public UserRole()
        {

        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        #endregion

        #region Methods   

        public override string ToString()
        {
            try
            {
                return ((this.Name != null) && (this.Name.Trim() != string.Empty))
                       ? this.Name
                       : this.Code;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        #endregion
    }
}
