using Microsoft.AspNetCore.Mvc;
using SiteEmprestimos.Data;
using SiteEmprestimos.Interfaces;
using SiteEmprestimos.Models;

namespace SiteEmprestimos.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly ApplicationDbContext _repository;
        public EmprestimoService(ApplicationDbContext repository) 
        {
            _repository = repository;
        }

        public IEnumerable<EmprestimosModel> GetAll()
        {
            return _repository.Emprestimos;
        }

        public EmprestimosModel GetById(int? id)
        {
           EmprestimosModel result = _repository.Emprestimos.FirstOrDefault(x => x.Id == id);
           return (result);
        }

        public bool Create(EmprestimosModel model)
        {
            model.Active = true;
            _repository.Emprestimos.Add(model);
            _repository.SaveChanges();
            return true;
        }
        
        public bool Update(EmprestimosModel model)
        {
            EmprestimosModel emprestimo = GetById(model.Id);
            emprestimo.Recebedor = model.Recebedor;
            emprestimo.Fornecedor = model.Fornecedor;
            emprestimo.LivroEmprestado = model.LivroEmprestado;
            emprestimo.DataEmprestimo = DateTime.Now;

            _repository.Emprestimos.Update(emprestimo);
            _repository.SaveChanges();
            return true;
        }

        public bool Delete(int? id)
        {
            EmprestimosModel emprestimo = GetById(id);

            if(emprestimo is null) 
            {
                return false;
            }
            else
            {
                emprestimo.Active = false;

                _repository.Remove(emprestimo);
                _repository.SaveChanges();
                return true;
            }
        }
    }
}
