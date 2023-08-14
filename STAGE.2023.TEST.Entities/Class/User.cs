using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Entities
{
   public class User
    {
        #region Constructors

        public User()
        {
            UserRole = new UserRole();
        }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string FullName { get; set; }
        //public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }

        public UserRole UserRole { get; set; }

        

        #endregion

        #region Methods  

        public bool Authenticate(string Login, string Password)
        {
            try
            {
                if ((Login != null) && (Login.Trim() != string.Empty)
                 && (this.Login != null) && (this.Login.Trim() != string.Empty)
                 && (Password != null) && (Password.Trim() != string.Empty)
                 && (this.Password != null) && (this.Password.Trim() != string.Empty))
                {
                    return Login.Trim().ToUpper().Equals(this.Login.Trim().ToUpper()) && Password.Equals(this.Password.Trim());
                }

                return false;
            }
            catch (Exception ex)
            {
                string _StrEX = ex.Message;
                return false;
            }
        }

        //public override string ToString()
        //{
        //    try
        //    {
        //        return string.Concat(this.FirstName, ' ', this.LastName);
        //    }
        //    catch (Exception)
        //    {
        //        return string.Empty;
        //    }
        //}
        public string GetBirthDate(string dateFormat)
        {
            try
            {
                return this.BirthDate.ToString(dateFormat);
            }
            catch (Exception ex)
            {
                string _StrEX = ex.Message;
                return string.Empty;
            }
        }
        public string GetCreationDate(string dateFormat)
        {
            try
            {
                return this.CreationDate.ToString(dateFormat);
            }
            catch (Exception ex)
            {
                string _StrEX = ex.Message;
                return string.Empty;
            }
        }
        #endregion

    }
}
