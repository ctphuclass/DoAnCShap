using GamesAPI.Models;
using Manina.Windows.Forms;
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
        private List<RoomModel> listRoomModel = new List<RoomModel>();
        public frmMain()
        {
            InitializeComponent();
        }

        async Task<ResultMessageModel> GetRoomActive()
        {
            ResultMessageModel result = new ResultMessageModel();
            try
            {
                UserActionModel userActionModel = new UserActionModel();
                userActionModel.UserID = currentUser.UserID;
                userActionModel.ActionType = USER_ACTION_TYPE.USER_GET_ROOM_LIST;
                var client = new RestClient(ConfigurationManager.AppSettings["API_URL"].ToString());
                var request = new RestRequest("api/UserAction");
                request.AddObject(userActionModel);
                request.Method = Method.POST;
                var response = client.Post(request);
                var content = response.Content; // raw content as string
                result = JsonConvert.DeserializeObject<ResultMessageModel>(content);
                
            }
            catch (Exception ex)
            {
                result.Result = -1;
                result.ResultID = 0;
                result.ResultMessage = ex.Message;
            }
            return result;
        }

        async Task<ResultMessageModel> CreateRoom(int iUserID)
        {
            ResultMessageModel result = new ResultMessageModel();
            try
            {
                UserActionModel userActionModel = new UserActionModel();
                userActionModel.UserID = currentUser.UserID;
                userActionModel.ActionType = USER_ACTION_TYPE.USER_CREATE_ROOM;
                var client = new RestClient(ConfigurationManager.AppSettings["API_URL"].ToString());
                var request = new RestRequest("api/UserAction");
                request.AddObject(userActionModel);
                request.Method = Method.POST;
                var response = client.Post(request);
                var content = response.Content; // raw content as string
                result = JsonConvert.DeserializeObject<ResultMessageModel>(content);
            }
            catch(Exception ex)
            {
                result.Result = -1;
                result.ResultID = 0;
                result.ResultMessage = ex.Message;
            }
            return result;
        }

        async Task<UserModel> GetUserInfo(int iUserID)
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
            ResultMessageModel result = await GetRoomActive();
            if (result.Result > 0)
            {
                listRoomModel.Clear();
                listRoomModel = JsonConvert.DeserializeObject<List<RoomModel>>(result.ResultMessage);
                RefreshRoomList();
            }
            
        }

        private void roomList_ItemClick(object sender, Manina.Windows.Forms.ItemClickEventArgs e)
        {
            this.Text = e.Item.Text;
        }

        private async void btCreateRoom_Click(object sender, EventArgs e)
        {
            //UserActionModel userAction = new UserActionModel();
            //userAction.UserID = currentUser.UserID;
            //userAction.ActionType = USER_ACTION_TYPE.USER_CREATE_ROOM;

            ResultMessageModel result = await CreateRoom(currentUser.UserID);
            if(result.Result > 0)
            {
                result = await GetRoomActive();
                if (result.Result > 0)
                {
                    listRoomModel.Clear();
                    listRoomModel = JsonConvert.DeserializeObject<List<RoomModel>>(result.ResultMessage);
                    RefreshRoomList();
                }
            }
        }

        private void RefreshRoomList()
        {
            if (listRoomModel.Count > 0)
            {
                foreach (RoomModel room in listRoomModel)
                {
                    roomList.Items.Clear();
                    ImageListViewItem itemImage = new ImageListViewItem(Application.StartupPath + "\\Image\\Room.png", "Room " + room.RoomNo.ToString() + " - " + room.CreatedUserName);
                    itemImage.Tag = room;
                    roomList.Items.Add(itemImage);
                }
            }
        }
    }
}
