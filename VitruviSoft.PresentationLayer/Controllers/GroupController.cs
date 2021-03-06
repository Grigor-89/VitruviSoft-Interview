using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitruviSoft.BLL.Interfaces;
using VitruviSoft.BLL.Models;
using VitruviSoft.BLL.Services;
using VitruviSoft.DAL.Entities;
using VitruviSoft.PresentationLayer.Models;

namespace VitruviSoft.PresentationLayer.Controllers
{
    public class GroupController : Controller
    {

        private readonly IGroupService groupService;
        private readonly IProviderService providerService;

        public GroupController(IGroupService groupService, IProviderService providerService)
        {
            this.groupService = groupService;
            this.providerService = providerService;
        }

        public IActionResult AllGroups()
        {
            return View(groupService.GetAllRootGroups());
        }

        public IActionResult Add()
        {
            var group = groupService.GetAllGroups();
            ViewData["AddGroup"] = group;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind("Id,Name,Type,ParentId")] Group group)
        {
            if (ModelState.IsValid)
            {
                groupService.AddGroup(group.ToModel());
                return RedirectToAction(nameof(AllGroups));
            }
            return View(group);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var groups = groupService.GetGroups(id.Value);
            var providers = providerService.GetProviders(id.Value);
            var vm = new GroupViewModel
            {
                Groups = groups,
                Providers = providers
            };

            return View(vm);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = groupService.GetGroupById(id.Value);
            
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            groupService.DeleteGroup(id);
            return RedirectToAction(nameof(AllGroups));
        }
    }
}
