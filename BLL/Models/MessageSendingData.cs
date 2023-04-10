using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    internal class MessageSendingData
    {
        public int Sender_Id { get; set; }
        public string RecipientEmail { get; set; }
        public string Content { get; set; }
    }
}
