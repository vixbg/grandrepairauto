using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IGenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> where TEntity : class,
        IEntity<TPrimaryKey>, ISoftDeletable where TPrimaryDTO : class, IDTO where TCreateDTO : class, IDTO where TUpdateDTO : class, IDTO
    {
        IEnumerable<TPrimaryDTO> GetAll(IFilter<TEntity> filter);
        IEnumerable<TPrimaryDTO> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TPrimaryDTO GetByID(TPrimaryKey id);
        TPrimaryDTO Create(TCreateDTO dto);
        TPrimaryDTO Update(TUpdateDTO dto, TPrimaryKey id);
        bool Delete(TPrimaryKey id);
        bool Restore(TPrimaryKey id);
    }
}
