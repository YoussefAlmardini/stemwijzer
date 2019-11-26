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
        public List<Points> points { get; set; }

        public UserSession() { }
        public void Start()
        {
            points = new List<Points>();

        }
    }
}
