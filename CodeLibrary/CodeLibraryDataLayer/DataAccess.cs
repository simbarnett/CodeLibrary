using CodeLibraryDataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibraryDataLayer
{
	public class DataAccess
	{

		//public static byte[]

		public static TechNotice GetPdfFromDatabase(string connectionString, int id)
		{			
			var resultSet = new List<TechNotice>();

			using (var connection = new SqlConnection(connectionString))
			{
				var storedProcedure = "LSEG\\simonb.TestGetPdfFromDb";

				using (var sqlCommand = new SqlCommand(storedProcedure, connection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;
					sqlCommand.Parameters.AddWithValue("@id", id);
					connection.Open();
					
					using (var sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							var resultSetrow = new TechNotice
							{
								Id              = sqlDataReader["Id"] is              DBNull ? -1 : Convert.ToInt32(sqlDataReader["Id"]),
								Title           = sqlDataReader["Title"] is           DBNull ? string.Empty : sqlDataReader["Title"].ToString(),
								Content         = sqlDataReader["Content"] is         DBNull ? null : (byte[])sqlDataReader["Content"],
								ContentItem     = sqlDataReader["ContentItem"] is     DBNull ? null : (byte[])sqlDataReader["Content"],
								CsvContent      = sqlDataReader["CsvContent"] is      DBNull ? null : (byte[])sqlDataReader["Content"],
								RedactedContent = sqlDataReader["RedactedContent"] is DBNull ? null : (byte[])sqlDataReader["Content"]
							};

							resultSet.Add(resultSetrow);
						}
					}
				}
			}
			return resultSet.FirstOrDefault();
		}
	}
}
