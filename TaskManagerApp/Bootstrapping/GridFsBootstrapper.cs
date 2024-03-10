using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using TaskManagerApp.Persistence.FileStorage.Configuration;

namespace TaskManagerApp.Bootstrapping
{
    public static class GridFsBootstrapper
    {
        public static void AddGridFsBucket(this IServiceCollection services, IConfiguration configuration)
        {
            var fileStoreDatabaseConfigureation = GetGridFsConfiguration(configuration);

            var db = new MongoClient(fileStoreDatabaseConfigureation.ConnectionString).GetDatabase(fileStoreDatabaseConfigureation.DatabaseName);
            var gridFS = new GridFSBucket(db);
            services.AddSingleton<IGridFSBucket>(gridFS);
        }

        private static FileStoreDatabaseConfiguration GetGridFsConfiguration(IConfiguration configuration)
        {
            var fileStoreDatabaseConfiguration = new FileStoreDatabaseConfiguration();

            configuration.GetSection(FileStoreDatabaseConfiguration.ConfigureSectionName).Bind(fileStoreDatabaseConfiguration);

            return fileStoreDatabaseConfiguration;
        }
    }
}
