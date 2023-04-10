using SocialNetwork.BAL.Models;
using SocialNetwork.BAL.Services;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    class Program
    {
        static UserService userService;
        private static MessageService messageService;
        private static FriendService friendService;

        public static AutenticationView autenticationView;
        public static FriendDeleteView friendDeleteView;
        public static FriendListView friendListView;
        public static FriendRequestView friendRequestView;
        public static MainView mainView;
        public static MessageSendingView messageSendingView;
        public static RegistrationView registrationView;
        public static UserDataUpdateView userDataUpdateView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserInfoView userInfoView;
        public static UserMenuView userMenuView;
        public static UserOutcomingMessageView userOutcomingMessageView;


        
        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();
            friendService = new FriendService();

            autenticationView = new AutenticationView(userService);
            friendDeleteView = new FriendDeleteView(friendService);
            friendListView = new FriendListView(friendService);
            friendRequestView = new FriendRequestView(userService, friendService);
            mainView = new MainView();
            messageSendingView = new MessageSendingView(messageService, userService);
            registrationView = new RegistrationView(userService);
            userDataUpdateView = new UserDataUpdateView(userService);
            userIncomingMessageView = new UserIncomingMessageView(messageService, userService);
            userInfoView = new UserInfoView();
            userMenuView = new UserMenuView(userService);
            userOutcomingMessageView = new UserOutcomingMessageView(messageService);

            while (true)
            {
                mainView.Show();
            }

        }
    }
}