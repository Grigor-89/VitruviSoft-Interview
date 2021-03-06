using System;
using System.Collections.Generic;
using System.Text;

namespace VitruviSoft.DAL.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }

    }
}
