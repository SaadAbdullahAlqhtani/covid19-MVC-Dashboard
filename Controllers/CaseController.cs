using AutoMapper;
using covid19.Data;
using covid19.Models;
using covid19.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Controllers
{
    [Authorize]
    public class CaseController : Controller
    {
        private ICaseRepository _caseRepository;
        private readonly IMapper _mapper;

        public CaseController(ICaseRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }

        public IActionResult Index()
        {
            var cases = _caseRepository.GetCases();

            return View(cases);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Case/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Case model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (!_caseRepository.CreateCase(model))
                {
                    ModelState.AddModelError("", $"Something went wrong saving the case " +
                                                $"{model.FirstName} {model.LastName}");
                    return StatusCode(500, ModelState);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: Case/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_caseRepository.CaseExists(id))
                return NotFound();

            var data = _caseRepository.GetCase(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_caseRepository.DeleteCase(data))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " +
                                            $"{data.FirstName} {data.LastName}");
                return StatusCode(500, ModelState);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Case/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (!_caseRepository.CaseExists(id))
                return NotFound();

            var data = _caseRepository.GetCase(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return View(data);
        }

        // POST: Case/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Case model)
        {
            try
            {
                if (model == null)
                    return BadRequest(ModelState);

                if (!_caseRepository.CaseExists(model.Id))
                    ModelState.AddModelError("", "Case doesn't exist!");

                if (!ModelState.IsValid)
                    return StatusCode(404, ModelState);

                if (!_caseRepository.UpdateCase(model))
                {
                    ModelState.AddModelError("", $"Something went wrong updating the case " +
                                                $"{model.FirstName} {model.LastName}");
                    return StatusCode(500, ModelState);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // GET: Case/Details/5
        public ActionResult Details(int id)
        {
            if (!_caseRepository.CaseExists(id))
                return NotFound();

            var data = _caseRepository.GetCase(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return View(data);
        }

        public IActionResult GetCuredCase()
        {

            var data = _caseRepository.GetCuredCases();

            return View(data);
        }
    }
}
