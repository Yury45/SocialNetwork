using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BAL.Services;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    internal class AutenticationView
    {
        UserService userService;

        public AutenticationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var autenticationData = new UserAuthenticationData();

            Console.WriteLine("Введите почту:");
            autenticationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            autenticationData.Password = Console.ReadLine();

            try
            {
                var user = userService.Authenticate(autenticationData);

                MessageHandler.ShowSuccessMessage($"Вы успешно вошли в сеть!\n" +
                                                  $"Добро пожаловать, {user.Firstname}");

                Program.userMenuView.Show(user);
            }
            catch (WrongPasswordException e)
            {
                MessageHandler.ShowAlertMessage("Неверный пароль!\n");
            }
            catch (UserNotFoundException e)
            {
                MessageHandler.ShowAlertMessage("Пользователь не найден!\n");
            }
            catch(Exception e)
            {
                MessageHandler.ShowAlertMessage("Ошибка операции.");
            }
        }
    }
}
