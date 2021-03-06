using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VitruviSoft.DAL.Entities;

namespace VitruviSoft.DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly GroupContext _context;

        public GroupRepository(GroupContext context)
        {
            _context = context;
        }
        public void Create(Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Group group = _context.Groups.Find(id);
            if (group != null)
                _context.Groups.Remove(group);
            _context.SaveChanges();
        }

        public IEnumerable<Group> GetAll()
        {
            return _context.Groups.ToList();
        }

        public Group GetById(int id) 
        {
            return _context.Groups.FirstOrDefault(g => g.Id == id);
        }
        
        public IEnumerable<Group> GetByParentId(int id)
        {
            return _context.Groups.Where(g => g.ParentId == id);
        }

        public IEnumerable<Group> GetRoots()
        {
            return _context.Groups.Where(g => g.ParentId == 0).ToList();
        }
    }
}
