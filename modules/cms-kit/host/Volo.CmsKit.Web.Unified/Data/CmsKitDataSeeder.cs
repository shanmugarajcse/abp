using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.CmsKit.Contents;
using Volo.CmsKit.Pages;

namespace Volo.CmsKit.Data
{
    public class CmsKitDataSeeder : IDataSeedContributor, ITransientDependency
    {
        public CmsKitDataSeeder(
            IContentRepository contentRepository,
            IGuidGenerator guidGenerator)
        {
            ContentRepository = contentRepository;
            GuidGenerator = guidGenerator;
        }

        protected IContentRepository ContentRepository { get; }
        protected IGuidGenerator GuidGenerator { get; }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await ContentRepository.GetCountAsync() == 0)
            {
                _ = await ContentRepository.InsertAsync(
                    new Content(
                        GuidGenerator.Create(),
                        typeof(Page).FullName,
                        Guid.Empty.ToString(),
                        "Hello World!"));
            }
        }
    }
}
