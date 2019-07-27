using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GamesAPI.Models;
using Newtonsoft.Json;
using RestSharp;

namespace CaroClient
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }
        static async Task<ResultMessageModel> LoginAsync(UserActionModel userActionModel)
        {
            ResultMessageModel result = new ResultMessageModel();
            try
            {
                var client = new RestClient(ConfigurationManager.AppSettings["API_URL"].ToString());
                var request = new RestRequest("api/UserAction");
                request.AddObject(userActionModel);
                request.Method = Method.POST;

                var response = client.Post(request);
                var content = response.Content; // raw content as string
                result = JsonConvert.DeserializeObject<ResultMessageModel>(content);
                if(result == null)
                {
                    result = new ResultMessageModel();
                    result.Result = -1;
                    result.ResultMessage = "CALL_API_FAIL";
                }
            }
            catch
            {
                result.Result = -1;
                result.ResultMessage = "LOGIN_FAIL";
            }
            return result;
        }
        private async void btLogin_Click(object sender, EventArgs e)
        {
            UserActionModel userActionModel = new UserActionModel();
            userActionModel.UserName = tbUserName.Text;
            userActionModel.ActionData = tbPassword.Text;
            userActionModel.ActionType = USER_ACTION_TYPE.USER_LOGIN;
            ResultMessageModel result = await LoginAsync(userActionModel);
            if (result.Result > 0)//login ok
            {
                userActionModel.UserID = result.ResultID;
                this.Hide();
                frmMain fMain = new frmMain();
                fMain.currentUser.UserID = userActionModel.UserID;
                fMain.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(result.ResultMessage);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
