using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class account
    {
        public string username;

        public string Username 
        {
            get { return username; }
            set { username = value; }
        }
        public string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string fullname;

        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
        public string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public DateTime dob;

        public DateTime DOB
        {
            get { return dob; }
            set { dob = value; }
        }
        public bool gender;

        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public bool role;

        public bool Role
        {
            get { return role; }
            set { role = value; }
        }

        public account(string username, string password, string fullname, string email, DateTime dob, bool gender, bool role)
        {
            this.username = username;
            this.password = password;
            this.fullname = fullname;
            this.email = email;
            this.dob = dob;
            this.gender = gender;
            this.role = role;
        }
        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public account()
        {
        }
    }
}