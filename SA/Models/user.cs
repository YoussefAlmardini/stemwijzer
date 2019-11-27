using System.Collections.Generic;

namespace SA.Models
{
    public class User
    {
        public bool ID { get; set; }
        public bool IsAdult { get; set; }

        public string Email { get; set; }

        public UserSession Session { get; set; }

        public User()
        {
            this.Session = new UserSession();
        }
    }

    public class UserSession
    {
        public List<UserOpinion> UserOpinion;
        public UserSession() { }

        public void Start()
        {
            UserOpinion = new List<UserOpinion>();
        }

        public void AddStandPoint(UserOpinion opinion)
        {
            this.UserOpinion.Add(opinion);
        }       

        public void Update(UserOpinion opinion)
        {
            for (int i = 0; i < UserOpinion.Count; i++)
            {
                if (UserOpinion[i].stand == opinion.stand)
                {
                    UserOpinion[i].userOpinion = opinion.userOpinion;
                }
            }
        }

        public bool IsExist(Stand currentStand)
        {
            bool condition = false;

            for(int i = 0; i < UserOpinion.Count; i++)
            {
                if(UserOpinion[i].stand == currentStand)
                {
                    condition = true;
                }
            }

            return condition;
        }
    }
}
