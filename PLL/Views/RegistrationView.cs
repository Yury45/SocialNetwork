using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BAL.Models;
using SocialNetwork.BAL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    internal class RegistrationView
    {
        private UserService userService;

        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.WriteLine("Для создания нового профиля введите данные.");

            Console.WriteLine("Введите имя:");
            userRegistrationData.Firstname = Console.ReadLine();

            Console.WriteLine("Введите фамилию:");
            userRegistrationData.Lastname = Console.ReadLine();

            Console.WriteLine("Введите адрес электронной почты:");
            userRegistrationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            userRegistrationData.Password = Console.ReadLine();

            try
            {
                userService.Register(userRegistrationData);

                MessageHandler.ShowSuccessMessage("Учетная запись успешно зарегестрирована!\n");
            }
            catch (ArgumentNullException e)
            {
                MessageHandler.ShowAlertMessage("Некорректные данные.\n");
            }
            catch (Exception e)
            {
                MessageHandler.ShowAlertMessage("Ошибка регистрации!\n");
            }
        }
    }
}
