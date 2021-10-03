using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Model;
using Project.Service.Model.Interface;

namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private string ConnectionString = "Data Source=.;Initial Catalog=VehicleStore;Integrated Security=True;";

        public Task<int> CreateAsync(IVehicleMake entity)
        {
            if (entity.Id.Equals(Guid.Empty))
            {
                entity.Id = Guid.NewGuid();
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO VehicleMakes VALUES(")
                .Append(entity.Id).Append(", '")
                .Append(entity.Name).Append("', '")
                .Append(entity.Abbreviation).Append("');");

            return Task.Run(async () =>
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(stringBuilder.ToString()))
                    {
                        int result = await command.ExecuteNonQueryAsync();
                        return result;
                    }
                }
            });
            
                
        }

        public Task<int> DeleteAsync(Guid id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM VehicleMakes WHERE Id=")
                .Append(id).Append(";");

            return Task.Run(async () =>
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(stringBuilder.ToString()))
                    {
                        int result = await command.ExecuteNonQueryAsync();
                        return result;

                    }
                }
            });
        }

        public Task<IEnumerable<IVehicleMake>> FindAsync(ISort sort, IFilter filter, IPage page)
        {
            throw new NotImplementedException();
        }

        public async Task<IVehicleMake> ReadAsync(Guid id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM VehicleMakes WHERE Id=")
                .Append(id).Append(";");
            VehicleMake vehicleMake = new VehicleMake();

            
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();
                    
                    using (SqlCommand command = new SqlCommand(stringBuilder.ToString()))
                    {
                                                
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            
                            if (reader.HasRows)
                            {
                                
                                while (reader.Read())
                                {
                                                                       
                                    vehicleMake.Id = reader.GetGuid(reader.GetOrdinal("Id"));
                                    vehicleMake.Name = reader.GetString(reader.GetOrdinal("Name"));
                                    vehicleMake.Abbreviation = reader.GetString(reader.GetOrdinal("Abbreviation"));                                    
                                }                                
                            }
                            return vehicleMake;
                        }                        
                    }                
                }
                
            
            
        }

        public Task<int> UpdateAsync(IVehicleMake entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE VehicleMakes SET Name='")
                .Append(entity.Name).Append("', Abbreviation='")
                .Append(entity.Abbreviation)
                .Append("' WHERE Id=").Append(entity.Id).Append(";");

            return Task.Run(async () =>
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(stringBuilder.ToString()))
                    {
                        int result = await command.ExecuteNonQueryAsync();
                        return result;

                    }
                }
            });
        }
    }
}
