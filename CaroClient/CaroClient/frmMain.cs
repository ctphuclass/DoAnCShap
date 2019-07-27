using GamesAPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroClient
{
    public partial class frmMain : Form
    {
        public UserModel currentUser = new UserModel();
        public frmMain()
        {
            InitializeComponent();
        }

        static async Task<UserModel> GetUserInfo(int iUserID)
        {
            UserModel user = new UserModel();
            try
            {
                var client = new RestClient(ConfigurationManager.AppSettings["API_URL"].ToString());
                var request = new RestRequest("api/User/"+iUserID.ToString());

                var response = client.Get(request);
                var content = response.Content; // raw content as string
                user = JsonConvert.DeserializeObject<UserModel>(content);
                
            }
            catch
            {
                user = null;
            }
            return user;
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            currentUser = await GetUserInfo(this.currentUser.UserID);
            if(currentUser != null)
            {
                tbUserName.Text = currentUser.UserName;
                tbPoint.Text = currentUser.Point.ToString();
                tbRank.Text = currentUser.Rank.ToString();
                this.Text = currentUser.UserName;
            }
        }

        private void roomList_ItemClick(object sender, Manina.Windows.Forms.ItemClickEventArgs e)
        {
            this.Text = e.Item.Text;
        }
    }
}
