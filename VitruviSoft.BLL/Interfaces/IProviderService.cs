using System;
using System.Collections.Generic;
using System.Text;
using VitruviSoft.BLL.Models;

namespace VitruviSoft.BLL.Interfaces
{
    public interface IProviderService
    {
        IEnumerable<ProviderModel> GetProviders(int groupId);
        void AddProvider(ProviderModel provider);
        IEnumerable<ProviderModel> GetAllProviders();
        ProviderModel GetProviderById(int id);
        void DeleteProvider(int id);

    }
}
