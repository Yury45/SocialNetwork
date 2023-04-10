using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BAL.Services;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    internal class UserOutcomingMessageView
    {
        private MessageService messageService;

        public UserOutcomingMessageView(MessageService messageService)
        {
            this.messageService = messageService;
        }
        public void Show(User user)
        {
            var messages = messageService.GetOutcomingMessagesByUserId(user.Id);

            if (messages.Count() != null)
            {
                foreach (var message in messages)
                {
                    Console.WriteLine($"Отправлено для {message.RecipientEmail}: {message.Content}\n");
                }
            }
            else
            {
                Console.WriteLine("Исходящих сообщений нет.\n");
            }
        }
    }
}
