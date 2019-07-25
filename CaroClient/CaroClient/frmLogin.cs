using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            var client = new RestClient("http://localhost:54263/");
            var request = new RestRequest("api/UserAction");
            request.AddObject(userActionModel);
            request.Method = Method.POST;
            
            var response = client.Post(request);
            var content = response.Content; // raw content as string
            ResultMessageModel result = JsonConvert.DeserializeObject<ResultMessageModel>(content);
            // or automatically deserialize result
            // return content type is sniffed but can be explicitly set via RestClient.AddHandler();
            //RestResponse<ResultMessageModel> response2 = client.Execute<ResultMessageModel>(request);

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
                MessageBox.Show("Hien thi form choi co caro");
            }
            else
            {
                MessageBox.Show(result.ResultMessage);
            }
        }
    }
}
