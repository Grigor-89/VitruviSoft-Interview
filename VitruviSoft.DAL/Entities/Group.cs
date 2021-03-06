using System;
using System.Collections.Generic;
using System.Text;

namespace VitruviSoft.DAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ParentId { get; set; }
        public ICollection<Provider> Providers { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
