using CrudMySql.Aplicacao;
using CrudMySql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMySql.Controllers
{
    public class HomeController : Controller
    {

        private PessoaAplicacao pessoaAplicacao;


        public HomeController()
        {
            pessoaAplicacao = new PessoaAplicacao();
        }
        // GET: Home
        public ActionResult Index(string busca)
        {
            if(busca == null)
            {
            var lista = pessoaAplicacao.ListarTodos(); 
            return View(lista);
            }
            //var buscar = pessoaAplicacao.ListarTodos(busca);
            return View(busca);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaAplicacao.Salvar(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        public ActionResult Editar(int Id)
        {
            var pessoa = pessoaAplicacao.ListarPorId(Id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Editar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaAplicacao.Salvar(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        public ActionResult Detalhe(int id)
        {
            var pessoa = pessoaAplicacao.ListarPorId(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        public ActionResult Excluir(int id)
        {
            var pessoa = pessoaAplicacao.ListarPorId(id);

            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            pessoaAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}