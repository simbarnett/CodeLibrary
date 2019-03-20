using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLibraryHelpers.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace CodeLibrary.ServerSide.Scratch
{
    class CallSqlFunction
    {
      public string GetIndexFamilyCode(string indexCode)
      {
          var familyName = string.Empty;
          var connectionString = ConfigHelper.GetConnectionString("PrimeConnectionString");

          using (var connection = new SqlConnection(connectionString))
          {
              var commandText = $"SELECT TECHNOTE.[get_family_mnemonic](@dgcode)";
						
							//var blahCommand = new SqlCommand(commandText, connection);
							//blahCommand.Parameters.AddWithValue("@dgcode", 44);
							//connection.Open();
							//blahCommand.ExecuteScalar();

							using (var command = new SqlCommand(commandText, connection))
              {
                  command.Parameters.AddWithValue("@dgcode", indexCode);
                  command.CommandType = CommandType.Text;

                  try
                  {
                      connection.Open();
                      familyName = command.ExecuteScalar().ToString();
                  }
					catch (SqlException sqlEx)
					{
						throw sqlEx;
					}
                  catch (Exception ex)
                  {
                      throw ex;
                  }
              }
          }

                return familyName;
        }
    }
}
