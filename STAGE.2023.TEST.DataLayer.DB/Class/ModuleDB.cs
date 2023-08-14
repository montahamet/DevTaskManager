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

namespace STAGE._2023.TEST.DataLayer.DB
{
    public class ModuleDB
{
        #region Enums 

        private enum enumQryModuleFields
        {
            module_name = 0,
            id_project,
            project_name,
            id_TypeDev,
            TypeDev_name,
            module_details,
            posting_date,
            posted_by,
            due_date,
            id_PriorityDev,
            PriorityDev_name,
            id_StatusDev,
            StatusDev_name,
            user_id,
            full_name,
            module_notes
          
        }
        #endregion

        public IEnumerable<Module> GetAll(int id_project)
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

                        command.Parameters.Add("id_project", SqlDbType.Int);
                        command.Parameters["id_project"].Value = id_project;

                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.Module()
                            {

                                module_name = (!DR.IsDBNull((int)enumQryModuleFields.module_name))
                                           ? DR[(int)enumQryModuleFields.module_name].ToString().Trim()
                                           : string.Empty,
                                Project = new Project()
                                {

                                    id_project = (!DR.IsDBNull((int)enumQryModuleFields.id_project))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.id_project])
                                            : 0,

                                    project_name = (!DR.IsDBNull((int)enumQryModuleFields.project_name))
                                              ? DR[(int)enumQryModuleFields.project_name].ToString().Trim()
                                              : string.Empty,
                                },
                                TypeDev = new TypeDev()
                                {

                                    id_TypeDev = (!DR.IsDBNull((int)enumQryModuleFields.id_TypeDev))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.id_TypeDev])
                                            : 0,

                                    TypeDev_name = (!DR.IsDBNull((int)enumQryModuleFields.TypeDev_name))
                                              ? DR[(int)enumQryModuleFields.TypeDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                module_details = (!DR.IsDBNull((int)enumQryModuleFields.module_details))
                                           ? DR[(int)enumQryModuleFields.module_details].ToString().Trim()
                                           : string.Empty,
                                posting_date = (!DR.IsDBNull((int)enumQryModuleFields.posting_date))
                                           ? DR[(int)enumQryModuleFields.posting_date].ToString().Trim()
                                           : string.Empty,
                                posted_by = (!DR.IsDBNull((int)enumQryModuleFields.posted_by))
                                           ? DR[(int)enumQryModuleFields.posted_by].ToString().Trim()
                                           : string.Empty,
                                due_date = (!DR.IsDBNull((int)enumQryModuleFields.due_date))
                                           ? DR[(int)enumQryModuleFields.due_date].ToString().Trim()
                                           : string.Empty,
                                PriorityDev = new PriorityDev()
                                {

                                    id_PriorityDev = (!DR.IsDBNull((int)enumQryModuleFields.id_PriorityDev))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.id_PriorityDev])
                                            : 0,

                                    PriorityDev_name = (!DR.IsDBNull((int)enumQryModuleFields.PriorityDev_name))
                                              ? DR[(int)enumQryModuleFields.PriorityDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                StatusDev = new StatusDev()
                                {

                                    id_StatusDev = (!DR.IsDBNull((int)enumQryModuleFields.id_StatusDev))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.id_StatusDev])
                                            : 0,

                                    StatusDev_name = (!DR.IsDBNull((int)enumQryModuleFields.StatusDev_name))
                                              ? DR[(int)enumQryModuleFields.StatusDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                User = new User()
                                {

                                    Id = Convert.ToInt32(DR[(int)enumQryModuleFields.user_id]),
                                    FullName = (!DR.IsDBNull((int)enumQryModuleFields.full_name))
                                            ? DR[(int)enumQryModuleFields.full_name].ToString()
                                            : string.Empty,


                                },
                                module_notes = (!DR.IsDBNull((int)enumQryModuleFields.module_notes))
                                           ? DR[(int)enumQryModuleFields.module_notes].ToString().Trim()
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

        public Module GetOne(string module_name)
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
                                module_name = (!DR.IsDBNull((int)enumQryModuleFields.module_name))
                                           ? DR[(int)enumQryModuleFields.module_name].ToString().Trim()
                                           : string.Empty,
                                Project = new Project()
                                {

                                    id_project = (!DR.IsDBNull((int)enumQryModuleFields.id_project))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.id_project])
                                            : 0,

                                    project_name = (!DR.IsDBNull((int)enumQryModuleFields.project_name))
                                              ? DR[(int)enumQryModuleFields.project_name].ToString().Trim()
                                              : string.Empty,
                                },
                                TypeDev = new TypeDev()
                                {

                                    id_TypeDev = (!DR.IsDBNull((int)enumQryModuleFields.id_TypeDev))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.id_TypeDev])
                                            : 0,

                                    TypeDev_name = (!DR.IsDBNull((int)enumQryModuleFields.TypeDev_name))
                                              ? DR[(int)enumQryModuleFields.TypeDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                module_details = (!DR.IsDBNull((int)enumQryModuleFields.module_details))
                                           ? DR[(int)enumQryModuleFields.module_details].ToString().Trim()
                                           : string.Empty,
                                posting_date = (!DR.IsDBNull((int)enumQryModuleFields.posting_date))
                                           ? DR[(int)enumQryModuleFields.posting_date].ToString().Trim()
                                           : string.Empty,
                                posted_by = (!DR.IsDBNull((int)enumQryModuleFields.posted_by))
                                           ? DR[(int)enumQryModuleFields.posted_by].ToString().Trim()
                                           : string.Empty,
                                due_date = (!DR.IsDBNull((int)enumQryModuleFields.due_date))
                                           ? DR[(int)enumQryModuleFields.due_date].ToString().Trim()
                                           : string.Empty,
                                PriorityDev = new PriorityDev()
                                {

                                    id_PriorityDev = (!DR.IsDBNull((int)enumQryModuleFields.id_PriorityDev))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.id_PriorityDev])
                                            : 0,

                                    PriorityDev_name = (!DR.IsDBNull((int)enumQryModuleFields.PriorityDev_name))
                                              ? DR[(int)enumQryModuleFields.PriorityDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                StatusDev = new StatusDev()
                                {

                                    id_StatusDev = (!DR.IsDBNull((int)enumQryModuleFields.id_StatusDev))
                                            ? Convert.ToInt32(DR[(int)enumQryModuleFields.id_StatusDev])
                                            : 0,

                                    StatusDev_name = (!DR.IsDBNull((int)enumQryModuleFields.StatusDev_name))
                                              ? DR[(int)enumQryModuleFields.StatusDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                User = new User()
                                {

                                    Id = Convert.ToInt32(DR[(int)enumQryModuleFields.user_id]),
                                    FullName = (!DR.IsDBNull((int)enumQryModuleFields.full_name))
                                            ? DR[(int)enumQryModuleFields.full_name].ToString()
                                            : string.Empty,


                                },
                                module_notes = (!DR.IsDBNull((int)enumQryModuleFields.module_notes))
                                           ? DR[(int)enumQryModuleFields.module_notes].ToString().Trim()
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
        public bool Add(Module module)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_voiture_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@module_name", SqlDbType.VarChar);
                        command.Parameters["@module_name"].Value = module.module_name;


                        command.Parameters.Add("@id_project", SqlDbType.Int);
                        command.Parameters["id_project"].Value = module.Project.id_project;

                        command.Parameters.Add("@id_TypeDev", SqlDbType.Int);
                        command.Parameters["id_TypeDev"].Value = module.TypeDev.id_TypeDev;


                        command.Parameters.Add("@module_details", SqlDbType.VarChar);
                        command.Parameters["@module_details"].Value = module.module_details;

                        command.Parameters.Add("@posting_date", SqlDbType.VarChar);
                        command.Parameters["@posting_date"].Value = module.posting_date;

                        command.Parameters.Add("@posted_by", SqlDbType.VarChar);
                        command.Parameters["@posted_by"].Value = module.posted_by;

                        command.Parameters.Add("@due_date", SqlDbType.VarChar);
                        command.Parameters["@due_date"].Value = module.due_date;


                        command.Parameters.Add("@id_PriorityDev", SqlDbType.Int);
                        command.Parameters["id_PriorityDev"].Value = module.PriorityDev.id_PriorityDev;

                        command.Parameters.Add("@id_StatusDev", SqlDbType.Int);
                        command.Parameters["id_StatusDev"].Value = module.StatusDev.id_StatusDev;

                        command.Parameters.Add("@user_id", SqlDbType.Int);
                        command.Parameters["@user_id"].Value = module.User.Id;

                        command.Parameters.Add("@module_notes", SqlDbType.VarChar);
                        command.Parameters["@module_notes"].Value = module.module_notes;



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


        public bool Update(Module module)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_module_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@module_name", SqlDbType.VarChar);
                        command.Parameters["@module_name"].Value = module.module_name;


                        command.Parameters.Add("@id_project", SqlDbType.Int);
                        command.Parameters["id_project"].Value = module.Project.id_project;

                        command.Parameters.Add("@id_TypeDev", SqlDbType.Int);
                        command.Parameters["id_TypeDev"].Value = module.TypeDev.id_TypeDev;


                        command.Parameters.Add("@module_details", SqlDbType.VarChar);
                        command.Parameters["@module_details"].Value = module.module_details;

                        command.Parameters.Add("@posting_date", SqlDbType.VarChar);
                        command.Parameters["@posting_date"].Value = module.posting_date;

                        command.Parameters.Add("@posted_by", SqlDbType.VarChar);
                        command.Parameters["@posted_by"].Value = module.posted_by;

                        command.Parameters.Add("@due_date", SqlDbType.VarChar);
                        command.Parameters["@due_date"].Value = module.due_date;


                        command.Parameters.Add("@id_PriorityDev", SqlDbType.Int);
                        command.Parameters["id_PriorityDev"].Value = module.PriorityDev.id_PriorityDev;

                        command.Parameters.Add("@id_StatusDev", SqlDbType.Int);
                        command.Parameters["id_StatusDev"].Value = module.StatusDev.id_StatusDev;

                        command.Parameters.Add("@user_id", SqlDbType.Int);
                        command.Parameters["@user_id"].Value = module.User.Id;

                        command.Parameters.Add("@module_notes", SqlDbType.VarChar);
                        command.Parameters["@module_notes"].Value = module.module_notes;

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

        public bool Remove(Module module)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_module_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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

    }
}
