using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string FavoriteMovie { get; set; }
        public string FavoriteBook { get; set; }
        public IEnumerable<Message> IncomingMessages { get; }
        public IEnumerable<Message> OutcomingMessages { get; }
         
        public User(int id, string firstname, string lastname, string email, string password, string photo, string favoriteMovie,
                    string favoriteBook, IEnumerable<Message> incomingMessages, IEnumerable<Message> outcomingMessages)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.Password = password;
            this.Photo = photo;
            this.FavoriteMovie = favoriteMovie;
            this.FavoriteBook = favoriteBook;

            this.IncomingMessages = incomingMessages;
            this.OutcomingMessages = outcomingMessages;
        }
    }
}
