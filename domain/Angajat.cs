using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.domain
{
    public class Angajat : Entity<long>
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public Angajat(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string GetUsername()
        {
            return this.Username;
        }

        public void SetUsername(string username)
        {
            this.Username = username;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }
    }
}
