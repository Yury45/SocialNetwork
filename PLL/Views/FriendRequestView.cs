using SocialNetwork.BAL.Services;
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
    internal class FriendRequestView
    {
        private UserService userService;
        private FriendService friendService;

        public FriendRequestView(UserService userService, FriendService friendService)
        {
            this.userService = userService;
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var friendRequestData = new FriendRequestData();

            Console.WriteLine("Добавление в список друзей");
            Console.WriteLine("Введите адресс электронной почты друга:");

            friendRequestData.AcceptorEmail = Console.ReadLine();
            friendRequestData.RequestorEmail = user.Email;

            try
            {
                friendService.SendFriendRequest(friendRequestData);
                MessageHandler.ShowSuccessMessage("Успех. \nПользователь добавлен в список друзей.\n");

            }
            catch (ArgumentNullException e)
            {
                MessageHandler.ShowAlertMessage("Некорректные данные.\n");
            }
            catch (Exception e)
            {
                MessageHandler.ShowAlertMessage("Ошибка при добавлении в список друзей.\n");
            }
        }
    }
}
