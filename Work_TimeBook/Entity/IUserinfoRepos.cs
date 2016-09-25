using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;

namespace Entity
{
    public interface IUserinfoRepos : IBaseRepos<UserInfoEntity>
    {
        IEnumerable<UserInfoEntity> UserInfos { get; }
        int ValiteLoginInfo(string loginname, string loginpwd);

        UserInfoEntity DeleteUserinfo(UserInfoEntity userInfoEntity);
        bool ExistUserName(string userName);
        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserInfoEntity GetUserInfoById(int id);
    }

  public   class UserinfoRepos : BaseRepos<UserInfoEntity>, IUserinfoRepos 
    {
      

        public UserinfoRepos(EFDbContext context) : base(context)
        {

        }

        public IEnumerable<UserInfoEntity> UserInfos => _Context.UserInfos;

      /// <summary>
        /// 验证登录信息
        /// </summary>
        /// <param name="loginname">用户名</param>
        /// <param name="loginpwd">用户密码</param>
        /// <returns>未找到用户返回-1.找到后返回用户id</returns>
      public int ValiteLoginInfo(string loginname, string loginpwd)
      {
          var userinfo = UserInfos.FirstOrDefault(u => u.LoginName == loginname && u.LoginPwd == loginpwd);
          if (userinfo != null)
          {
              return userinfo.UserInfoEntityId;
          }

          return -1;
      }
        
      public UserInfoEntity DeleteUserinfo(UserInfoEntity userInfoEntity)
      {
         return _Context.UserInfos.Remove(userInfoEntity);
      }

      public bool ExistUserName(string userName)
      {
          return UserInfos.Any(m => m.LoginName == userName);
      }

      public UserInfoEntity GetUserInfoById(int id)
      {
          return UserInfos.FirstOrDefault(u => u.UserInfoEntityId == id);
      }
        
     
    }
}
