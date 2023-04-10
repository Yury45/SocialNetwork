using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    internal class UserInfoView
    {
        public void Show(User user)
        {
            Console.WriteLine("Информация о пользователе:");
            Console.WriteLine($"Имя: {user.Firstname}");
            Console.WriteLine($"Фамилия: {user.Lastname}");
            Console.WriteLine($"Почта: {user.Email}");
            Console.WriteLine($"Любимая книга: {user.FavoriteBook}");
            Console.WriteLine($"любимый фильм: {user.FavoriteMovie}");
            Console.WriteLine($"Фото: {user.Photo}\n");

        }
    }
}
