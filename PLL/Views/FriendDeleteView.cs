using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    internal class FriendDeleteView
    {
        FriendService friendService;

        public FriendDeleteView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            Console.WriteLine("Удаление друга\nВведите адрес электронной почты: ");

            var friendDeleteData = new FriendRequestData();

            friendDeleteData.RequestorEmail = user.Email;
            friendDeleteData.AcceptorEmail = Console.ReadLine();

            try
            {
                friendService.DeleteFriend(friendDeleteData);
            }
            catch (ArgumentNullException e)
            {
                MessageHandler.ShowAlertMessage("Некорректные данные.");
            }
            catch (UserNotFoundException e)
            {
                MessageHandler.ShowAlertMessage("Пользователь не найден");
            }
            catch (Exception e)
            {
                MessageHandler.ShowAlertMessage("Ошибка операции.");
            }
        }
    }
}
