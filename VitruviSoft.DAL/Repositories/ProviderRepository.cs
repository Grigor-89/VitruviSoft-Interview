using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VitruviSoft.DAL.Entities;
using VitruviSoft.DAL.Interfaces;

namespace VitruviSoft.DAL.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly GroupContext _context;

        public ProviderRepository(GroupContext context)
        {
            _context = context;
        }
        public void Create(Provider provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Provider provider = _context.Providers.Find(id);
            if (provider != null)
                _context.Providers.Remove(provider);
            _context.SaveChanges();
        }

        public IEnumerable<Provider> GetByGroupId(int id)
        {
            return _context.Providers.Where(p => p.GroupId == id).ToList();
        }

        public IEnumerable<Provider> GetAll()
        {
            return _context.Providers.ToList();
        }

        public Provider GetById(int id)
        {
            return _context.Providers.FirstOrDefault(p => p.Id == id);
        }
    }
}
