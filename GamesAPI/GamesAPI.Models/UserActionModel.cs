﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesAPI.Models
{
    public enum USER_ACTION_TYPE
    {
        USER_LOGIN,USER_ACTIVE,USER_CREATE_ROOM,USER_JOIN_ROOM,USER_GET_ROOM_INFO,USER_GET_ROOM_VIEWER
        ,USER_GET_ROOM_LIST
    };
    public class UserActionModel
    {
        public string UserName { get; set; }
        public int UserID { get; set; }
        public USER_ACTION_TYPE ActionType { get; set; }
        public string ActionData { get; set; }
    }
}