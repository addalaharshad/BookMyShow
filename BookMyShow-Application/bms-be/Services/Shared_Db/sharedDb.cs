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
                     .UsingDefaultMapper<ConventionMapper>(m =>
                     {
                         m.InflectTableName = (inflector, s) => inflector.Pluralise(inflector.Underscore(s));
                         m.InflectColumnName = (inflector, s) => inflector.Underscore(s);
                     })
                     .Create();
        }

        public IDatabase getDb()
        {
            return db;
        }
    }
}
