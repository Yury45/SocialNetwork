using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories.Interfaces;

internal interface IMessageReposytory
{
    int Create(MessageEntity messageEntity);
    IEnumerable<MessageEntity> FindBySenderId(int senderId);
    IEnumerable<MessageEntity> FindByRecipientId(int recipientId);
    int DeleteById(int messageId);
}