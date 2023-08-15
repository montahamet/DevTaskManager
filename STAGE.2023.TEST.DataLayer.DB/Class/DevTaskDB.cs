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
    public class DevTaskDB : IDevTask
    {
        #region Enums 
        private enum enumQryDevTaskFields
        {
            dev_task_id = 0,
            id_project,
            project_name,
            id_TypeDev,
            TypeDev_name,
            details,
            source,
            posting_date,
            posted_by,
            due_date,
            id_PriorityDev,
            PriorityDev_name,
            id_StatusDev,
            StatusDev_name,
            user_id,
            full_name,
            notes

        }
        #endregion
        public IEnumerable<DevTask> GetAll(int dev_task_id)
        {
            Entities.DevTasks Ret = new Entities.DevTasks();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_dev_task_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("dev_task_id", SqlDbType.Int);
                        command.Parameters["dev_task_id"].Value = dev_task_id;

                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.DevTask()
                            {
                                dev_task_id = (!DR.IsDBNull((int)enumQryDevTaskFields.dev_task_id))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.dev_task_id])
                                            : 0,
                                Project = new Project()
                                {

                                    id_project = (!DR.IsDBNull((int)enumQryDevTaskFields.id_project))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_project])
                                            : 0,

                                    project_name = (!DR.IsDBNull((int)enumQryDevTaskFields.project_name))
                                              ? DR[(int)enumQryDevTaskFields.project_name].ToString().Trim()
                                              : string.Empty,
                                },
                                TypeDev = new TypeDev()
                                {

                                    id_TypeDev = (!DR.IsDBNull((int)enumQryDevTaskFields.id_TypeDev))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_TypeDev])
                                            : 0,

                                    TypeDev_name = (!DR.IsDBNull((int)enumQryDevTaskFields.TypeDev_name))
                                              ? DR[(int)enumQryDevTaskFields.TypeDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                details = (!DR.IsDBNull((int)enumQryDevTaskFields.details))
                                           ? DR[(int)enumQryDevTaskFields.details].ToString().Trim()
                                           : string.Empty,
                                source = (!DR.IsDBNull((int)enumQryDevTaskFields.source))
                                           ? DR[(int)enumQryDevTaskFields.source].ToString().Trim()
                                           : string.Empty,
                                posting_date = (!DR.IsDBNull((int)enumQryDevTaskFields.posting_date))
                                           ? DR[(int)enumQryDevTaskFields.posting_date].ToString().Trim()
                                           : string.Empty,
                                posted_by = (!DR.IsDBNull((int)enumQryDevTaskFields.posted_by))
                                           ? DR[(int)enumQryDevTaskFields.posted_by].ToString().Trim()
                                           : string.Empty,
                                due_date = (!DR.IsDBNull((int)enumQryDevTaskFields.due_date))
                                           ? DR[(int)enumQryDevTaskFields.due_date].ToString().Trim()
                                           : string.Empty,
                                PriorityDev = new PriorityDev()
                                {

                                    id_PriorityDev = (!DR.IsDBNull((int)enumQryDevTaskFields.id_PriorityDev))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_PriorityDev])
                                            : 0,

                                    PriorityDev_name = (!DR.IsDBNull((int)enumQryDevTaskFields.PriorityDev_name))
                                              ? DR[(int)enumQryDevTaskFields.PriorityDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                StatusDev = new StatusDev()
                                {

                                    id_StatusDev = (!DR.IsDBNull((int)enumQryDevTaskFields.id_StatusDev))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_StatusDev])
                                            : 0,

                                    StatusDev_name = (!DR.IsDBNull((int)enumQryDevTaskFields.StatusDev_name))
                                              ? DR[(int)enumQryDevTaskFields.StatusDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                User = new User()
                                {

                                    Id = Convert.ToInt32(DR[(int)enumQryDevTaskFields.user_id]),
                                    FullName = (!DR.IsDBNull((int)enumQryDevTaskFields.full_name))
                                            ? DR[(int)enumQryDevTaskFields.full_name].ToString()
                                            : string.Empty,


                                },
                                notes = (!DR.IsDBNull((int)enumQryDevTaskFields.notes))
                                           ? DR[(int)enumQryDevTaskFields.notes].ToString().Trim()
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

        public DevTask GetOneByID(int dev_task_id)
        {
            Entities.DevTask Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_dev_task_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@dev_task_id", SqlDbType.Int);
                        command.Parameters["@dev_task_id"].Value = dev_task_id;

                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.DevTask()
                            {
                                dev_task_id = (!DR.IsDBNull((int)enumQryDevTaskFields.dev_task_id))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.dev_task_id])
                                            : 0,
                                Project = new Project()
                                {

                                    id_project = (!DR.IsDBNull((int)enumQryDevTaskFields.id_project))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_project])
                                            : 0,

                                    project_name = (!DR.IsDBNull((int)enumQryDevTaskFields.project_name))
                                              ? DR[(int)enumQryDevTaskFields.project_name].ToString().Trim()
                                              : string.Empty,
                                },
                                TypeDev = new TypeDev()
                                {

                                    id_TypeDev = (!DR.IsDBNull((int)enumQryDevTaskFields.id_TypeDev))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_TypeDev])
                                            : 0,

                                    TypeDev_name = (!DR.IsDBNull((int)enumQryDevTaskFields.TypeDev_name))
                                              ? DR[(int)enumQryDevTaskFields.TypeDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                details = (!DR.IsDBNull((int)enumQryDevTaskFields.details))
                                           ? DR[(int)enumQryDevTaskFields.details].ToString().Trim()
                                           : string.Empty,
                                source = (!DR.IsDBNull((int)enumQryDevTaskFields.source))
                                           ? DR[(int)enumQryDevTaskFields.source].ToString().Trim()
                                           : string.Empty,
                                posting_date = (!DR.IsDBNull((int)enumQryDevTaskFields.posting_date))
                                           ? DR[(int)enumQryDevTaskFields.posting_date].ToString().Trim()
                                           : string.Empty,
                                posted_by = (!DR.IsDBNull((int)enumQryDevTaskFields.posted_by))
                                           ? DR[(int)enumQryDevTaskFields.posted_by].ToString().Trim()
                                           : string.Empty,
                                due_date = (!DR.IsDBNull((int)enumQryDevTaskFields.due_date))
                                           ? DR[(int)enumQryDevTaskFields.due_date].ToString().Trim()
                                           : string.Empty,
                                PriorityDev = new PriorityDev()
                                {

                                    id_PriorityDev = (!DR.IsDBNull((int)enumQryDevTaskFields.id_PriorityDev))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_PriorityDev])
                                            : 0,

                                    PriorityDev_name = (!DR.IsDBNull((int)enumQryDevTaskFields.PriorityDev_name))
                                              ? DR[(int)enumQryDevTaskFields.PriorityDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                StatusDev = new StatusDev()
                                {

                                    id_StatusDev = (!DR.IsDBNull((int)enumQryDevTaskFields.id_StatusDev))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_StatusDev])
                                            : 0,

                                    StatusDev_name = (!DR.IsDBNull((int)enumQryDevTaskFields.StatusDev_name))
                                              ? DR[(int)enumQryDevTaskFields.StatusDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                User = new User()
                                {

                                    Id = Convert.ToInt32(DR[(int)enumQryDevTaskFields.user_id]),
                                    FullName = (!DR.IsDBNull((int)enumQryDevTaskFields.full_name))
                                            ? DR[(int)enumQryDevTaskFields.full_name].ToString()
                                            : string.Empty,


                                },
                                notes = (!DR.IsDBNull((int)enumQryDevTaskFields.notes))
                                           ? DR[(int)enumQryDevTaskFields.notes].ToString().Trim()
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

        public DevTask GetOneByProjectName(string project_name)
        {
            Entities.DevTask Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_dev_task_get_one_by_name", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("@project_name", SqlDbType.VarChar);
                        command.Parameters["@project_name"].Value = project_name;
                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.DevTask()
                            {
                                dev_task_id = (!DR.IsDBNull((int)enumQryDevTaskFields.dev_task_id))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.dev_task_id])
                                            : 0,
                                Project = new Project()
                                {

                                    id_project = (!DR.IsDBNull((int)enumQryDevTaskFields.id_project))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_project])
                                            : 0,

                                    project_name = (!DR.IsDBNull((int)enumQryDevTaskFields.project_name))
                                              ? DR[(int)enumQryDevTaskFields.project_name].ToString().Trim()
                                              : string.Empty,
                                },
                                TypeDev = new TypeDev()
                                {

                                    id_TypeDev = (!DR.IsDBNull((int)enumQryDevTaskFields.id_TypeDev))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_TypeDev])
                                            : 0,

                                    TypeDev_name = (!DR.IsDBNull((int)enumQryDevTaskFields.TypeDev_name))
                                              ? DR[(int)enumQryDevTaskFields.TypeDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                details = (!DR.IsDBNull((int)enumQryDevTaskFields.details))
                                           ? DR[(int)enumQryDevTaskFields.details].ToString().Trim()
                                           : string.Empty,
                                source = (!DR.IsDBNull((int)enumQryDevTaskFields.source))
                                           ? DR[(int)enumQryDevTaskFields.source].ToString().Trim()
                                           : string.Empty,
                                posting_date = (!DR.IsDBNull((int)enumQryDevTaskFields.posting_date))
                                           ? DR[(int)enumQryDevTaskFields.posting_date].ToString().Trim()
                                           : string.Empty,
                                posted_by = (!DR.IsDBNull((int)enumQryDevTaskFields.posted_by))
                                           ? DR[(int)enumQryDevTaskFields.posted_by].ToString().Trim()
                                           : string.Empty,
                                due_date = (!DR.IsDBNull((int)enumQryDevTaskFields.due_date))
                                           ? DR[(int)enumQryDevTaskFields.due_date].ToString().Trim()
                                           : string.Empty,
                                PriorityDev = new PriorityDev()
                                {

                                    id_PriorityDev = (!DR.IsDBNull((int)enumQryDevTaskFields.id_PriorityDev))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_PriorityDev])
                                            : 0,

                                    PriorityDev_name = (!DR.IsDBNull((int)enumQryDevTaskFields.PriorityDev_name))
                                              ? DR[(int)enumQryDevTaskFields.PriorityDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                StatusDev = new StatusDev()
                                {

                                    id_StatusDev = (!DR.IsDBNull((int)enumQryDevTaskFields.id_StatusDev))
                                            ? Convert.ToInt32(DR[(int)enumQryDevTaskFields.id_StatusDev])
                                            : 0,

                                    StatusDev_name = (!DR.IsDBNull((int)enumQryDevTaskFields.StatusDev_name))
                                              ? DR[(int)enumQryDevTaskFields.StatusDev_name].ToString().Trim()
                                              : string.Empty,
                                },
                                User = new User()
                                {

                                    Id = Convert.ToInt32(DR[(int)enumQryDevTaskFields.user_id]),
                                    FullName = (!DR.IsDBNull((int)enumQryDevTaskFields.full_name))
                                            ? DR[(int)enumQryDevTaskFields.full_name].ToString()
                                            : string.Empty,


                                },
                                notes = (!DR.IsDBNull((int)enumQryDevTaskFields.notes))
                                           ? DR[(int)enumQryDevTaskFields.notes].ToString().Trim()
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

        public bool Add(DevTask devTask)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_dev_task_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@dev_task_id", SqlDbType.Int);
                        command.Parameters["dev_task_id"].Value = devTask.dev_task_id;


                        command.Parameters.Add("@id_project", SqlDbType.Int);
                        command.Parameters["id_project"].Value = devTask.Project.id_project;

                        command.Parameters.Add("@id_TypeDev", SqlDbType.Int);
                        command.Parameters["id_TypeDev"].Value = devTask.TypeDev.id_TypeDev;


                        command.Parameters.Add("@details", SqlDbType.VarChar);
                        command.Parameters["@details"].Value = devTask.details;

                        command.Parameters.Add("@source", SqlDbType.VarChar);
                        command.Parameters["@source"].Value = devTask.source;
                        

                        command.Parameters.Add("@posting_date", SqlDbType.VarChar);
                        command.Parameters["@posting_date"].Value = devTask.posting_date;

                        command.Parameters.Add("@posted_by", SqlDbType.VarChar);
                        command.Parameters["@posted_by"].Value = devTask.posted_by;

                        command.Parameters.Add("@due_date", SqlDbType.VarChar);
                        command.Parameters["@due_date"].Value = devTask.due_date;


                        command.Parameters.Add("@id_PriorityDev", SqlDbType.Int);
                        command.Parameters["id_PriorityDev"].Value = devTask.PriorityDev.id_PriorityDev;

                        command.Parameters.Add("@id_StatusDev", SqlDbType.Int);
                        command.Parameters["id_StatusDev"].Value = devTask.StatusDev.id_StatusDev;

                        command.Parameters.Add("@user_id", SqlDbType.Int);
                        command.Parameters["@user_id"].Value = devTask.User.Id;

                        command.Parameters.Add("@notes", SqlDbType.VarChar);
                        command.Parameters["@notes"].Value = devTask.notes;



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

        public bool Update(DevTask devTask)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_dev_task_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@dev_task_id", SqlDbType.Int);
                        command.Parameters["dev_task_id"].Value = devTask.dev_task_id;


                        command.Parameters.Add("@id_project", SqlDbType.Int);
                        command.Parameters["id_project"].Value = devTask.Project.id_project;

                        command.Parameters.Add("@id_TypeDev", SqlDbType.Int);
                        command.Parameters["id_TypeDev"].Value = devTask.TypeDev.id_TypeDev;


                        command.Parameters.Add("@details", SqlDbType.VarChar);
                        command.Parameters["@details"].Value = devTask.details;

                        command.Parameters.Add("@source", SqlDbType.VarChar);
                        command.Parameters["@source"].Value = devTask.source;


                        command.Parameters.Add("@posting_date", SqlDbType.VarChar);
                        command.Parameters["@posting_date"].Value = devTask.posting_date;

                        command.Parameters.Add("@posted_by", SqlDbType.VarChar);
                        command.Parameters["@posted_by"].Value = devTask.posted_by;

                        command.Parameters.Add("@due_date", SqlDbType.VarChar);
                        command.Parameters["@due_date"].Value = devTask.due_date;


                        command.Parameters.Add("@id_PriorityDev", SqlDbType.Int);
                        command.Parameters["id_PriorityDev"].Value = devTask.PriorityDev.id_PriorityDev;

                        command.Parameters.Add("@id_StatusDev", SqlDbType.Int);
                        command.Parameters["id_StatusDev"].Value = devTask.StatusDev.id_StatusDev;

                        command.Parameters.Add("@user_id", SqlDbType.Int);
                        command.Parameters["@user_id"].Value = devTask.User.Id;

                        command.Parameters.Add("@notes", SqlDbType.VarChar);
                        command.Parameters["@notes"].Value = devTask.notes;

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

        public bool Remove(DevTask devTask)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_dev_task_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@dev_task_id", SqlDbType.Int);
                        command.Parameters["@dev_task_id"].Value = devTask.dev_task_id;

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
