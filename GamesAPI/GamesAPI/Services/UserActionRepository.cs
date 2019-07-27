using GamesAPI.DataAccess;
using GamesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesAPI.Services
{
    public class UserActionRepository
    {
        public ResultMessageModel ProcessAction(UserActionModel userActionModel)
        {
            ResultMessageModel result = new ResultMessageModel();
            UserDataAccess userDataAccess = new UserDataAccess();
            try
            {
                userActionModel.UserID = userDataAccess.GetUserIDByUserName(userActionModel.UserName);

                if (userActionModel.ActionType == USER_ACTION_TYPE.USER_ACTIVE)
                {
                    result = ActiveUser(userActionModel);
                }
                else if (userActionModel.ActionType == USER_ACTION_TYPE.USER_LOGIN)
                {
                    result = LoginUser(userActionModel);
                }
            }
            catch (Exception ex)
            {
                result.Result = -1;
                result.ResultID = 0;
                result.ResultMessage = ex.Message;
            }
            return result;
        }
        public ResultMessageModel ActiveUser(UserActionModel userActionModel)
        {
            UserActionDataAccess userActionDataAccess = new UserActionDataAccess();
            ResultMessageModel result = userActionDataAccess.ActiveUser(userActionModel);
            return result;
        }
        public ResultMessageModel LoginUser(UserActionModel userActionModel)
        {
            UserActionDataAccess userActionDataAccess = new UserActionDataAccess();
            ResultMessageModel result = userActionDataAccess.LoginUser(userActionModel);
            return result;
        }
        public ResultMessageModel UserCreateRoom(UserActionModel userActionModel)
        {
            UserActionDataAccess userActionDataAccess = new UserActionDataAccess();
            ResultMessageModel result = userActionDataAccess.ActiveUser(userActionModel);
            return result;
        }
    }
}