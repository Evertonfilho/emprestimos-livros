using Microsoft.AspNetCore.Mvc;
using SiteEmprestimos.Models;
using SiteEmprestimos.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SiteEmprestimos.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoService _service;

        public EmprestimoController(IEmprestimoService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _service.GetAll();
            return View(emprestimos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel result = _service.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        //Métodos:
        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = _service.Create(model);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel model)
        {
            if (ModelState.IsValid)
            {
                bool result = _service.Update(model);
                if (result is true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel result = _service.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel model)
        {
            if (model is null)
            {
                return NotFound();
            }
            bool result = _service.Delete(model.Id);

            if (result is false)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
