using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.DAL.Repositories.Interfaces;
using SocialNetwork.DAL.Repository;
using SocialNetwork.DAL.Repository.Interfaces;

namespace SocialNetwork.BLL.Services
{
    internal class FriendService
    {
        private IUserRepository userRepository;
        private IFriendRepository friendRepository;

        public FriendService()
        {
            this.userRepository = new UserRepository();
            this.friendRepository = new FriendRepository();
        }

        public void SendFriendRequest(FriendRequestData friendRequestData)
        {
            if (String.IsNullOrEmpty(friendRequestData.AcceptorEmail)) 
                throw new ArgumentNullException();

            var findFriendEntity = this.userRepository.FindByEmail(friendRequestData.AcceptorEmail);

            if(findFriendEntity is null) 
                throw new ArgumentNullException();

            var friendEntityRequestor = new FriendEntity()
            {
                user_id = userRepository.FindByEmail(friendRequestData.RequestorEmail).id,
                friend_id = findFriendEntity.id
            };

            var friendEntityAcceptor = new FriendEntity()
            {
                user_id = findFriendEntity.id,
                friend_id = userRepository.FindByEmail(friendRequestData.RequestorEmail).id
            };

            if (friendRepository
                    .FindAllByUserId(friendEntityRequestor.user_id)
                    .Any(f => f.friend_id == friendEntityRequestor.friend_id) ||
                friendRepository
                    .FindAllByUserId(friendEntityAcceptor.user_id)
                    .Any(f => f.friend_id == friendEntityAcceptor.friend_id))
                throw new ArgumentNullException();

                if (this.friendRepository.Create(friendEntityRequestor) == 0)
                    throw new Exception();
            if (this.friendRepository.Create(friendEntityAcceptor) == 0)
                throw new Exception();
        }

        public IEnumerable<Friend> GetFriends(int userId)
        {
            List<Friend> friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var requestorUserEntity = userRepository.FindById(f.user_id);
                var acceptorUserEntity = userRepository.FindById(f.friend_id);

                friends.Add(new Friend(f.id, f.user_id, f.friend_id, acceptorUserEntity.email, requestorUserEntity.email ));
            });

            return friends;
        }

        public void ShowFriends(int userId)
        {
            List<Friend> friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var requestorUserEntity = userRepository.FindById(f.user_id);
                var acceptorUserEntity = userRepository.FindById(f.friend_id);

                friends.Add(new Friend(f.id, f.user_id, f.friend_id, acceptorUserEntity.email, requestorUserEntity.email ));
            });

            if (friends.Count > 0)
            {
                Console.WriteLine("Друзья: ");
                foreach (var friend in friends)
                {
                    Console.WriteLine($"{friend.userEmail}");
                }
            }
            else
            {
                Console.WriteLine("Список друзей пуст.");
            }
        }

        public void DeleteFriend(FriendRequestData friendRequestData)
        {
            if (String.IsNullOrEmpty(friendRequestData.AcceptorEmail)) throw new ArgumentNullException();

            var userDeleteRequestor = userRepository.FindByEmail(friendRequestData.RequestorEmail);
            if (userDeleteRequestor is null) throw new UserNotFoundException();

            var userDeleteAcceptor = userRepository.FindByEmail(friendRequestData.AcceptorEmail);
            if(userDeleteAcceptor is null) throw new UserNotFoundException(); 

            var friendEntityDeleteRequestor = friendRepository
                .FindAllByUserId(userDeleteRequestor.id).FirstOrDefault(f => f.friend_id == userDeleteAcceptor.id);

            var friendEntityDeleteAcceptor = friendRepository
                .FindAllByUserId(userDeleteAcceptor.id).FirstOrDefault(f => f.friend_id == userDeleteRequestor.id);

            if (friendEntityDeleteAcceptor is null) throw new UserNotFoundException();

            if (this.friendRepository.Delete(friendEntityDeleteAcceptor.id) == 0) throw new Exception();

            if (friendEntityDeleteRequestor is null) throw new UserNotFoundException();

            if (this.friendRepository.Delete(friendEntityDeleteRequestor.id) == 0) throw new Exception();

        }
    }
}