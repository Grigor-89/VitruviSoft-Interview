using System;
using System.Collections.Generic;
using System.Text;
using VitruviSoft.DAL.Entities;

namespace VitruviSoft.BLL.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ParentId { get; set; }

        public Group ToEntity()
        {
            return new Group
            {
                Id = this.Id,
                Name = this.Name,
                Type = this.Type,
                ParentId = this.ParentId
            };
        }
    }

    public static class GroupExtension {
        public static GroupModel ToModel(this Group group)
        {
            return new GroupModel
            {
                ParentId = group.ParentId,
                Id = group.Id,
                Name = group.Name,
                Type = group.Type
            };
        }
    }
}
