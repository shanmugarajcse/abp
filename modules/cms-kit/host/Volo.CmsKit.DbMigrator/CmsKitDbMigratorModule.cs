using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Volo.CmsKit.DbMigrator
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(CmsKitWebUnifiedModule)
    )]
    public class CmsKitDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
