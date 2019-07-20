using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesAPI.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Point { get; set; }
        public int Rank { get; set; }
    }
}