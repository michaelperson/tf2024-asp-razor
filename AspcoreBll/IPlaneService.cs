using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using tf2024_asp_razor.entities.Interfaces;
using tf2024_asp_razor.Models.Entities;

namespace AspcoreBll
{
    public interface IPlaneService
    {
        bool Insert(PlaneEntity toInsert);
        bool Update(PlaneEntity toUpdate);
        bool Delete(int Id);

        PlaneEntity? GetById(int Id, params Expression<Func<PlaneEntity, IEntity>>[] includeProperties);
        IEnumerable<PlaneEntity> GetAll(params Expression<Func<PlaneEntity, IEntity>>[] includeProperties);



    }
}
