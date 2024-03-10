namespace TaskManagerApp.Persistence.FileStorage.Configuration
{
    public class FileStoreDatabaseConfiguration
    {
        public static string ConfigureSectionName  = "FileStoreDatabase";

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
