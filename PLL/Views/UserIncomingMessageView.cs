using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BAL.Services;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    internal class UserIncomingMessageView
    {
        private UserService userService;

        public UserIncomingMessageView(MessageService messageService, UserService userService)
        {
            this.userService = userService;
        }

        public void Show(IEnumerable<Message> userIncomingMessages)
        {
            Console.WriteLine("Список входящих сообщений:");

            if (userIncomingMessages.Count() != 0)
            {

                foreach (var message in userIncomingMessages)
                {
                    Console.WriteLine($"{userService.FindByEmail(message.SenderEmail).Firstname}: {message.Content}");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Входящие сообщения отсутствуют.\n");
            }
        }
    }
}
