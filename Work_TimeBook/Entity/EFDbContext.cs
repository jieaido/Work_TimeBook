using System.Data.Entity;
using Entity.Model;

namespace Entity
{
    public class EFDbContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“EFDbContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Entity.EFDbContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“EFDbContext”
        //连接字符串。
        public EFDbContext()
            : base("name=work_TimeContext")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permiss> Permisses { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
    }

   
}