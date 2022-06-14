using PetaPoco;
using PetaPoco.Providers;
namespace BookMyShow_BE.Services.Shared_Db
{
    public class sharedDb
    {
        private readonly IDatabase db;
        public sharedDb()
        {
            db = DatabaseConfiguration.Build()
                     .UsingConnectionString("Data Source=.\\sqlexpress;Initial Catalog=BookMyShow;Integrated Security=True")
                     .UsingProvider<SqlSererMsDataDatabaseProvider>()
                     .Create();
        }

        public IDatabase getDb()
        {
            return db;
        }
    }
}
