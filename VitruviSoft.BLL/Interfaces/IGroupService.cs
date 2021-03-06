using System;
using System.Collections.Generic;
using System.Text;
using VitruviSoft.BLL.Models;

namespace VitruviSoft.BLL.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<GroupModel> GetGroups(int parentId);
        void AddGroup(GroupModel group);
        IEnumerable<GroupModel> GetAllGroups();
        IEnumerable<GroupModel> GetAllRootGroups();
        GroupModel GetGroupById(int id);
        void DeleteGroup(int id);
    }
}
