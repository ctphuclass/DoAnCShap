using GamesAPI.Models;
using GamesAPI.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace GamesAPI.DataAccess
{
    public class UserDataAccess
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.AppSettings["ConnectionString"].ToString());

        public ResultMessageModel CreateUser(UserModel umUser) // passing Bussiness object Here
        {
            ResultMessageModel result = new ResultMessageModel();
            try
            {
                /* Because We will put all out values from our (UserRegistration.aspx)
				To in Bussiness object and then Pass it to Bussiness logic and then to
				DataAcess
				this way the flow carry on*/
                SqlCommand cmd = new SqlCommand("usp_USER_CreateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pUserName", SqlDbType.VarChar, 50);
                cmd.Parameters["@pUserName"].Value = umUser.UserName;
                cmd.Parameters.Add("@pPassword", SqlDbType.VarChar, 50);
                cmd.Parameters["@pPassword"].Value = umUser.Password;
                cmd.Parameters.Add("@pEmail", SqlDbType.VarChar, 255);
                cmd.Parameters["@pEmail"].Value = umUser.Email;
                cmd.Parameters.Add("@pAddress", SqlDbType.NVarChar, 8000);
                cmd.Parameters["@pAddress"].Value = umUser.Address;
                cmd.Parameters.Add("@pPhone", SqlDbType.VarChar, 50);
                cmd.Parameters["@pPhone"].Value = umUser.Phone;

                cmd.Parameters.Add("@pResult", SqlDbType.Int);
                cmd.Parameters.Add("@pResultID", SqlDbType.Int);
                cmd.Parameters.Add("@pResultMessage", SqlDbType.VarChar, 50);

                cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultID"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultMessage"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                result.Result = (int)cmd.Parameters["@pResult"].Value;
                if(result.Result > 0)
                    result.ResultID = (int)cmd.Parameters["@pResultID"].Value;
                result.ResultMessage = cmd.Parameters["@pResultMessage"].Value.ToString();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                result.Result = -1;
                result.ResultMessage = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }

        public UserModel GetUserByUserID(int iUserID)
        {
            UserModel result = new UserModel();
            try
            {
                /* Because We will put all out values from our (UserRegistration.aspx)
				To in Bussiness object and then Pass it to Bussiness logic and then to
				DataAcess
				this way the flow carry on*/
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("usp_USER_GetUserByUserID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pUserID", SqlDbType.VarChar, 50);
                cmd.Parameters["@pUserID"].Value = iUserID;
                da.SelectCommand = cmd;
                da.Fill(dt);
                cmd.Dispose();
                if (dt.Rows.Count == 1)
                {
                    result = UtilsRepository.CreateItemFromRow<UserModel>(dt.Rows[0]);
                }
                else
                {
                    result = null;
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }

        public int GetUserIDByUserName(string psUserName)
        {
            int iUserID;
            try
            {
                /* Because We will put all out values from our (UserRegistration.aspx)
				To in Bussiness object and then Pass it to Bussiness logic and then to
				DataAcess
				this way the flow carry on*/
                SqlCommand cmd = new SqlCommand("usp_USER_GetUserIDByUserName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pUserName", SqlDbType.VarChar, 50);
                cmd.Parameters["@pUserName"].Value = psUserName;
                cmd.Parameters.Add("@pUserID", SqlDbType.Int);
                
                cmd.Parameters["@pResultID"].Direction = ParameterDirection.Output;
                
                con.Open();
                cmd.ExecuteNonQuery();
                iUserID = (int)cmd.Parameters["@pResult"].Value;
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                iUserID = 0;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return iUserID;
        }
    }
}