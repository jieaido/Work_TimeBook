using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;

namespace Entity.InterFace
{
    public interface IMenuEntityRepos:IBaseRepos<MenuEntity>
    {
        /// <summary>
        /// 获取所有主节点
        /// </summary>
        /// <returns></returns>
        IEnumerable<MenuEntity> GetAllRootMenus();
        /// <summary>
        /// 根据id获取该menu的所有叶子节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<MenuEntity> GetAllLeafMenus(int id);
        /// <summary>
        /// 根据id删除所有的子节点
        /// </summary>
        /// <param name="id"></param>
        void DeleteLeafMenu(int id );
        /// <summary>
        /// 根据id删除所有的子节点及自身
        /// </summary>
        /// <param name="id"></param>
        void DeleteLeadMenuAndSelf(int id );

    }
    public class MenuEntityRepos:BaseRepos<MenuEntity>,IMenuEntityRepos
    {
        public MenuEntityRepos(EFDbContext context) : base(context)
        {
        }

        public IEnumerable<MenuEntity> GetAllRootMenus()
        {
           return  GetSet().Where(m => m.ParentMenuId == -1).OrderBy(m => m.SortId);
        }

        public IEnumerable<MenuEntity> GetAllLeafMenus(int id)
        {
            var result = from menuEntity in GetSet() where menuEntity.ParentMenuId == id select menuEntity;
            return result;

        }

        public void DeleteLeafMenu(int id)
        {
            GetSet().RemoveRange(GetAllLeafMenus(id));
        }

        public void DeleteLeadMenuAndSelf(int id)
        {
           
            DeleteLeafMenu(id);
            Delete(Where(m => m.MenuEntityId == id).FirstOrDefault());
        }
        
    }
}
