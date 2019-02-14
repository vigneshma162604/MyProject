using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetDAL
{
    public class AuthenticationDAL
    {
        public bool CheckPerSonDetails(string userId = "", string password = "")
        {
            try
            {
                using (TweeterAppEntities tweetEntity = new TweeterAppEntities())
                {
                    ObjectParameter objectParam = new ObjectParameter("Result", typeof(Int32));
                    var value = tweetEntity.Fun_SP_GetPerson(userId, password, objectParam).ToList();
                    if (objectParam.Value.Equals(1))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool PostPersonDetails(string userId, string password, string fullName, string email)
        {
            try
            {
                using (TweeterAppEntities tweetEntity = new TweeterAppEntities())
                {
                    ObjectParameter objectParam = new ObjectParameter("Result", typeof(Int32));
                    var value = tweetEntity.Fun_SP_CreatPerson(userId, password, fullName, email, objectParam).ToList();
                    if (objectParam.Value.Equals(1))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SaveTweet(string userId, string msg)
        {
            try
            {
                using (TweeterAppEntities tweetEntity = new TweeterAppEntities())
                {
                    ObjectParameter objectParam = new ObjectParameter("Result", typeof(Int32));
                    var value = tweetEntity.Fun_SP_SaveTweet(userId, msg, objectParam).ToList();
                    if (objectParam.Value.Equals(1))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Tweet> GetTweet(string userId)
        {
            try
            {
                using (TweeterAppEntities tweetEntity = new TweeterAppEntities())
                {
                    //ObjectParameter objectParam = new ObjectParameter("Fun_SP_GetTweet_Result", typeof(Tweet));
                    var value = tweetEntity.Fun_SP_GetTweet(userId).ToList();
                    if (value != null)
                        return value.Select(s => new Tweet() { UserId = s.UserId, Message = s.Message, Created = s.Created }).ToList();
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
