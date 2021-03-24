using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface ILoginManager
    {
        bool CheckLogin(LoginModel user);
    }
}
