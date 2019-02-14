using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetBL.Models;
using TweetDAL;

namespace TweetBL
{
    public class AuthenticationBL
    {
        public bool CheckPersonDetails(string userId, string password)
        {
            AuthenticationDAL authenticationDAL = new AuthenticationDAL();
            return authenticationDAL.CheckPerSonDetails(userId, password);
        }

        public bool PostPersonalDetails(PersonModel personModel)
        {
            AuthenticationDAL authenticationDAL = new AuthenticationDAL();
            return authenticationDAL.PostPersonDetails(personModel.UserId, personModel.Password, personModel.FullName, personModel.Email);
        }

        public bool SaveTweet(string userId, string msg)
        {
            AuthenticationDAL authenticationDAL = new AuthenticationDAL();
            return authenticationDAL.SaveTweet(userId, msg);
        }

        public List<TweetModel> GetTweet(string userId)
        {
            AuthenticationDAL authenticationDAL = new AuthenticationDAL();
            return TransferToTweetModel(authenticationDAL.GetTweet(userId));
        }

        private List<TweetModel> TransferToTweetModel(List<Tweet> tweet)
        {
            if (tweet != null)
                return tweet.Select(s => new TweetModel() { UserId = s.UserId, Message = s.Message, Created = s.Created }).ToList();
            else
                return null;
        }

        private PersonModel TransferToLocal(Person person)
        {
            if (person != null)
                return new PersonModel() { UserId = person.UserId, Password = person.Password, FullName = person.FullName, Joined = person.Joined, Email = person.Email, Active = person.Active };
            else
                return null;
        }
    }
}
