using System;
using System.Collections.Generic;

namespace AssetManagement.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            AssetMaster = new HashSet<AssetMaster>();
        }

        public int VdId { get; set; }
        public string VdName { get; set; }
        public string VdType { get; set; }
        public int? VdAtypeId { get; set; }
        public DateTime? VdFrom { get; set; }
        public DateTime? VdTo { get; set; }
        public string VdAddr { get; set; }

        public virtual AssetType VdAtype { get; set; }
        public virtual ICollection<AssetMaster> AssetMaster { get; set; }
    }
}
