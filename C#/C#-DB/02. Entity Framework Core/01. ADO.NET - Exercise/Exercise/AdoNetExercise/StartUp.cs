namespace AdoNetExercise
{
    using System.Text;

    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        /*
        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(Config.ConnectionString);
            connection.Open();

            //using (connection) { }

            Console.WriteLine("Connected to Db...");
        }
        */

        static async Task Main(string[] args)
        {
            // In .NET 6 ToString() is working properly
            // If you are using 'using' operator, you will not need to call Close() explicitely
            // If you are not using 'using' -> Close()/Dispose()

            await using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            await sqlConnection.OpenAsync();


            // Problem 02 ----------------------------------------------------------------------

            //string result = await GetAllVillainsWithTheirMinionsAsync(sqlConnection);
            //Console.WriteLine(result);


            // Problem 03 ----------------------------------------------------------------------

            //int villainId = int.Parse(Console.ReadLine());
            //string result = await GetVillainsWithAllMinionsByIdAsync(sqlConnection, villainId);
            //Console.WriteLine(result);


            // Problem 04 ----------------------------------------------------------------------

            //string[] minionArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            //string[] villainArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            //string result = await AddNewMinionAsync(sqlConnection, minionArgs[1], villainArgs[1]);
            //Console.WriteLine(result);


            // Problem 05 ----------------------------------------------------------------------

            //string countryName = Console.ReadLine();
            //string result = await ChangeTownNamesCasingAsync(sqlConnection, countryName);
            //Console.WriteLine(result);


            // Problem 06 ----------------------------------------------------------------------

            //int villainId = int.Parse(Console.ReadLine());
            //string result = await RemoveVillainByIdAndReleaseHisMinionsAsync(sqlConnection, villainId);
            //Console.WriteLine(result);


            // Problem 07 ----------------------------------------------------------------------

            //string result = await PrintAllMinionsNamesAsync(sqlConnection);
            //Console.WriteLine(result);


            // Problem 08 ----------------------------------------------------------------------

            //int[] minionIds = Console.ReadLine()
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();
            //string result = await UpdateMinionsByIdAsync(sqlConnection, minionIds);
            //Console.WriteLine(result);


            // Problem 09 ----------------------------------------------------------------------

            //int id = int.Parse(Console.ReadLine());
            //string result = await IncreaseMinionAgeStoredProcedureAsync(sqlConnection, id);
            //Console.WriteLine(result);
        }


        // Problem 02. Villain Names
        static async Task<string> GetAllVillainsWithTheirMinionsAsync(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand sqlCommand = new SqlCommand(SqlQueries.GetAllVillainsAndCountOfTheirMinions, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
            while (reader.Read())
            {
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }


        // Problem 03. Minion Names
        static async Task<string> GetVillainsWithAllMinionsByIdAsync(SqlConnection sqlConnection, int villainId)
        {
            // SQL Injection Prevention -> Using SqlParameters
            // One row with one column -> ExecuteScalar
            SqlCommand getVillainNameCmd = new SqlCommand(SqlQueries.GetVillainNameById, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            object? villainNameObj = await getVillainNameCmd.ExecuteScalarAsync();
            if (villainNameObj == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            string villainName = (string)villainNameObj;

            // Use SqlParameters
            // ExecuteReader() -> Many rows with many columns
            SqlCommand getAllMinionsCmd = new SqlCommand(SqlQueries.GetAllMinionsByVillainId, sqlConnection);
            getAllMinionsCmd.Parameters.AddWithValue("@Id", villainId);
            SqlDataReader minionsReader = await getAllMinionsCmd.ExecuteReaderAsync();
            string output = GenerateVillainWithMinionsOutput(villainName, minionsReader);

            return output;
        }

        private static string GenerateVillainWithMinionsOutput(string villainName, SqlDataReader minionsReader)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Villain: {villainName}");
            if (!minionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long rowNum = (long)minionsReader["RowNum"];
                    string minionName = (string)minionsReader["Name"];
                    int minionAge = (int)minionsReader["Age"];

                    sb.AppendLine($"{rowNum}. {minionName} {minionAge}");
                }
            }

            return sb.ToString().TrimEnd();
        }


        // Problem 04. Add Minion
        static async Task<string> AddNewMinionAsync(SqlConnection sqlConnection, string minionInfo, string villainName)
        {
            StringBuilder sb = new StringBuilder();

            string[] minionArg = minionInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string minionName = minionArg[0];
            int minionAge = int.Parse(minionArg[1]);
            string townName = minionArg[2];

            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                int townId = await GetTownIdOrAddByNameAsync(sqlConnection, sqlTransaction, sb, townName);
                int villainId = await GetVillainIdOrAddByNameAsync(sqlConnection, sqlTransaction, sb, villainName);
                int minionId = await AddNewMinionAndReturnIdAsync(sqlConnection, sqlTransaction, minionName, minionAge, townId);

                await SetMinionToBeSubjectOfVillainAsync(sqlConnection, sqlTransaction, minionId, villainId);

                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                await sqlTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await sqlTransaction.RollbackAsync();
                sb.AppendLine($"Transaction Failed! - {ex.Message}");
            }

            return sb.ToString().TrimEnd();
        }

        private static async Task<int> GetTownIdOrAddByNameAsync(SqlConnection sqlConnection, SqlTransaction transaction, StringBuilder sb, string townName)
        {
            SqlCommand getTownIdCmd = new SqlCommand(SqlQueries.GetTownIdByName, sqlConnection, transaction);
            getTownIdCmd.Parameters.AddWithValue("@townName", townName);

            object? townIdObj = await getTownIdCmd.ExecuteScalarAsync();
            if (townIdObj == null)
            {
                SqlCommand addNewTownCmd = new SqlCommand(SqlQueries.AddNewTown, sqlConnection, transaction);
                addNewTownCmd.Parameters.AddWithValue("@townName", townName);

                // Add the town command
                await addNewTownCmd.ExecuteNonQueryAsync();

                // Take the ID of the newly added town
                townIdObj = await getTownIdCmd.ExecuteScalarAsync();

                sb.AppendLine($"Town {townName} was added to the database.");
            }

            return (int)townIdObj;
        }

        private static async Task<int> GetVillainIdOrAddByNameAsync(SqlConnection sqlConnection, SqlTransaction transaction, StringBuilder sb, string villainName)
        {
            SqlCommand getVillainIdCmd = new SqlCommand(SqlQueries.GetVillainIdByName, sqlConnection, transaction);
            getVillainIdCmd.Parameters.AddWithValue("@Name", villainName);

            int? villainId = (int?)await getVillainIdCmd.ExecuteScalarAsync();
            if (!villainId.HasValue)
            {
                SqlCommand addNewVillainCmd = new SqlCommand(SqlQueries.AddNewVillainWithDefaultEvilnessFactor, sqlConnection, transaction);
                addNewVillainCmd.Parameters.AddWithValue("@villainName", villainName);

                // Add new villian to the db
                await addNewVillainCmd.ExecuteNonQueryAsync();

                // Find the ID of the newly created villain
                villainId = (int?)await getVillainIdCmd.ExecuteScalarAsync();

                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId.Value;
        }

        private static async Task<int> AddNewMinionAndReturnIdAsync(SqlConnection sqlConnection, SqlTransaction transaction, string minionName, int minionAge, int townId)
        {
            SqlCommand addMinionCmd = new SqlCommand(SqlQueries.AddNewMinion, sqlConnection, transaction);
            addMinionCmd.Parameters.AddWithValue("@name", minionName);
            addMinionCmd.Parameters.AddWithValue("@age", minionAge);
            addMinionCmd.Parameters.AddWithValue("@townId", townId);

            // Add new minion
            await addMinionCmd.ExecuteScalarAsync();

            // Find Id of the newly created minion
            SqlCommand getMinionIdCmd = new SqlCommand(SqlQueries.GetMinionIdByName, sqlConnection, transaction);
            getMinionIdCmd.Parameters.AddWithValue("@Name", minionName);

            int minionId = (int)await getMinionIdCmd.ExecuteScalarAsync();

            return minionId;
        }

        private static async Task SetMinionToBeSubjectOfVillainAsync(SqlConnection sqlConnection, SqlTransaction transaction, int minionId, int villainId)
        {
            SqlCommand addMinionVillainCmd = new SqlCommand(SqlQueries.SetMinionToBeSubjectOfVillain, sqlConnection, transaction);
            addMinionVillainCmd.Parameters.AddWithValue("@minionId", minionId);
            addMinionVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            await addMinionVillainCmd.ExecuteScalarAsync();
        }


        // Problem 05. Change Town Names Casing
        private static async Task<string> ChangeTownNamesCasingAsync(SqlConnection sqlConnection, string countryName)
        {
            var updateCmd = new SqlCommand(SqlQueries.UpdateTownNamesQuery, sqlConnection);
            updateCmd.Parameters.AddWithValue("@countryName", countryName);
            var affectedRows = await updateCmd.ExecuteNonQueryAsync();

            if (affectedRows == 0)
            {
                return "No town names were affected.";
            }
            else
            {
                Console.WriteLine($"{affectedRows} town names were affected.");

                using var selectCmd = new SqlCommand(SqlQueries.SelectTownNamesQuery, sqlConnection);
                selectCmd.Parameters.AddWithValue("@countryName", countryName);

                using (var reader = selectCmd.ExecuteReader())
                {
                    var towns = new List<string>();

                    while (reader.Read())
                    {
                        towns.Add((string)reader[0]);
                    }

                    return $"[{String.Join(", ", towns)}]";
                }
            }
        }


        // Problem 06. *Remove Villain
        static async Task<string> RemoveVillainByIdAndReleaseHisMinionsAsync(SqlConnection connection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // FindVillainNameById
                using var sqlFindVillainNameByIdCmd = new SqlCommand(SqlQueries.GetVillainNameByIdQuery, connection, transaction);
                sqlFindVillainNameByIdCmd.Parameters.AddWithValue("@villainId", villainId);
                var villainName = (string)await sqlFindVillainNameByIdCmd.ExecuteScalarAsync();

                if (villainName == null)
                {
                    return "No such villain was found.";
                }

                // DeleteMinionsVillain
                using var sqlDeleteMinionsVillainCmd = new SqlCommand(SqlQueries.DeleteMinionsFromServiceByVillainIdQuery, connection, transaction);
                sqlDeleteMinionsVillainCmd.Parameters.AddWithValue("@villainId", villainId);
                int affectedRows = await sqlDeleteMinionsVillainCmd.ExecuteNonQueryAsync();

                // DeleteVillainById
                using var sqlDeleteVillainByIdCmd = new SqlCommand(SqlQueries.DeleteVillainByIdQuery, connection, transaction);
                sqlDeleteVillainByIdCmd.Parameters.AddWithValue("@villainId", villainId);
                await sqlDeleteVillainByIdCmd.ExecuteNonQueryAsync();

                // Output
                sb.AppendLine($"{villainName} was deleted.");
                sb.AppendLine($"{affectedRows} minions were released.");

                // Commit Transaction
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                sb.AppendLine($"Transaction Failed! - {ex.Message}");
            }

            return sb.ToString().TrimEnd();
        }


        // Problem 07. Print All Minion Names
        static async Task<string> PrintAllMinionsNamesAsync(SqlConnection connection)
        {
            SqlCommand selectAllMinionsCmd = new SqlCommand(SqlQueries.GetAllMinionsNamesQuery, connection);

            List<string> minionNames = new List<string>();

            using (SqlDataReader reader = await selectAllMinionsCmd.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    minionNames.Add(((string)reader[0]).Trim());
                }
            }

            StringBuilder sb = new StringBuilder();
            int count = minionNames.Count;
            int midIndex = count % 2 == 0 ? count / 2 : count / 2 + 1;

            for (int i = 0; i < midIndex; i++)
            {
                int backIndex = count - 1 - i;
                sb.AppendLine(minionNames[i]);
                if (i == backIndex)
                {
                    break;
                }
                sb.AppendLine(minionNames[backIndex]);
            }

            return sb.ToString().TrimEnd();
        }


        // Problem 08. Increase Minion Age
        static async Task<string> UpdateMinionsByIdAsync(SqlConnection connection, int[] ids)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int id in ids)
            {
                SqlCommand updateCmd = new SqlCommand(SqlQueries.UpdateMinionsByIdQuery, connection);
                updateCmd.Parameters.AddWithValue("@Id", id);
                await updateCmd.ExecuteNonQueryAsync();
            }

            using SqlCommand selectMinionsCmd = new SqlCommand(SqlQueries.SelectMinionsNameAndAgeQuery, connection);
            using SqlDataReader reader = await selectMinionsCmd.ExecuteReaderAsync();
            while (reader.Read())
            {
                sb.AppendLine($"{reader[0]} {reader[1]}");
            }

            return sb.ToString().TrimEnd();
        }


        // Problem 09. Increase Age Stored Procedure
        private static async Task<string> IncreaseMinionAgeStoredProcedureAsync(SqlConnection sqlConnection, int id)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand execGetOlderCmd = new SqlCommand(SqlQueries.ExecuteGetOlderQuery, sqlConnection);
            execGetOlderCmd.Parameters.AddWithValue("@Id", id);
            await execGetOlderCmd.ExecuteNonQueryAsync();

            using SqlCommand getNameAndAgeCmd = new SqlCommand(SqlQueries.SelectMinionNameAndAgeById, sqlConnection);
            getNameAndAgeCmd.Parameters.AddWithValue("@Id", id);
            using SqlDataReader reader = await getNameAndAgeCmd.ExecuteReaderAsync();
            while (reader.Read())
            {
                sb.AppendLine($"{reader[0]} - {reader[1]} years old");
            }

            return sb.ToString().Trim();
        }
    }
}