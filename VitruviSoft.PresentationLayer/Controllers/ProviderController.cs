using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitruviSoft.BLL.Interfaces;
using VitruviSoft.BLL.Models;
using VitruviSoft.DAL.Entities;
using VitruviSoft.PresentationLayer.Models;

namespace VitruviSoft.PresentationLayer.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IProviderService providerService;
        private readonly IGroupService groupService;

        public ProviderController(IProviderService providerService, IGroupService groupService)
        {
            this.providerService = providerService;
            this.groupService = groupService;
        }

        public IActionResult Add()
        {
            //var provider = providerService.GetAllProviders();
            //ViewData["AddProvider"] = provider;
            var vm = new ProviderViewModel
            {
                Groups = groupService.GetAllGroups()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind("Id,Name,Type,GroupId")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                providerService.AddProvider(provider.ToModel());
                return RedirectToAction("AllGroups", "Group");
            }
            return View(provider);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = providerService.GetProviderById(id.Value);

            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            providerService.DeleteProvider(id);
            return RedirectToAction("AllGroups", "Group");
        }
    }
}
