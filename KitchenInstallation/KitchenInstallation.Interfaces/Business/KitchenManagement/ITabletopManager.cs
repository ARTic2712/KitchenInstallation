namespace KitchenInstallation.Interfaces.Business.KitchenManagement
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Contracts;
    using Entities.Details;

    public interface ITabletopManager
    {
        int Create(string json);

        Task<IEnumerable<Tabletop>> GetAll();

        Task<Tabletop> GetById(int id);

        Task<OperationResult> Delete(int id);

    }
}
