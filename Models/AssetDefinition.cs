using System;
using System.Collections.Generic;

namespace AssetManagement.Models
{
    public partial class AssetDefinition
    {
        public AssetDefinition()
        {
            AssetMaster = new HashSet<AssetMaster>();
        }

        public int AdId { get; set; }
        public string AdName { get; set; }
        public int? AdTypeId { get; set; }
        public string AdClass { get; set; }

        public virtual AssetType AdType { get; set; }
        public virtual ICollection<AssetMaster> AssetMaster { get; set; }
    }
}
