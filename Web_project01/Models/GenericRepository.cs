using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Dapper.SqlMapper;

namespace Web_project01.Models
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly string connectingString;
        private readonly string primaryKeyColumnName;

        public GenericRepository(string conn, string primaryKeyColumnName = "Id")
        {
            connectingString = conn;
            this.primaryKeyColumnName = primaryKeyColumnName;
        }

        public void AddEntity(TEntity entity)
        {
            using (var c = new SqlConnection(connectingString))
            {
                var tableName = typeof(TEntity).Name;
                c.Open();

                var properties = typeof(TEntity).GetProperties().Where(p => p.Name != "ProductId");
                var columnsNames = string.Join(",", properties.Select(x => x.Name));
                var parameterNames = string.Join(",", properties.Select(x => "@" + x.Name));

                var query = $"INSERT INTO {tableName} ({columnsNames}) VALUES ({parameterNames}); SELECT SCOPE_IDENTITY();";

                var command = new SqlCommand(query, c);

                foreach (var p in properties)
                {
                    var value = p.GetValue(entity) ?? DBNull.Value;
                    command.Parameters.AddWithValue("@" + p.Name, value);
                }

                var newId = command.ExecuteScalar();
                if (newId != null)
                {
                    var idProperty = entity.GetType().GetProperty(primaryKeyColumnName);
                    if (idProperty != null && idProperty.CanWrite)
                    {
                        idProperty.SetValue(entity, Convert.ChangeType(newId, idProperty.PropertyType));
                    }
                }
            }
        }

        public void DeleteById(int id)
        {
            //using (var c = new SqlConnection(connectingString))
            //{
            //    var tableName = typeof(TEntity).Name;

            //    try
            //    {
            //        c.Open();

            //        var query = $"DELETE FROM {tableName} WHERE ProductId = @id"; // Corrected column name

            //        var command = new SqlCommand(query, c);
            //        command.Parameters.AddWithValue("@id", id);

            //        command.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }
            //}


            using (var c = new SqlConnection(connectingString))
            {
                var tableName = typeof(TEntity).Name;
                c.Open();
                var deleteQuery = $"Delete from {tableName} where ProductId=@id";
                c.Execute(deleteQuery, new { Id = id });
            }
        }


        public void UpdateById(TEntity entity)
        {
            //using (var c = new SqlConnection(connectingString))
            //{
            //    var tableName = typeof(TEntity).Name;

            //    try
            //    {
            //        c.Open();

            //        var properties = typeof(TEntity).GetProperties()
            //            .Where(prop => prop.Name != primaryKeyColumnName && prop.GetValue(updatedEntity) != null);

            //        var setClause = string.Join(", ", properties.Select(prop => $"{prop.Name} = @{prop.Name}"));

            //        var query = $"UPDATE {tableName} SET {setClause} WHERE ProductId = @id";

            //        var command = new SqlCommand(query, c);
            //        command.Parameters.AddWithValue("@id", id);

            //        foreach (var prop in properties)
            //        {
            //            command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(updatedEntity));
            //        }

            //        command.ExecuteNonQuery();
            //    }
            //    catch (SqlException ex)
            //    {
            //        Console.WriteLine($"SQL Error Number: {ex.Number}, Message: {ex.Message}");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }
            //}

            using (var c = new SqlConnection(connectingString))
            {
                var tableName = typeof(TEntity).Name;
                var properties = typeof(TEntity).GetProperties().Where(p => p.Name != "ProductId");
                var setClause = string.Join(",", properties.Select(p => $"{p.Name} = @{p.Name}"));
                var query = $"UPDATE {tableName} SET {setClause} WHERE ProductId = @Id";
                var parameters = new DynamicParameters(entity);
                parameters.Add("Id", entity.GetType().GetProperty("ProductId").GetValue(entity, null));
                c.Execute(query, parameters);
            }
        }

        public TEntity FindById(int id)
        {
            //using (var c = new SqlConnection(connectingString))
            //{
            //    var tableName = typeof(TEntity).Name;

            //    try
            //    {
            //        c.Open();

            //        var query = $"SELECT * FROM {tableName} WHERE {primaryKeyColumnName} = @id";

            //        var command = new SqlCommand(query, c);
            //        command.Parameters.AddWithValue("@id", id);

            //        using (var dr = command.ExecuteReader())
            //        {
            //            if (dr.HasRows && dr.Read())
            //            {
            //                var entity = new TEntity();
            //                foreach (var prop in typeof(TEntity).GetProperties())
            //                {
            //                    if (prop.CanWrite && dr.HasColumn(prop.Name))
            //                    {
            //                        var value = dr[prop.Name] == DBNull.Value ? null : dr[prop.Name];
            //                        prop.SetValue(entity, value);
            //                    }
            //                }
            //                return entity;
            //            }
            //        }
            //    }
            //    catch (SqlException ex)
            //    {
            //        Console.WriteLine($"SQL Error Number: {ex.Number}, Message: {ex.Message}");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }
            //}

            //return default;

            using (var c = new SqlConnection(connectingString))
            {
                c.Open();
                var tableName = typeof(TEntity).Name;
                var query = $"select * from {tableName} where ProductId = @Id";
                return c.QueryFirstOrDefault<TEntity>(query, new { Id = id });
            }
        }

        public List<TEntity> GetAll()
        {
            //using (var c = new SqlConnection(connectingString))
            //{
            //    var tableName = typeof(TEntity).Name;
            //    var entities = new List<TEntity>();

            //    try
            //    {
            //        c.Open();
            //        var query = $"SELECT * FROM {tableName}";

            //        var command = new SqlCommand(query, c);
            //        using (var dr = command.ExecuteReader())
            //        {
            //            while (dr.Read())
            //            {
            //                var entity = new TEntity();
            //                foreach (var prop in typeof(TEntity).GetProperties())
            //                {
            //                    if (prop.CanWrite && dr.HasColumn(prop.Name))
            //                    {
            //                        var value = dr[prop.Name] == DBNull.Value ? null : dr[prop.Name];
            //                        prop.SetValue(entity, value);
            //                    }
            //                }
            //                entities.Add(entity);
            //            }
            //        }
            //    }
            //    catch (SqlException ex)
            //    {
            //        Console.WriteLine($"SQL Error Number: {ex.Number}, Message: {ex.Message}");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }

            //    return entities;
            //}

            using (var c = new SqlConnection(connectingString))
            {
                var tableName = typeof(TEntity).Name;
                var query = $"select * from {tableName}";
                var entities = c.Query<TEntity>(query).ToList();
                return entities;
            }


        }
    }

    public static class SqlDataReaderExtensions
    {
        public static bool HasColumn(this SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}