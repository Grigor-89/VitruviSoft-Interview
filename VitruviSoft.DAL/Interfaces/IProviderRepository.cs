using System;
using System.Collections.Generic;
using System.Text;
using VitruviSoft.DAL.Entities;

namespace VitruviSoft.DAL.Interfaces
{
    public interface IProviderRepository
    {
        IEnumerable<Provider> GetAll();
        void Create(Provider provider);
        void Delete(int id);
        IEnumerable<Provider> GetByGroupId(int id);
        Provider GetById(int id);

    }
}
