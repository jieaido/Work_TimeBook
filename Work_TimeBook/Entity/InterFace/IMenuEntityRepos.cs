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
        IEnumerable<MenuEntity> GetAllRootMenus();
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
    }
}
