using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BAL.Services;
using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    internal class UserDataUpdateView
    {
        private UserService userService;

        public UserDataUpdateView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            Console.WriteLine("Введите новые данные");

            Console.WriteLine("Имя: ");
            user.Firstname = Console.ReadLine();

            Console.WriteLine("Фамилия: ");
            user.Lastname = Console.ReadLine();

            Console.WriteLine("Любимая книга: ");
            user.FavoriteBook = Console.ReadLine();

            Console.WriteLine("Любимый фильм:");
            user.FavoriteMovie = Console.ReadLine();

            Console.WriteLine("Ссылка на фото: ");
            user.Photo = Console.ReadLine();

            Console.WriteLine("Новый пароль: ");
            user.Password = Console.ReadLine();

            try
            {
                userService.Update(user);

                MessageHandler.ShowSuccessMessage("Успех. Информация изменена!\n");
            }
            catch (NullReferenceException e)
            {
                MessageHandler.ShowAlertMessage("Некорректные данные.\n");
            }
            catch (Exception e)
            { 
                MessageHandler.ShowAlertMessage("Ошибка изменений данных.\n");
            }

        }
    }
}
