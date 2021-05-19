using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public int Level { get; set; }
        public int Progress { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User(string login, string password, int level, int progress)
        {
            Login = login;
            Password = password;
            Level = level;
            Progress = progress;
        }
    }
}
