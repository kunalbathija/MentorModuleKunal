using Common;
using System;
using System.Collections.Generic;

namespace Business
{
    public class LoginManager: ILoginManager
    {
        private List<LoginModel> _logins;
        public LoginManager()
        {
            _logins = new List<LoginModel>()
            {
                new LoginModel(){username = "kunal", password = "123" },
                new LoginModel(){username = "krishna", password = "456" }
            };
        }

        public Boolean CheckLogin(LoginModel user)
        {
            LoginModel tempUser;
            tempUser = _logins.Find(x => x.username == user.username);
            if (tempUser == null)
            {
                return false;   
            }
            if(user.password == tempUser.password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
