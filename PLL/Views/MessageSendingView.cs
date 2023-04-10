using SocialNetwork.BAL.Services;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    internal class MessageSendingView
    {
        MessageService messageService;
        UserService userService;

        public MessageSendingView(MessageService messageService, UserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;
        }

        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();

            Console.WriteLine("Введите почтовый адрес получателя:");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.WriteLine("Ввдиде сообщение (Не более 5000 символов):");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.Sender_Id = user.Id;

            try
            {
                messageService.SendMessage(messageSendingData);

                MessageHandler.ShowSuccessMessage("Сообщение успешно отправлено.\n");

                user = userService.FindById(user.Id);

            }
            catch (UserNotFoundException)
            {
                MessageHandler.ShowAlertMessage("Пользователь не найлен.\n");
            }
            catch (ArgumentNullException)
            {
                MessageHandler.ShowAlertMessage("Ввкдите корректное значение!\n");
            }
            catch (Exception)
            {
                MessageHandler.ShowAlertMessage("Произошла ошибка при отправке сообщения!\n");
            }
        }
    }
}
