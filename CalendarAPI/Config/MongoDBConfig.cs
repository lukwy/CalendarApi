namespace CalendarAPI.Config
{
    public class MongoDBConfig
    {
        public string ConnectionString 
        { 
            get 
            {
                return $@"mongodb://{Environment.GetEnvironmentVariable("DB_HOST")}:{Environment.GetEnvironmentVariable("DB_PORT")}";
            } 
        }

        public string DatabaseName => Environment.GetEnvironmentVariable("DB_NAME");
    }
}
