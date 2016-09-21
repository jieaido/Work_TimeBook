using Entity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helper
{
  public  static class UserHelper
    {

      public static int GetUserinfoId()
      {
            
            var formsIdentity = HttpContext.Current.User.Identity as FormsIdentity;
            int id = Convert.ToInt32(formsIdentity.Ticket.UserData);
            return id;
      }
        
    }
}

