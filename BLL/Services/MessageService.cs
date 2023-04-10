﻿using System;
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
    internal class MessageService
    {
        private IUserRepository userRepository;
        private IMessageReposytory messageReposytory;

        public MessageService()
        {
            userRepository = new UserRepository();
            messageReposytory = new MessageRepository();
        }
         
        public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
        {
            var messages = new List<Message>();

            messageReposytory.FindByRecipientId(recipientId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var recipientUserEntity = userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content,senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }

        public IEnumerable<Message> GetOutcomingMessagesByUserId(int senderId)
        {
            var messages = new List<Message>();

            messageReposytory.FindBySenderId(senderId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var recipientUserEntity = userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }

        public void SendMessage(MessageSendingData messageSendingData)
        {
            if (String.IsNullOrEmpty(messageSendingData.Content))
                throw new ArgumentNullException();

            if (messageSendingData.Content.Length > 5000)
                throw new ArgumentOutOfRangeException();

            var findUserEntity = this.userRepository.FindByEmail(messageSendingData.RecipientEmail);
            if(findUserEntity is null) 
                throw new UserNotFoundException();

            var messageEntity = new MessageEntity()
            {
                content = messageSendingData.Content,
                sender_id = messageSendingData.Sender_Id,
                recipient_id = findUserEntity.id
            };

            if (this.messageReposytory.Create(messageEntity) == 0)
                throw new Exception();

        }
    }
}
