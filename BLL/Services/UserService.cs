using System.ComponentModel.DataAnnotations;
using SocialNetwork.BAL.Models;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repository;
using SocialNetwork.DAL.Repository.Interfaces;

namespace SocialNetwork.BAL.Services
{
    internal class UserService
    {
        private IUserRepository userRepository;
        private MessageService messageService;
        private FriendService friendService;

        public UserService()
        {
            userRepository = new UserRepository();
            messageService = new MessageService();
            friendService = new FriendService();
        }

        public void Register(UserRegistrationData userRegistrationData)
        {

            if (!CheckFirstname(userRegistrationData.Firstname)) throw new ArgumentNullException();

            if (!CheckLastname(userRegistrationData.Lastname)) throw new ArgumentNullException();

            if (!CheckEmail(userRegistrationData.Email)) throw new ArgumentNullException();

            if (!CheckPassword(userRegistrationData.Password)) throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.Firstname,
                lastname = userRegistrationData.Lastname,
                email = userRegistrationData.Email,
                password = userRegistrationData.Password
            };

            if (this.userRepository.Create(userEntity) == 0)
                throw new Exception();
        }

        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessage = messageService.GetIncomingMessagesByUserId(userEntity.id);

            var outcomingMessage = messageService.GetOutcomingMessagesByUserId(userEntity.id);

            return new User(userEntity.id,
                userEntity.firstname,
                userEntity.lastname,
                userEntity.email,
                userEntity.password,
                userEntity.photo,
                userEntity.favorite_movie,
                userEntity.favorite_book,
                incomingMessage,
                outcomingMessage);
        }

        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);

            if (findUserEntity is null)
                throw new ArgumentNullException();

            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindByEmail(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);

            if (findUserEntity is null) throw new ArgumentNullException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindById(int id)
        {
            var findUserEntity = userRepository.FindById(id);

            if (findUserEntity is null) throw new ArgumentNullException();

            return ConstructUserModel(findUserEntity);
        }

        public void Update(User user)
        {

            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.Firstname,
                lastname = user.Lastname,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_book = user.FavoriteBook,
                favorite_movie = user.FavoriteMovie
            };

            if (!CheckFirstname(updatableUserEntity.firstname)) throw new ArgumentNullException();

            if (!CheckLastname(updatableUserEntity.lastname)) throw new ArgumentNullException();

            if(!CheckPassword(updatableUserEntity.password)) throw new ArgumentNullException();

            if (this.userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }

        #region Checks

        private bool CheckPassword(string password)
        {
            if (password.Length >= 8
                  && password.Any(char.IsLetter)
                  && password.Any(char.IsDigit)
                  && password.Any(char.IsPunctuation)
                  && password.Any(char.IsUpper)
                  && password.Any(char.IsLower))
            {
                Console.WriteLine("Введите пароль повторно: ");
                return (Equals(password, Console.ReadLine()));
            }

            return false;
        }

        private bool CheckFirstname(string firstname) => !String.IsNullOrEmpty(firstname);

        private bool CheckLastname(string lastname) => !String.IsNullOrEmpty(lastname);

        private bool CheckEmail(string email)
        {
            return !String.IsNullOrEmpty(email) && new EmailAddressAttribute().IsValid(email) && userRepository.FindByEmail(email) == null;
        }

        #endregion
    }
}
