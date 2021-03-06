using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitruviSoft.BLL.Models;

namespace VitruviSoft.PresentationLayer.Models
{
    public class ProviderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<GroupModel> Groups { get; set; }
    }
}
