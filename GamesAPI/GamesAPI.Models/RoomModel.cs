using System;
using System.Collections.Generic;
using System.Text;

namespace GamesAPI.Models
{
    public class RoomModel
    {
        public long RoomID { get; set; }
        public int RoomNo { get; set; }
        public int CreatedUserID { get; set; }
        public string CreatedUserName { get; set; }
        public int JoinUserID { get; set; }
        public long GameID { get; set; }
        public int MinSecondPerStep { get; set; }
        public int RoomStatus { get; set; }
    }
}
