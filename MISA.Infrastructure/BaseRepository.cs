using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> , IDisposable where TEntity : BaseEntity
    {
        #region DECLARE

        /// <summary>
        /// Phục vụ cho việc lấy chuỗi kết nỗi được lưu trữ trong file appsetting.json
        /// </summary>
        IConfiguration _configuration;

        /// <summary>
        /// Chuỗi kết nối
        /// </summary>
        string _connectionString = string.Empty;

        /// <summary>
        /// Phục vụ cho việc mở kết nối xuống database
        /// </summary>
        protected IDbConnection _dbConnection = null;

        /// <summary>
        /// Tên table để biết được thao tác với table nào trong database
        /// </summary>
        string _tableName;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
            _dbConnection.Open();
            _tableName = typeof(TEntity).Name;
        }
        #endregion

        #region Method
        
        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        ///  CreatedBy : DDHung (9/11/2021)
        public int AddEntity(TEntity entity)
        {
            var rowAffects = 0;
            
            using(var transaction = _dbConnection.BeginTransaction())
            {
                rowAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", entity, commandType: CommandType.StoredProcedure);
                transaction.Commit();
            }
            //var rowAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", entity, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="entityId">Id của bản ghi cần xóa</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        ///  CreatedBy : DDHung (9/11/2021)
        public int DeleteEntity(string entityId)
        {
            var rowAffects = 0;
            //_dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                
                var queryString = $"delete from {_tableName} where {_tableName}Id = @entityId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@entityId", entityId);
                rowAffects = _dbConnection.Execute(queryString, param : parameters ,commandType: CommandType.Text);
                transaction.Commit();
            }    
            
            return rowAffects;
        }

        /// <summary>
        /// Tìm kiếm bản ghi theo Id
        /// </summary>
        /// <param name="entityId">Id bản ghi cần tìm kiếm</param>
        /// <returns>Bản ghi đầu tiên được tìm thấy theo Id</returns>
        ///  CreatedBy : DDHung (9/11/2021)
        public TEntity GetEntityById(string entityId)
        {
            var queryString = $"Select * from {_tableName} where {_tableName}Id = @entityId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@entityId", entityId);
            var entity = _dbConnection.Query<TEntity>(queryString, param:parameters ,commandType: CommandType.Text).FirstOrDefault();
            return entity;
        }

        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy : DDHung (9/11/2021)
        public IEnumerable<TEntity> GetEntities()
        {
            var entites = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}", commandType: CommandType.StoredProcedure);
            return entites;
        }

        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : DDHung (9/11/2021)
        public int UpdateEntity(TEntity entity)
        {
            var rowAffects = 0;
            //_dbConnection.Open();
            using(var transaction = _dbConnection.BeginTransaction())
            {
                rowAffects = _dbConnection.Execute($"Proc_Update{_tableName}", entity, commandType: CommandType.StoredProcedure);
                transaction.Commit();
            }
            return rowAffects;
        }

        /// <summary>
        /// Lấy bản ghi dựa vào thuộc tính (Property)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property">Thông tin thuộc tính</param>
        /// <returns>Trả về 1 bản ghi đầu tiên được tìm thấy</returns>
        /// CreatedBy : DDHung (9/11/2021)
        public TEntity GetEntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = String.Empty;
            DynamicParameters parameters = new DynamicParameters();
            if (entity.EntityState == EntityState.AddNew)
            {
                parameters.Add("@propertyValue", propertyValue);
                query = $"SELECT * FROM {_tableName} where {propertyName} = @propertyValue";
            }    
            else if(entity.EntityState == EntityState.Update)
            {
                parameters.Add("@propertyValue", propertyValue);
                parameters.Add("@keyValue", keyValue);
                query = $"SELECT * FROM {_tableName} where {propertyName} = @propertyValue AND {_tableName}Id <> @keyValue";
            }
            else
            {
                return null;
            }
            var entityReturn = _dbConnection.Query<TEntity>(query,param : parameters, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }

        /// <summary>
        /// Dùng để đóng các kết nối với CSDL khi Object không còn sử dụng nữa.
        /// </summary>
        /// CreatedBy : DDHung (9/11/2021)
        public void Dispose()
        {
            if(_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }

        #endregion

    }
}
