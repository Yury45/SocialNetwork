using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BAL.Services;
using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    internal class UserMenuView
    {
        public UserService userService;

        public UserMenuView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine($"Входящие сообщения: {user.IncomingMessages.Count()}");
                Console.WriteLine($"Исходящие сообщения: {user.OutcomingMessages.Count()}");

                Console.WriteLine("Посмотреть информацию о моем профиле (Нажмите 1)");
                Console.WriteLine("Редактировать профиль (Нажмите 2)");
                Console.WriteLine("Добавить в друзья (Нажмите 3)");
                Console.WriteLine("Написать сообщение (Нажмите 4)");
                Console.WriteLine("Просмотреть входящие сообщения (Нажмите 5)");
                Console.WriteLine("Просмотреть исходящие сообщения (Нажмите 6)");
                Console.WriteLine("Список друзей (Нажмите 7)");
                Console.WriteLine("Удалить пользователя из списка друзей (Нажмите 8)");
                Console.WriteLine("Выйти из профиля (Нажмите 9)");


                string keyValue = Console.ReadLine();

                if(keyValue == "9") break;

                switch (keyValue)
                {
                    case "1":
                    {
                        Program.userInfoView.Show(user); 
                        break;
                    }
                    case "2":
                    {
                        Program.userDataUpdateView.Show(user);
                        break;
                    }
                    case "3":
                    {
                        Program.friendRequestView.Show(user);
                        break;
                    }
                    case "4":
                    {
                        Program.messageSendingView.Show(user);
                        break;
                    }
                    case "5":
                    {
                        Program.userIncomingMessageView.Show(user.IncomingMessages);
                        break;
                    }
                    case "6":
                    {
                        Program.userOutcomingMessageView.Show(user);
                        break;
                    }
                    case "7":
                    {
                        Program.friendListView.Show(user);
                        break;
                    }
                    case "8":
                    {
                        Program.friendDeleteView.Show(user);
                        break;
                    }
                }
            }
        }
    }
}
