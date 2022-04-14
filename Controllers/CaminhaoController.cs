using CadsatroCaminhoes.Data;
using CadsatroCaminhoes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadsatroCaminhoes.Controllers
{
	public class CaminhaoController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CaminhaoController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Caminhao> objCaminhaoList = _db.Caminhoes.ToList();
			return View(objCaminhaoList);
		}

		//GET
		public IActionResult Inserir()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Inserir(Caminhao obj)
		{
			if (ModelState.IsValid)
			{
				_db.Caminhoes.Add(obj);
				_db.SaveChanges();
				TempData["sucess"] = "Caminhão inserido com sucesso!";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		//GET
		public IActionResult Editar(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var caminhaoFromDb = _db.Caminhoes.Find(id);

			if (caminhaoFromDb == null)
			{
				return NotFound();
			}

			return View(caminhaoFromDb);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Editar(Caminhao obj)
		{
			if (ModelState.IsValid)
			{
				_db.Caminhoes.Update(obj);
				_db.SaveChanges();
				TempData["sucess"] = "Caminhão editado com sucesso!";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		//GET
		public IActionResult Deletar(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var caminhaoFromDb = _db.Caminhoes.Find(id);

			if (caminhaoFromDb == null)
			{
				return NotFound();
			}

			return View(caminhaoFromDb);
		}

		//POST
		[HttpPost,ActionName("Deletar")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletarPOST(int? id)
		{
			var obj = _db.Caminhoes.Find(id);

			if (obj==null)
			{
				return NotFound();
			}

			_db.Caminhoes.Remove(obj);
			_db.SaveChanges();
			TempData["sucess"] = "Caminhão excluído com sucesso!";
			return RedirectToAction("Index");
		}
	}
}
