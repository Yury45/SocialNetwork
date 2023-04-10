using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    internal class Friend
    {
        public int id { get; set; } 

        public int user_id { get; set; }

        public int friend_id { get; set; }

        public string userEmail { get; set; }

        public string friendEmail { get; set; }

        public Friend(int id, int user_id, int friend_id, string userEmail, string friendEmail)
        {
            this.id = id;
            this.user_id = user_id;
            this.friend_id = friend_id;
            this.userEmail = userEmail;
            this.friendEmail = friendEmail;
        }
    }
}
