using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    internal class FriendListView
    {
        private FriendService friendService;

        public FriendListView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            Console.WriteLine("Список друзей: ");
            try
            {
                friendService.ShowFriends(user.Id);
            }
            catch (Exception e)
            {
                MessageHandler.ShowAlertMessage("Ошибка вывода списка!");
            }

        }
    }
}
