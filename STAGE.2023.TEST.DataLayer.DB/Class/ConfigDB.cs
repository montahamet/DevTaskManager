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
    public class ConfigDB : IConfig
    {
        #region Enums 


        private enum enumQryTypeDevFields
        {
            id_TypeDev = 0,
            TypeDev_name
        }

        private enum enumQryPriorityDevFields
        {
            id_PriorityDev = 0,
            PriorityDev_name
        }


        private enum enumQryStatusDevFields
        {
            id_StatusDev = 0,
            StatusDev_name
        }

        private enum enumQryStatusProjectFields
        {
            id_StatusProject = 0,
            StatusProject_name

        }

        #endregion

        ////TypeDev
        public IEnumerable<TypeDev> GetAllTypeDevs()
        {
            Entities.TypeDevs Ret = new Entities.TypeDevs();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_typedev_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.TypeDev()
                            {
                                id_TypeDev = (!DR.IsDBNull((int)enumQryTypeDevFields.id_TypeDev))
                                            ? Convert.ToInt32(DR[(int)enumQryTypeDevFields.id_TypeDev])
                                            : 0,
                                TypeDev_name = (!DR.IsDBNull((int)enumQryTypeDevFields.TypeDev_name))
                                              ? DR[(int)enumQryTypeDevFields.TypeDev_name].ToString().Trim()
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

        public TypeDev TypeDevGetOne(int id_TypeDev)
        {
            Entities.TypeDev Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_typedev_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("@id_TypeDev", SqlDbType.Int);
                        command.Parameters["@id_TypeDev"].Value = id_TypeDev;
                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.TypeDev()
                            {
                                id_TypeDev = (!DR.IsDBNull((int)enumQryTypeDevFields.id_TypeDev))
                                            ? Convert.ToInt32(DR[(int)enumQryTypeDevFields.id_TypeDev])
                                            : 0,
                                TypeDev_name = (!DR.IsDBNull((int)enumQryTypeDevFields.TypeDev_name))
                                           ? DR[(int)enumQryTypeDevFields.TypeDev_name].ToString().Trim()
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

        public bool TypeDevAdd(TypeDev typedev)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_typedev_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;



                        command.Parameters.Add("@TypeDev_name", SqlDbType.VarChar);
                        command.Parameters["@TypeDev_name"].Value = typedev.TypeDev_name;



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

        public bool TypeDevUpdate(TypeDev typedev)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_typedev_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_TypeDev", SqlDbType.Int);
                        command.Parameters["@id_TypeDev"].Value = typedev.id_TypeDev;

                        command.Parameters.Add("@TypeDev_name", SqlDbType.VarChar);
                        command.Parameters["@TypeDev_name"].Value = typedev.TypeDev_name;

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

        public bool TypeDevRemove(TypeDev typedev)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_typedev_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_TypeDev", SqlDbType.Int);
                        command.Parameters["@id_TypeDev"].Value = typedev.id_TypeDev;

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

        /////PriorityDev

        public IEnumerable<PriorityDev> GetAllPriorityDevs()
        {
            Entities.PriorityDevs Ret = new Entities.PriorityDevs();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prioritydev_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.PriorityDev()
                            {
                                id_PriorityDev = (!DR.IsDBNull((int)enumQryPriorityDevFields.id_PriorityDev))
                                            ? Convert.ToInt32(DR[(int)enumQryPriorityDevFields.id_PriorityDev])
                                            : 0,
                                PriorityDev_name = (!DR.IsDBNull((int)enumQryPriorityDevFields.PriorityDev_name))
                                               ? DR[(int)enumQryPriorityDevFields.PriorityDev_name].ToString().Trim()
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

        public PriorityDev PriorityDevGetOne(int id_PriorityDev)
        {
            Entities.PriorityDev Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prioritydev_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("@id_PriorityDev", SqlDbType.Int);
                        command.Parameters["@id_PriorityDev"].Value = id_PriorityDev;
                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.PriorityDev()
                            {
                                id_PriorityDev = (!DR.IsDBNull((int)enumQryPriorityDevFields.id_PriorityDev))
                                            ? Convert.ToInt32(DR[(int)enumQryPriorityDevFields.id_PriorityDev])
                                            : 0,
                                PriorityDev_name = (!DR.IsDBNull((int)enumQryPriorityDevFields.PriorityDev_name))
                                           ? DR[(int)enumQryPriorityDevFields.PriorityDev_name].ToString().Trim()
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

        public bool PriorityDevAdd(PriorityDev prioritydev)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prioritydev_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;



                        command.Parameters.Add("@PriorityDev_name", SqlDbType.VarChar);
                        command.Parameters["@PriorityDev_name"].Value = prioritydev.PriorityDev_name;



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

        public bool PriorityDevUpdate(PriorityDev prioritydev)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prioritydev_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_PriorityDev", SqlDbType.Int);
                        command.Parameters["@id_PriorityDev"].Value = prioritydev.id_PriorityDev;

                        command.Parameters.Add("@PriorityDev_name", SqlDbType.VarChar);
                        command.Parameters["@PriorityDev_name"].Value = prioritydev.PriorityDev_name;

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

        public bool PriorityDevRemove(PriorityDev prioritydev)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_prioritydev_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_PriorityDev", SqlDbType.Int);
                        command.Parameters["@id_PriorityDev"].Value = prioritydev.id_PriorityDev;

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


        /////StatusDev
        public IEnumerable<StatusDev> GetAllStatusDevs()
        {
            Entities.StatusDevs Ret = new Entities.StatusDevs();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_statusdev_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.StatusDev()
                            {
                                id_StatusDev = (!DR.IsDBNull((int)enumQryStatusDevFields.id_StatusDev))
                                            ? Convert.ToInt32(DR[(int)enumQryStatusDevFields.id_StatusDev])
                                            : 0,
                                StatusDev_name = (!DR.IsDBNull((int)enumQryStatusDevFields.StatusDev_name))
                                               ? DR[(int)enumQryStatusDevFields.StatusDev_name].ToString().Trim()
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

        public StatusDev StatusDevGetOne(int id_StatusDev)
        {
            Entities.StatusDev Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_statusdev_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("@id_StatusDev", SqlDbType.Int);
                        command.Parameters["@id_StatusDev"].Value = id_StatusDev;
                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.StatusDev()
                            {
                                id_StatusDev = (!DR.IsDBNull((int)enumQryStatusDevFields.id_StatusDev))
                                            ? Convert.ToInt32(DR[(int)enumQryStatusDevFields.id_StatusDev])
                                            : 0,
                                StatusDev_name = (!DR.IsDBNull((int)enumQryStatusDevFields.StatusDev_name))
                                           ? DR[(int)enumQryStatusDevFields.StatusDev_name].ToString().Trim()
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

        public bool StatusDevAdd(StatusDev statusdev)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_statusdev_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;



                        command.Parameters.Add("@StatusDev_name", SqlDbType.VarChar);
                        command.Parameters["@StatusDev_name"].Value = statusdev.StatusDev_name;



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

        public bool StatusDevUpdate(StatusDev statusdev)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_statusdev_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_StatusDev", SqlDbType.Int);
                        command.Parameters["@id_StatusDev"].Value = statusdev.id_StatusDev;

                        command.Parameters.Add("@StatusDev_name", SqlDbType.VarChar);
                        command.Parameters["@StatusDev_name"].Value = statusdev.StatusDev_name;

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

        public bool StatusDevRemove(StatusDev statusdev)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_statusdev_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_StatusDev", SqlDbType.Int);
                        command.Parameters["@id_StatusDev"].Value = statusdev.id_StatusDev;

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

        /////StatusProject
        public IEnumerable<StatusProject> GetAllStatusProject()
        {
            Entities.StatusProjects Ret = new Entities.StatusProjects();
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_statusproject_get_all", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        DR = command.ExecuteReader();

                        while (DR.Read())
                        {
                            Ret.Add(new Entities.StatusProject()
                            {
                                id_StatusProject = (!DR.IsDBNull((int)enumQryStatusProjectFields.id_StatusProject))
                                            ? Convert.ToInt32(DR[(int)enumQryStatusProjectFields.id_StatusProject])
                                            : 0,
                                
                                StatusProject_name = (!DR.IsDBNull((int)enumQryStatusProjectFields.StatusProject_name))
                                               ? DR[(int)enumQryStatusProjectFields.StatusProject_name].ToString().Trim()
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

        public StatusProject StatusProjectGetOne(int id_StatusProject)
        {
            Entities.StatusProject Ret = null;
            SqlDataReader DR = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_statusproject_get_one_by_id", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.Add("@id_StatusProject", SqlDbType.Int);
                        command.Parameters["@id_StatusProject"].Value = id_StatusProject;
                        conn.Open();
                        DR = command.ExecuteReader();

                        if (DR.Read())
                        {
                            Ret = new Entities.StatusProject()
                            {
                                id_StatusProject = (!DR.IsDBNull((int)enumQryStatusProjectFields.id_StatusProject))
                                            ? Convert.ToInt32(DR[(int)enumQryStatusProjectFields.id_StatusProject])
                                            : 0,

                                
                                StatusProject_name = (!DR.IsDBNull((int)enumQryStatusProjectFields.StatusProject_name))
                                           ? DR[(int)enumQryStatusProjectFields.StatusProject_name].ToString().Trim()
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

        public bool StatusProjectAdd(StatusProject statusproject)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_statusproject_insert", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@StatusProject_name", SqlDbType.VarChar);
                        command.Parameters["@StatusProject_name"].Value = statusproject.StatusProject_name;



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

        public bool StatusProjectUpdate(StatusProject statusproject)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_statusproject_update", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_StatusProject", SqlDbType.Int);
                        command.Parameters["@id_StatusProject"].Value = statusproject.id_StatusProject;

                        command.Parameters.Add("@StatusProject_name", SqlDbType.VarChar);
                        command.Parameters["@StatusProject_name"].Value = statusproject.StatusProject_name;

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

        public bool StatusProjectRemove(StatusProject statusproject)
        {
            int Ret = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(SettingDB.ConnStr))
                {
                    using (SqlCommand command = new SqlCommand("sp_statusproject_delete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@id_StatusProject", SqlDbType.Int);
                        command.Parameters["@id_StatusProject"].Value = statusproject.id_StatusProject;

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
