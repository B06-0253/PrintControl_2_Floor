using System.IO;
using System.Linq;
using Dapper;
using System.Collections.Generic;

namespace TPA_PrinterControll
{
    public class SqLiteModelRepository : SqLiteBaseRepository, IModelRepository
    {
        public Model GetModel(long id)
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                Model result = cnn.Query<Model>(
                    @"SELECT *
                    FROM Model
                    WHERE Id = @ID", new { id }).FirstOrDefault();
                return result;
            }
        }

        public List<Model> GetAllModel()
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                List<Model> result = cnn.Query<Model>(
                    @"SELECT *
                    FROM Model").ToList();
                return result;
            }
        }

        public void InsertModel(Model Model)
        {
            if (!File.Exists(DbFile)) return;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                Model.ID = cnn.Query<long>(
                    @"INSERT INTO Model 
                    (  ModelCode, SupplierCode, CustomerPartNo, CountryOfProduction,FosterPartNo,PlantCode,ChangeIndexNo,MatrixCode ) VALUES 
                    ( @ModelCode, @SupplierCode, @CustomerPartNo, @CountryOfProduction,@FosterPartNo,@PlantCode,@ChangeIndexNo,@MatrixCode  );
                    select last_insert_rowid()", Model).First();
            }
        }

        public void UpdateModel(Model Model)
        {
            if (!File.Exists(DbFile)) return;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                string sql = string.Format(@"UPDATE Model SET ModelCode=@ModelCode, SupplierCode=@SupplierCode, CustomerPartNo=@CustomerPartNo, CountryOfProduction=@CountryOfProduction,
                                                    FosterPartNo=@FosterPartNo,PlantCode=@PlantCode,ChangeIndexNo=@ChangeIndexNo,MatrixCode=@MatrixCode
                                            WHERE ID = @ID");
                cnn.Query<long>(sql, Model);
            }
        }
    }
}
