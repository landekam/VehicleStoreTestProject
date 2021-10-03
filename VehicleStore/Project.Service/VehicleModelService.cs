using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Model;
using Project.Service.Model.Interface;

namespace Project.Service
{
    public class VehicleModelService : IVehicleModelService
    {

        private string ConnectionString = "Data Source=.;Initial Catalog=VehicleStore;Integrated Security=True;";

        public Task<int> CreateAsync(IVehicleModel entity)
        {
            if (entity.Id.Equals(Guid.Empty))
            {
                entity.Id = Guid.NewGuid();
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO VehicleModels VALUES(")
                .Append(entity.Id).Append(", ")
                .Append(entity.MakeId).Append(", '")
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
            stringBuilder.Append("DELETE FROM VehicleModels WHERE Id=")
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

        public Task<IEnumerable<IVehicleModel>> FindAsync(ISort sort, IFilter filter, IPage page)
        {
            throw new NotImplementedException();
        }

        public async Task<IVehicleModel> ReadAsync(Guid id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM VehicleModels WHERE Id=")
                .Append(id).Append(";");
            VehicleModel vehicleModel = new VehicleModel();


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

                                vehicleModel.Id = reader.GetGuid(reader.GetOrdinal("Id"));

                                vehicleModel.Name = reader.GetString(reader.GetOrdinal("Name"));
                                vehicleModel.Abbreviation = reader.GetString(reader.GetOrdinal("Abbreviation"));
                            }
                        }
                        return vehicleModel;
                    }
                }
            }
        }

        public Task<int> UpdateAsync(IVehicleModel entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE VehicleModels SET MakeId=").Append(entity.MakeId)
                .Append(", Name='").Append(entity.Name)
                .Append("', Abbreviation='").Append(entity.Abbreviation)
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
