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
    public class UserDB : IUser
    {
        private enum enumQryUserFields
        {
            user_id = 0,
            role_id,
            role_code,
            role_name,
            user_full_name,

            user_url_image,
            user_login,
            user_password,
            user_email,
            user_phone,
            user_is_active,
            user_birth_date,
            user_creation_date
        }
        public IEnumerable<User> GetAll()
        {
            Entities.Users Ret = new Entities.Users();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.User()
                            {
                                Id = Convert.ToInt32(DR[(int)enumQryUserFields.user_id]),
                                FullName = (!DR.IsDBNull((int)enumQryUserFields.user_full_name))
                                            ? DR[(int)enumQryUserFields.user_full_name].ToString()
                                            : string.Empty,

                                ImageUrl = (!DR.IsDBNull((int)enumQryUserFields.user_url_image))
                                           ? DR[(int)enumQryUserFields.user_url_image].ToString()
                                           : string.Empty,
                                Login = (!DR.IsDBNull((int)enumQryUserFields.user_login))
                                        ? DR[(int)enumQryUserFields.user_login].ToString()
                                        : string.Empty,
                                Password = (!DR.IsDBNull((int)enumQryUserFields.user_password))
                                           ? DR[(int)enumQryUserFields.user_password].ToString()
                                           : string.Empty,
                                Email = (!DR.IsDBNull((int)enumQryUserFields.user_email))
                                        ? DR[(int)enumQryUserFields.user_email].ToString()
                                        : string.Empty,
                                Phone = (!DR.IsDBNull((int)enumQryUserFields.user_phone))
                                        ? DR[(int)enumQryUserFields.user_phone].ToString()
                                        : string.Empty,
                                IsActive = (!DR.IsDBNull((int)enumQryUserFields.user_is_active))
                                           ? Convert.ToBoolean(DR[(int)enumQryUserFields.user_is_active].ToString())
                                           : false,
                                BirthDate = (!DR.IsDBNull((int)enumQryUserFields.user_birth_date))
                                            ? Convert.ToDateTime(DR[(int)enumQryUserFields.user_birth_date].ToString())
                                            : new DateTime(1970, 1, 1),
                                CreationDate = (!DR.IsDBNull((int)enumQryUserFields.user_creation_date))
                                               ? Convert.ToDateTime(DR[(int)enumQryUserFields.user_creation_date].ToString())
                                               : new DateTime(1970, 1, 1),
                                UserRole = new UserRole()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryUserFields.role_id))
                                         ? Convert.ToInt32(DR[(int)enumQryUserFields.role_id])
                                         : 0,
                                    Code = (!DR.IsDBNull((int)enumQryUserFields.role_code))
                                           ? DR[(int)enumQryUserFields.role_code].ToString()
                                           : string.Empty,
                                    Name = (!DR.IsDBNull((int)enumQryUserFields.role_name))
                                           ? DR[(int)enumQryUserFields.role_name].ToString()
                                           : string.Empty,
                                },
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

        public User GetOne(int userId)
        {
            Entities.User Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@userId", SqlDbType.Int);
                        command.Parameters["@userId"].Value = userId;

                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.User()
                            {
                                Id = Convert.ToInt32(DR[(int)enumQryUserFields.user_id]),
                                FullName = (!DR.IsDBNull((int)enumQryUserFields.user_full_name))
                                            ? DR[(int)enumQryUserFields.user_full_name].ToString().Trim()
                                            : string.Empty,

                                ImageUrl = (!DR.IsDBNull((int)enumQryUserFields.user_url_image))
                                           ? DR[(int)enumQryUserFields.user_url_image].ToString().Trim()
                                           : string.Empty,
                                Login = (!DR.IsDBNull((int)enumQryUserFields.user_login))
                                        ? DR[(int)enumQryUserFields.user_login].ToString().Trim()
                                        : string.Empty,
                                Password = (!DR.IsDBNull((int)enumQryUserFields.user_password))
                                           ? DR[(int)enumQryUserFields.user_password].ToString().Trim()
                                           : string.Empty,
                                Email = (!DR.IsDBNull((int)enumQryUserFields.user_email))
                                        ? DR[(int)enumQryUserFields.user_email].ToString().Trim()
                                        : string.Empty,
                                Phone = (!DR.IsDBNull((int)enumQryUserFields.user_phone))
                                        ? DR[(int)enumQryUserFields.user_phone].ToString().Trim()
                                        : string.Empty,
                                IsActive = (!DR.IsDBNull((int)enumQryUserFields.user_is_active))
                                           ? Convert.ToBoolean(DR[(int)enumQryUserFields.user_is_active].ToString().Trim())
                                           : false,
                                BirthDate = (!DR.IsDBNull((int)enumQryUserFields.user_birth_date))
                                            ? Convert.ToDateTime(DR[(int)enumQryUserFields.user_birth_date].ToString().Trim().Trim())
                                            : new DateTime(1970, 1, 1),
                                CreationDate = (!DR.IsDBNull((int)enumQryUserFields.user_creation_date))
                                               ? Convert.ToDateTime(DR[(int)enumQryUserFields.user_creation_date].ToString())
                                               : new DateTime(1970, 1, 1),
                                UserRole = new UserRole()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryUserFields.role_id))
                                         ? Convert.ToInt32(DR[(int)enumQryUserFields.role_id])
                                         : 0,
                                    Code = (!DR.IsDBNull((int)enumQryUserFields.role_code))
                                           ? DR[(int)enumQryUserFields.role_code].ToString().Trim()
                                           : string.Empty,
                                    Name = (!DR.IsDBNull((int)enumQryUserFields.role_name))
                                           ? DR[(int)enumQryUserFields.role_name].ToString().Trim()
                                           : string.Empty,
                                },
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

        public User GetOneByLogin(string userLogin)
        {
            Entities.User Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_get_one_by_login", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@userLogin", SqlDbType.VarChar);
                        command.Parameters["@userLogin"].Value = userLogin;

                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret = new Entities.User()
                            {
                                Id = Convert.ToInt32(DR[(int)enumQryUserFields.user_id]),
                                FullName = (!DR.IsDBNull((int)enumQryUserFields.user_full_name))
                                            ? DR[(int)enumQryUserFields.user_full_name].ToString()
                                            : string.Empty,

                                ImageUrl = (!DR.IsDBNull((int)enumQryUserFields.user_url_image))
                                           ? DR[(int)enumQryUserFields.user_url_image].ToString()
                                           : string.Empty,
                                Login = (!DR.IsDBNull((int)enumQryUserFields.user_login))
                                        ? DR[(int)enumQryUserFields.user_login].ToString()
                                        : string.Empty,
                                Password = (!DR.IsDBNull((int)enumQryUserFields.user_password))
                                           ? DR[(int)enumQryUserFields.user_password].ToString()
                                           : string.Empty,
                                Email = (!DR.IsDBNull((int)enumQryUserFields.user_email))
                                        ? DR[(int)enumQryUserFields.user_email].ToString()
                                        : string.Empty,
                                Phone = (!DR.IsDBNull((int)enumQryUserFields.user_phone))
                                        ? DR[(int)enumQryUserFields.user_phone].ToString()
                                        : string.Empty,
                                IsActive = (!DR.IsDBNull((int)enumQryUserFields.user_is_active))
                                           ? Convert.ToBoolean(DR[(int)enumQryUserFields.user_is_active].ToString())
                                           : false,
                                BirthDate = (!DR.IsDBNull((int)enumQryUserFields.user_birth_date))
                                            ? Convert.ToDateTime(DR[(int)enumQryUserFields.user_birth_date].ToString())
                                            : new DateTime(1970, 1, 1),
                                CreationDate = (!DR.IsDBNull((int)enumQryUserFields.user_creation_date))
                                               ? Convert.ToDateTime(DR[(int)enumQryUserFields.user_creation_date].ToString())
                                               : new DateTime(1970, 1, 1),
                                UserRole = new UserRole()
                                {
                                    Id = (!DR.IsDBNull((int)enumQryUserFields.role_id))
                                         ? Convert.ToInt32(DR[(int)enumQryUserFields.role_id])
                                         : 0,
                                    Code = (!DR.IsDBNull((int)enumQryUserFields.role_code))
                                           ? DR[(int)enumQryUserFields.role_code].ToString()
                                           : string.Empty,
                                    Name = (!DR.IsDBNull((int)enumQryUserFields.role_name))
                                           ? DR[(int)enumQryUserFields.role_name].ToString()
                                           : string.Empty,
                                },
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

        public bool Add(User user)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;



                        command.Parameters.Add("@fullName", SqlDbType.VarChar);
                        command.Parameters["@fullName"].Value = string.IsNullOrEmpty(user.FullName)
                                                                 ? string.Empty
                                                                 : user.FullName;
                        command.Parameters.Add("@urlImage", SqlDbType.VarChar);
                        command.Parameters["@urlImage"].Value = string.IsNullOrEmpty(user.ImageUrl)
                                                                ? string.Empty
                                                                : user.ImageUrl;

                        command.Parameters.Add("@login", SqlDbType.VarChar);
                        command.Parameters["@login"].Value = string.IsNullOrEmpty(user.Login)
                                                             ? string.Empty
                                                             : user.Login;

                        command.Parameters.Add("@password", SqlDbType.VarChar);
                        command.Parameters["@password"].Value = string.IsNullOrEmpty(user.Password)
                                                                ? string.Empty
                                                                : Utils.Crypto.Encrypt(user.Password, Entities.Constant.CONST_CIPHER_PHRASE);

                        command.Parameters.Add("@email", SqlDbType.VarChar);
                        command.Parameters["@email"].Value = string.IsNullOrEmpty(user.Email)
                                                             ? string.Empty
                                                             : user.Email;

                        command.Parameters.Add("@phone", SqlDbType.VarChar);
                        command.Parameters["@phone"].Value = string.IsNullOrEmpty(user.Phone)
                                                                ? string.Empty
                                                                : user.Phone;
                        command.Parameters.Add("@isActive", SqlDbType.Bit);
                        command.Parameters["@isActive"].Value = user.IsActive;

                        command.Parameters.Add("@birthDate", SqlDbType.DateTime);
                        command.Parameters["@birthDate"].Value = (user.BirthDate.Year < 1900)
                                                                 ? new DateTime(1970, 1, 1)
                                                                 : user.BirthDate;

                        command.Parameters.Add("@roleId", SqlDbType.Int);
                        command.Parameters["@roleId"].Value = user.UserRole.Id;

                        conn.Open();
                        Ret = command.ExecuteNonQuery();
                    }
                }

                return Ret > -1;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }

        public bool Update(User user)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@userId", SqlDbType.Int);
                        command.Parameters["@userId"].Value = user.Id;

                        command.Parameters.Add("@roleId", SqlDbType.Int);
                        command.Parameters["@roleId"].Value = user.UserRole.Id;

                        command.Parameters.Add("@fullName", SqlDbType.VarChar);
                        command.Parameters["@fullName"].Value = string.IsNullOrEmpty(user.FullName)
                                                                 ? string.Empty
                                                                 : user.FullName;

                        command.Parameters.Add("@urlImage", SqlDbType.VarChar);
                        command.Parameters["@urlImage"].Value = string.IsNullOrEmpty(user.ImageUrl)
                                                                ? string.Empty
                                                                : user.ImageUrl;

                        command.Parameters.Add("@login", SqlDbType.VarChar);
                        command.Parameters["@login"].Value = string.IsNullOrEmpty(user.Login)
                                                             ? string.Empty
                                                             : user.Login;

                        command.Parameters.Add("@password", SqlDbType.VarChar);
                        command.Parameters["@password"].Value = string.IsNullOrEmpty(user.Password)
                                                                ? string.Empty
                                                                : Utils.Crypto.Encrypt(user.Password, Entities.Constant.CONST_CIPHER_PHRASE);

                        command.Parameters.Add("@email", SqlDbType.VarChar);
                        command.Parameters["@email"].Value = string.IsNullOrEmpty(user.Email)
                                                             ? string.Empty
                                                             : user.Email;

                        command.Parameters.Add("@phone", SqlDbType.VarChar);
                        command.Parameters["@phone"].Value = string.IsNullOrEmpty(user.Phone)
                                                                ? string.Empty
                                                                : user.Phone;
                        command.Parameters.Add("@isActive", SqlDbType.Bit);
                        command.Parameters["@isActive"].Value = user.IsActive;

                        command.Parameters.Add("@birthDate", SqlDbType.DateTime);
                        command.Parameters["@birthDate"].Value = (user.BirthDate.Year < 1900)
                                                                 ? new DateTime(1970, 1, 1)
                                                                 : user.BirthDate;


                        conn.Open();
                        Ret = command.ExecuteNonQuery();
                    }
                }

                return Ret > -1;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }

        public bool Remove(User user)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_user_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@userId", SqlDbType.Int);
                        command.Parameters["@userId"].Value = user.Id;

                        conn.Open();
                        Ret = command.ExecuteNonQuery();
                    }
                }

                return Ret > -1;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                throw;
            }
        }
    }
}
