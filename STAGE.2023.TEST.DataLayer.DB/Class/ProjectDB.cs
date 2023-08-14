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

namespace STAGE._2023.TEST.DataLayer.DB
{
    public class ProjectDB : IProject
    {
        #region Enums

        private enum enumQryProjectFields
        {
            id_project = 0,
            project_name,
            project_module,
            project_version,
            project_description,
            project_leader,
            project_estimated_budget,
            project_total_amount,
            project_estimated_duration,
            id_StatusProject,
            StatusProject_name
        }

        #endregion
        public IEnumerable<Project> GetAll()
        {
            Entities.Projects Ret = new Entities.Projects();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_project_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure; 

                        command.Parameters.Add("@id_project", SqlDbType.Int);
                        command.Parameters["@id_project"].Value = -1;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.Project()
                            {
                                id_project = (!DR.IsDBNull((int)enumQryProjectFields.id_project))
                                            ? Convert.ToInt32(DR[(int)enumQryProjectFields.id_project])
                                            : 0,
                                project_name = (!DR.IsDBNull((int)enumQryProjectFields.project_name))
                                              ? DR[(int)enumQryProjectFields.project_name].ToString().Trim()
                                              : string.Empty,
                                project_module = (!DR.IsDBNull((int)enumQryProjectFields.project_module))
                                              ? DR[(int)enumQryProjectFields.project_module].ToString().Trim()
                                              : string.Empty,

                                project_version = (!DR.IsDBNull((int)enumQryProjectFields.project_version))
                                            ? DR[(int)enumQryProjectFields.project_version].ToString().Trim()
                                            : string.Empty,

                                project_description = (!DR.IsDBNull((int)enumQryProjectFields.project_description))
                                              ? DR[(int)enumQryProjectFields.project_description].ToString().Trim()
                                              : string.Empty,

                                project_leader = (!DR.IsDBNull((int)enumQryProjectFields.project_leader))
                                              ? DR[(int)enumQryProjectFields.project_leader].ToString().Trim()
                                             : string.Empty,
                                project_estimated_budget = (!DR.IsDBNull((int)enumQryProjectFields.project_estimated_budget))
                                            ? Convert.ToInt32(DR[(int)enumQryProjectFields.project_estimated_budget])
                                            : 0,
                                project_total_amount = (!DR.IsDBNull((int)enumQryProjectFields.project_total_amount))
                                            ? Convert.ToInt32(DR[(int)enumQryProjectFields.project_total_amount])
                                            : 0,
                                project_estimated_duration = (!DR.IsDBNull((int)enumQryProjectFields.project_estimated_duration))
                                              ? DR[(int)enumQryProjectFields.project_estimated_duration].ToString().Trim()
                                              : string.Empty,

                                StatusProject = new StatusProject()

                                {
                                    id_StatusProject = (!DR.IsDBNull((int)enumQryProjectFields.id_StatusProject))
                                            ? Convert.ToInt32(DR[(int)enumQryProjectFields.id_StatusProject])
                                            : 0,
                                    

                                    StatusProject_name = (!DR.IsDBNull((int)enumQryProjectFields.StatusProject_name))
                                              ? DR[(int)enumQryProjectFields.StatusProject_name].ToString()
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
        public Project Getone(int id_project)
        {
            Entities.Project Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_project_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_project", SqlDbType.Int);
                        command.Parameters["@id_project"].Value = id_project;

                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.Project()
                            {
                                id_project = Convert.ToInt32(DR[(int)enumQryProjectFields.id_project]),
                                project_name = (!DR.IsDBNull((int)enumQryProjectFields.project_name))
                                              ? DR[(int)enumQryProjectFields.project_name].ToString().Trim()
                                              : string.Empty,
                                project_module = (!DR.IsDBNull((int)enumQryProjectFields.project_module))
                                              ? DR[(int)enumQryProjectFields.project_module].ToString().Trim()
                                              : string.Empty,

                                project_version = (!DR.IsDBNull((int)enumQryProjectFields.project_version))
                                            ? DR[(int)enumQryProjectFields.project_version].ToString().Trim()
                                            : string.Empty,

                                project_description = (!DR.IsDBNull((int)enumQryProjectFields.project_description))
                                              ? DR[(int)enumQryProjectFields.project_description].ToString().Trim()
                                              : string.Empty,

                                project_leader = (!DR.IsDBNull((int)enumQryProjectFields.project_leader))
                                              ? DR[(int)enumQryProjectFields.project_leader].ToString().Trim()
                                             : string.Empty,
                                project_estimated_budget = Convert.ToInt32(DR[(int)enumQryProjectFields.project_estimated_budget]),
                                project_total_amount = Convert.ToInt32(DR[(int)enumQryProjectFields.project_total_amount]),
                                project_estimated_duration = (!DR.IsDBNull((int)enumQryProjectFields.project_estimated_duration))
                                              ? DR[(int)enumQryProjectFields.project_estimated_duration].ToString().Trim()
                                             : string.Empty,

                                StatusProject = new StatusProject()

                                {
                                    id_StatusProject = (!DR.IsDBNull((int)enumQryProjectFields.id_StatusProject))
                                            ? Convert.ToInt32(DR[(int)enumQryProjectFields.id_StatusProject])
                                            : 0,
                                    

                                    StatusProject_name = (!DR.IsDBNull((int)enumQryProjectFields.StatusProject_name))
                                              ? DR[(int)enumQryProjectFields.StatusProject_name].ToString()
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
        public bool Add(Project project)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_project_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                      

                        command.Parameters.Add("@project_name", SqlDbType.VarChar);
                        command.Parameters["@project_name"].Value = project.project_name;

                        command.Parameters.Add("@project_version", SqlDbType.VarChar);
                        command.Parameters["@project_version"].Value = project.project_name;

                        command.Parameters.Add("@project_module", SqlDbType.VarChar);
                        command.Parameters["@project_module"].Value = project.project_module;


                        command.Parameters.Add("@project_description", SqlDbType.VarChar);
                        command.Parameters["@project_description"].Value = project.project_description;

                        command.Parameters.Add("@project_leader", SqlDbType.VarChar);
                        command.Parameters["@project_leader"].Value = project.project_leader;

                        command.Parameters.Add("@project_estimated_budget", SqlDbType.Int);
                        command.Parameters["@project_estimated_budget"].Value = project.project_estimated_budget;

                        command.Parameters.Add("@project_total_amount", SqlDbType.Int);
                        command.Parameters["@project_total_amount"].Value = project.project_total_amount;

                        command.Parameters.Add("@project_estimated_duration", SqlDbType.VarChar);
                        command.Parameters["@project_estimated_duration"].Value = project.project_estimated_duration;

                        command.Parameters.Add("@id_StatusProject", SqlDbType.Int);
                        command.Parameters["@id_StatusProject"].Value = project.id_StatusProject;

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
        public bool Update(Project project)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_project_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_project", SqlDbType.Int);
                        command.Parameters["@id_project"].Value = project.id_project;


                        command.Parameters.Add("@project_name", SqlDbType.VarChar);
                        command.Parameters["@project_name"].Value = project.project_name;

                        command.Parameters.Add("@project_module", SqlDbType.VarChar);
                        command.Parameters["@project_module"].Value = project.project_module;

                        command.Parameters.Add("@project_version", SqlDbType.VarChar);
                        command.Parameters["@project_version"].Value = project.project_name;


                        command.Parameters.Add("@project_description", SqlDbType.VarChar);
                        command.Parameters["@project_description"].Value = project.project_description;

                        command.Parameters.Add("@project_leader", SqlDbType.VarChar);
                        command.Parameters["@project_leader"].Value = project.project_leader;

                        command.Parameters.Add("@project_estimated_budget", SqlDbType.Int);
                        command.Parameters["@project_estimated_budget"].Value = project.project_estimated_budget;

                        command.Parameters.Add("@project_total_amount", SqlDbType.Int);
                        command.Parameters["@project_total_amount"].Value = project.project_total_amount;

                        command.Parameters.Add("@project_estimated_duration", SqlDbType.VarChar);
                        command.Parameters["@project_estimated_duration"].Value = project.project_estimated_duration;

                        command.Parameters.Add("@id_StatusProject", SqlDbType.Int);
                        command.Parameters["@id_StatusProject"].Value = project.id_StatusProject;

                        

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
        public bool Remove(Project project)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_project_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_project", SqlDbType.Int);
                        command.Parameters["@id_project"].Value = project.id_project;

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
