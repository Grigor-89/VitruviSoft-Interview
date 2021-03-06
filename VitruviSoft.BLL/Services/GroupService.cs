using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VitruviSoft.BLL.Interfaces;
using VitruviSoft.BLL.Models;
using VitruviSoft.DAL;

namespace VitruviSoft.BLL.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public IEnumerable<GroupModel> GetGroups(int parentId)
        {
            var groups = groupRepository.GetByParentId(parentId);
            return groups.Select(g => g.ToModel());
        }

        public void AddGroup(GroupModel group)
        {
            groupRepository.Create(group.ToEntity());
        }
        
        public IEnumerable<GroupModel> GetAllGroups()
        {
            var groups = groupRepository.GetAll();
            return groups.Select(g => g.ToModel());
        }

        public GroupModel GetGroupById(int id)
        {
            return groupRepository.GetById(id).ToModel();

        }

        public void DeleteGroup(int id)
        {
            groupRepository.Delete(id);
        }

        public IEnumerable<GroupModel> GetAllRootGroups()
        {
            var groups = groupRepository.GetRoots();
            return groups.Select(g => g.ToModel());
        }
    }
}
