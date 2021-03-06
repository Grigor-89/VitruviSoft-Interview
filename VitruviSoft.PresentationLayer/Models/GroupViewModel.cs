using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitruviSoft.BLL.Models;

namespace VitruviSoft.PresentationLayer.Models
{
    public class GroupViewModel
    {
        public IEnumerable<GroupModel> Groups { get; set; }
        public IEnumerable<ProviderModel> Providers { get; set; }
    }
}
