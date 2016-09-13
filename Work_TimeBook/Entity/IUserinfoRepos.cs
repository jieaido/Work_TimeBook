﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;

namespace Entity
{
    public interface IUserinfoRepos
    {
        IEnumerable<UserInfo> UserInfos { get; }
        int ValiteLoginInfo(string loginname, string loginpwd);
    }

  public   class UserinfoRepos : IUserinfoRepos
    {
        private EFDbContext _context=new EFDbContext();
      public IEnumerable<UserInfo> UserInfos
      {
          get { return _context.UserInfos; }
      }

      public int ValiteLoginInfo(string loginname, string loginpwd)
      {
          var userinfo = UserInfos.FirstOrDefault(u => u.LoginName == loginname && u.LoginPwd == loginpwd);
          if (userinfo != null)
          {
              return userinfo.UserInfoId;
          }
          else return -1;

      }

      public void AddorUpdate(UserInfo userInfo)
      {
           _context.UserInfos.AddOrUpdate(userInfo);
      }

      public UserInfo DeleteUserinfo(UserInfo userInfo)
      {
         return _context.UserInfos.Remove(userInfo);
      }
    }
}
