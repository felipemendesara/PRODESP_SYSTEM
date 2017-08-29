using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colegio.Models;

namespace Colegio.Controllers
{
    public class AlunosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alunos
        public ActionResult Index()
        {
            return View(db.Alunos.ToList());//Lista todos os alunos cadastrados
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)// Se não encontrar nenhum id, ira retornar um BadRequestv(Pois não encontrou nem um id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id); // Cria um objeto aluno
            if (aluno == null)
            {
                return HttpNotFound();// Se o objeto aluno estiver vazio, irá retornar um HttpFound
            }
            return View(aluno);// Entra na visão de detalhes com o objeto aluno preenchido, podendo ser tipado e usado na view
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            return View(); // Retorna a view Create
        }

        // POST: Alunos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoId,AlunoNome,AlunoRg")] Aluno aluno)
        {
            if (ModelState.IsValid)//Se tudo estiver ok... 
            {
                db.Alunos.Add(aluno); // Add os dados do objeto aluno
                db.SaveChanges(); // Salva
                return RedirectToAction("Index"); // E redireciona para o inicio, com o novo aluno cadastrado! 
            }

            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id) // Recebe o id como parametro
        {
            if (id == null)// Se o id for nulo, da BadRequest
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id); // Pega o objeto aluno pelo ID
            if (aluno == null)//se o objeto for nulo, retorna o HttpNotFound
            {
                return HttpNotFound();
            }
            return View(aluno);// Retorna a Visão com os dados do aluno a ser tipado para edição 
        }

        // POST: Alunos/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoId,AlunoNome,AlunoRg")] Aluno aluno)
        {
            if (ModelState.IsValid) // Se for valido...
            {
                db.Entry(aluno).State = EntityState.Modified;// Modifica o objeto alino
                db.SaveChanges();// Salva
                return RedirectToAction("Index");//Redireciona para o inicio
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)// Se o id for nulo retorna BadRequest
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id); // Pega o aluno pelo id
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno); // Retorna a view
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) // Pega o o id
        {
            Aluno aluno = db.Alunos.Find(id); // objeto aluno
            db.Alunos.Remove(aluno); // Remove os dados do objeto aluno
            db.SaveChanges(); // Salva
            return RedirectToAction("Index");//Redireciona para Action Index
        }

        protected override void Dispose(bool disposing)
        { //Libera recurso
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
