using Microsoft.AspNetCore.Mvc;
using SiteEmprestimos.Models;

namespace SiteEmprestimos.Interfaces
{
    public interface IEmprestimoService
    {
        IEnumerable<EmprestimosModel> GetAll();
        EmprestimosModel GetById(int? id);
        bool Create(EmprestimosModel model);
        bool Update(EmprestimosModel model);
        bool Delete(int? id);
    }
}
