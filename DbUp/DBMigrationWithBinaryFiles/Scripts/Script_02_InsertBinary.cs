using DbUp.Engine;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WithBinary.Scripts
{
    public class Script_02_InsertBinary : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            var payload = File.ReadAllBytes(@"Binary\logo.png");

            var querry = $@"
                INSERT INTO [dbo].[Files]
                            ([FileId],
                            [File])
                VALUES
                            (newid(),
                            @logo);";

            var cmd = dbCommandFactory();
            SqlCommand insert = new SqlCommand(querry, (SqlConnection)cmd.Connection!);
            insert.Parameters.AddWithValue("@logo", payload);
            insert.ExecuteNonQuery();

            return string.Empty;
        }
    }
}
