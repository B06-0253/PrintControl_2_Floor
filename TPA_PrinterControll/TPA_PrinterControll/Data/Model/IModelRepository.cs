using System.Collections.Generic;

namespace TPA_PrinterControll
{
    public interface IModelRepository
    {
        Model GetModel(long id);

        List<Model> GetAllModel();
        void InsertModel(Model Model);

        void UpdateModel(Model Model);
    }
}