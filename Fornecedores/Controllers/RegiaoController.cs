using DAL;
using Fornecedores.DAO;
using Fornecedores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Fornecedores.Controllers
{
    public class RegiaoController : Controller
    {
        RegiaoDAO regiaoDAO = new RegiaoDAO();
        FornecedorDAO fornecedorDAO = new FornecedorDAO();
        EstadoDAO estadoDAO = new EstadoDAO();

        // GET: Regiao
        public ActionResult Index(IndexRegiao model)
        {
            model.Fornecedores = fornecedorDAO.ListaFornecedores();
            model.RegioesEstado = regiaoDAO.ListaRegioesEstado(model.IdFornecedor,Constantes.OPCAO_INDEX);
            return View(model);
        }

                
        public ActionResult CadastroRegiao(IndexRegiao model)
        {
            model.Estados = estadoDAO.ListaEstados();
            model.RegioesEstado = regiaoDAO.ListaRegioesEstado(0, Constantes.OPCAO_CADASTRO_REGIAO);
            return View(model);
        }

        public ActionResult Adiciona(IndexRegiao indexRegiao)
        {
            if (ModelState.IsValid)
            {
                regiaoDAO.Adiciona(indexRegiao);
                ModelState.AddModelError("", "Error in cloud - GetPLUInfo");
                return RedirectToAction("CadastroRegiao");                            
            }
            else
            {
                ModelState.AddModelError("", "Error in cloud - GetPLUInfo");
                return RedirectToAction("CadastroRegiao");
            }

        }

        public ActionResult Editar(int? IdRegiao)
        {
            if (IdRegiao == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RegiaoView regiaoView = regiaoDAO.GetRegiaoById(IdRegiao);
            regiaoView.Estados = estadoDAO.ListaEstados();

            if (regiaoView == null)
            {
                return HttpNotFound();
            }
            return View(regiaoView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "IdRegiao,Descricao,Ativo,IdEstado")] RegiaoView regiaoView)
        {
            if (ModelState.IsValid)
            {
                regiaoDAO.atualizaRegiao(regiaoView);
                return RedirectToAction("CadastroRegiao");
            }
            return View(regiaoView);
        }


        public ActionResult Inativar(int? IdRegiao)
            {
                if (IdRegiao == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

            regiaoDAO.InativarRegiao(IdRegiao);
               
                return RedirectToAction("CadastroRegiao");
            }

        public ActionResult Ativar(int? IdRegiao)
        {
            if (IdRegiao == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            regiaoDAO.AtivarRegiao(IdRegiao);

            return RedirectToAction("CadastroRegiao");
        }

    }
}