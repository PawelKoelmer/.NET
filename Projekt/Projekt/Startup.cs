using Hangfire;
using Owin;


namespace Projekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.UseSqlServerStorage("Shop");
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}