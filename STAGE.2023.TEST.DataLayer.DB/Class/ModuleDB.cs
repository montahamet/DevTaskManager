using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using STAGE._2023.TEST.Entities;
using STAGE._2023.TEST.DataLayer.DB.Setting;
using Microsoft.VisualBasic;
using System.Reflection;

namespace STAGE._2023.TEST.DataLayer.DB
{
    public class ModuleDB : IModule
    {
        #region Enums 

        private enum enumQryModuleFields
        {
            module_id = 0,
            module_name
           
        }
        #endregion

        public IEnumerable<Entities.Module> GetAll()
        {
            Entities.Modules Ret = new Entities.Modules();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_module_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@module_id", SqlDbType.Int);
                        command.Parameters["@module_id"].Value = -1;

                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.Module()
                            {
                                module_id = (!DR.IsDBNull((int)enumQryModuleFields.module_id))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.module_id])
                                            : 0,

                                module_name = (!DR.IsDBNull((int)enumQryModuleFields.module_name))
                                           ? DR[(int)enumQryModuleFields.module_name].ToString().Trim()
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
        public Entities.Module GetOneByID(int module_id)
        {
            Entities.Module Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_module_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("@module_id", SqlDbType.Int);
                        command.Parameters["@module_id"].Value = module_id;
                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.Module()
                            {
                                module_id = (!DR.IsDBNull((int)enumQryModuleFields.module_id))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.module_id])
                                            : 0,

                                module_name = (!DR.IsDBNull((int)enumQryModuleFields.module_name))
                                           ? DR[(int)enumQryModuleFields.module_name].ToString().Trim()
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

        public Entities.Module GetOneByName(string module_name)
        {
            Entities.Module Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_module_get_one_by_name", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("@module_name", SqlDbType.VarChar);
                        command.Parameters["@module_name"].Value = module_name;
                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.Module()
                            {
                                module_id = (!DR.IsDBNull((int)enumQryModuleFields.module_id))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.module_id])
                                            : 0,

                                module_name = (!DR.IsDBNull((int)enumQryModuleFields.module_name))
                                           ? DR[(int)enumQryModuleFields.module_name].ToString().Trim()
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
        public bool Add(Entities.Module module)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_module_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@module_id", SqlDbType.Int);
                        command.Parameters["module_id"].Value = module.module_id;

                        command.Parameters.Add("@module_name", SqlDbType.VarChar);
                        command.Parameters["@module_name"].Value = module.module_name;

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


        public bool Update(Entities.Module module)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_module_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@module_id", SqlDbType.Int);
                        command.Parameters["module_id"].Value = module.module_id;

                        command.Parameters.Add("@module_name", SqlDbType.VarChar);
                        command.Parameters["@module_name"].Value = module.module_name;

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

        public bool Remove(Entities.Module module)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_module_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@module_id", SqlDbType.Int);
                        command.Parameters["@module_id"].Value = module.module_id;

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
