using STAGE._2023.TEST.DataLayer.DB.Setting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STAGE._2023.TEST.Entities;

namespace STAGE._2023.TEST.DataLayer.DB
{
    public class UserRoleDB : IUserRole
    {
        private enum enumQryUserRoleFields
        {
            role_id = 0,
            role_code,
            role_name
        }
        public IEnumerable<UserRole> GetAll()
        {
            Entities.UserRoles Ret = new Entities.UserRoles();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_role_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.UserRole()
                            {
                                Id = (!DR.IsDBNull((int)enumQryUserRoleFields.role_id))
                                         ? Convert.ToInt32(DR[(int)enumQryUserRoleFields.role_id])
                                         : 0,
                                Code = (!DR.IsDBNull((int)enumQryUserRoleFields.role_code))
                                           ? DR[(int)enumQryUserRoleFields.role_code].ToString().Trim()
                                           : string.Empty,
                                Name = (!DR.IsDBNull((int)enumQryUserRoleFields.role_name))
                                           ? DR[(int)enumQryUserRoleFields.role_name].ToString().Trim()
                                           : string.Empty,
                            });
                        }
                    }
                }

                return Ret;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
            finally
            {
                if (DR != null)
                {
                    DR.Close();
                    DR = null;
                }
            }
        }
        public UserRole GetOne(int userRoleId)
        {
            Entities.UserRole Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_role_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@userRoleId", SqlDbType.Int);
                        command.Parameters["@userRoleId"].Value = userRoleId;

                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.UserRole()
                            {
                                Id = (!DR.IsDBNull((int)enumQryUserRoleFields.role_id))
                                         ? Convert.ToInt32(DR[(int)enumQryUserRoleFields.role_id])
                                         : 0,
                                Code = (!DR.IsDBNull((int)enumQryUserRoleFields.role_code))
                                           ? DR[(int)enumQryUserRoleFields.role_code].ToString()
                                           : string.Empty,
                                Name = (!DR.IsDBNull((int)enumQryUserRoleFields.role_name))
                                           ? DR[(int)enumQryUserRoleFields.role_name].ToString()
                                           : string.Empty,
                            };
                        }
                    }
                }

                return Ret;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
            finally
            {
                if (DR != null)
                {
                    DR.Close();
                    DR = null;
                }
            }
        }
    }
}
