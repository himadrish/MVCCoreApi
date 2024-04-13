namespace MVCCoreApiMovie.Models
{
    public class MovieDBSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string DBCollectionName { get; set; } = null!;
    }
}
