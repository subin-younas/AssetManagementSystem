using System;
using System.Collections.Generic;

namespace AssetManagement.Models
{
    public partial class AssetType
    {
        public AssetType()
        {
            AssetDefinition = new HashSet<AssetDefinition>();
            AssetMaster = new HashSet<AssetMaster>();
            Vendor = new HashSet<Vendor>();
        }

        public int AtId { get; set; }
        public string AtName { get; set; }

        public virtual ICollection<AssetDefinition> AssetDefinition { get; set; }
        public virtual ICollection<AssetMaster> AssetMaster { get; set; }
        public virtual ICollection<Vendor> Vendor { get; set; }
    }
}
