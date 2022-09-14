using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGenerator.Data.Entities
{
    public class DataSeed
    {
        public int Id { get; set; }
        public string SeedValue { get; set; }
        public string DisplayValue { get; set; }
        public int? ParentId { get; set; }
    }
}
