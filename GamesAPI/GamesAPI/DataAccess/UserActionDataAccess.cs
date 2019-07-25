using GamesAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace GamesAPI.DataAccess
{
    public class UserActionDataAccess
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.AppSettings["ConnectionString"].ToString());
        public ResultMessageModel ActiveUser(UserActionModel userActionModel) // passing Bussiness object Here
        {
            ResultMessageModel result = new ResultMessageModel();
            try
            {
                /* Because We will put all out values from our (UserRegistration.aspx)
				To in Bussiness object and then Pass it to Bussiness logic and then to
				DataAcess
				this way the flow carry on*/
                SqlCommand cmd = new SqlCommand("usp_USER_ActiveUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pUserID", SqlDbType.Int);
                cmd.Parameters["@pUserID"].Value = userActionModel.UserID;
                cmd.Parameters.Add("@pKeyCode", SqlDbType.VarChar, 8);
                cmd.Parameters["@pKeyCode"].Value = userActionModel.ActionData;
                cmd.Parameters.Add("@pResult", SqlDbType.Int);
                cmd.Parameters.Add("@pResultID", SqlDbType.Int);
                cmd.Parameters.Add("@pResultMessage", SqlDbType.VarChar, 50);

                cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultID"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultMessage"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                result.Result = (int)cmd.Parameters["@pResult"].Value;
                if (result.Result > 0)
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
        public ResultMessageModel LoginUser(UserActionModel userActionModel) // passing Bussiness object Here
        {
            ResultMessageModel result = new ResultMessageModel();
            try
            {
                /* Because We will put all out values from our (UserRegistration.aspx)
				To in Bussiness object and then Pass it to Bussiness logic and then to
				DataAcess
				this way the flow carry on*/
                SqlCommand cmd = new SqlCommand("usp_USER_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pUserName", SqlDbType.VarChar, 50);
                cmd.Parameters["@pUserName"].Value = userActionModel.UserName;
                cmd.Parameters.Add("@pPassword", SqlDbType.VarChar, 50);
                cmd.Parameters["@pPassword"].Value = userActionModel.ActionData;
                cmd.Parameters.Add("@pResult", SqlDbType.Int);
                cmd.Parameters.Add("@pResultID", SqlDbType.Int);
                cmd.Parameters.Add("@pResultMessage", SqlDbType.VarChar, 50);

                cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultID"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultMessage"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                result.Result = (int)cmd.Parameters["@pResult"].Value;
                if (result.Result > 0)
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
    }
}