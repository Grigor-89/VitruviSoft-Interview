using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using VitruviSoft.DAL.Entities;

namespace VitruviSoft.DAL
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAll();
        void Create(Group group);
        void Delete(int id);
        Group GetById(int id);
        IEnumerable<Group> GetByParentId(int parentId);
        IEnumerable<Group> GetRoots();
    }
}
