using System;
using System.Collections.Generic;
using System.Text;
using VitruviSoft.DAL.Entities;

namespace VitruviSoft.BLL.Models
{
    public class ProviderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int GroupId { get; set; }

        public Provider ToEntity()
        {
            return new Provider
            {
                Id = Id,
                Name = Name,
                Type = Type,
                GroupId = GroupId
            };

        }
    }

    public static class ProviderExtension
    {
        public static ProviderModel ToModel(this Provider provider)
        {
            return new ProviderModel
            {
                Id = provider.Id,
                Name = provider.Name,
                Type = provider.Type,
                GroupId = provider.GroupId
            };
        }
    }
}
