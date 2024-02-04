using FirstAppWorkHahn.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAppWorkHahn.Repositores
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<Employes> Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(Guid id);
    }

}
