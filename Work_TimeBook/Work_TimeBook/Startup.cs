using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Work_TimeBook.Startup))]
namespace Work_TimeBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
