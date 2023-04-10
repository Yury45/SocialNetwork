﻿using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories.Interfaces;
using SocialNetwork.DAL.Repository;

namespace SocialNetwork.DAL.Repositories
{
    internal class FriendRepository : BaseRepository , IFriendRepository 
    {
        public int Create(FriendEntity friendEntity)
        {
            return Execute(@"insert into friends (user_id,friend_id)
                                values (:user_id,:friend_id)",
                                friendEntity);
        }

        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            return Query<FriendEntity>(@"select * from friends
                                            where user_id = :user_id", 
                                  new { user_id = userId });
        }

        public int Delete(int id)
        {
            return Execute(@"delete from friends
                                where id = :id_p", 
                      new { id_p = id });
        }
    }
}
