using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VitruviSoft.BLL.Interfaces;
using VitruviSoft.BLL.Models;
using VitruviSoft.DAL.Interfaces;
using VitruviSoft.DAL.Repositories;

namespace VitruviSoft.BLL.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository providerRepositoy;
        public ProviderService(IProviderRepository providerRepository)
        {
            this.providerRepositoy = providerRepository;
        }

        public IEnumerable<ProviderModel> GetProviders(int groupId)
        {
            var providers = providerRepositoy.GetByGroupId(groupId);
            return providers.Select(p => p.ToModel());
        }

        public void AddProvider(ProviderModel provider)
        {
            providerRepositoy.Create(provider.ToEntity());
        }

        public IEnumerable<ProviderModel> GetAllProviders()
        {
            var providers = providerRepositoy.GetAll();
            return providers.Select(p => p.ToModel());
        }

        public ProviderModel GetProviderById(int id)
        {
            return providerRepositoy.GetById(id).ToModel();

        }

        public void DeleteProvider(int id)
        {
            providerRepositoy.Delete(id);
        }
    }
}
