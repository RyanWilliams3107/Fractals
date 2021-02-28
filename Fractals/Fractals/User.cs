using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fractals
{
    public class User
    {
        public string Username;
        public string HashedPassword;
        public User()
        {
            Username = null;
            HashedPassword = null;
        }
        public User(string UName, string HashedPass)
        {
            this.Username = UName;
            this.HashedPassword = HashedPass;
        }
        public static bool operator ==(User First, User Second)
        {
            return (First.Username == Second.Username) && (First.HashedPassword == Second.HashedPassword);
        }
        public static bool operator !=(User First, User Second)
        {
            return (First.Username != Second.Username) && (First.HashedPassword != Second.HashedPassword);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            User comp = obj as User;

            return comp == this;
        }
        public override int GetHashCode()
        {
            return -1;
        }
    }
}
