using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    internal class MainView
    {
        public void Show()
        {
            Console.WriteLine("Войти в профиль (Нажмите 1):");
            Console.WriteLine("Зарегестрировать пользователя (Нажмите 2):");

            switch (Console.ReadLine())
            {
                case "1":
                {
                    Program.autenticationView.Show();
                    break;
                }
                case "2":
                {
                    Program.registrationView.Show();
                    break;
                }
            }
        }
    }
}
