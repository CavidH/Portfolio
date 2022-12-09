using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Services.Interfaces;

namespace Portfolio.Areas.AdminPanel.Controllers
{    
    [Area("AdminPanel")]
    public class SkillController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public SkillController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task< ActionResult> Index()
        {
            return View(await _unitOfWorkService.SkillService.GetAllAsync());
        }

        // // GET: SkillController/Details/5
        // public ActionResult Details(int id)
        // {
        //     return View();
        // }

        // GET: SkillController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormFile Icon)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // // GET: SkillController/Edit/5
        // public ActionResult Edit(int id)
        // {
        //     return View();
        // }

        // POST: SkillController/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }
        //
        // // GET: SkillController/Delete/5
        // public ActionResult Delete(int id)
        // {
        //     return View();
        // }

        // // POST: SkillController/Delete/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Delete(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }
    }
}
