using System;
using System.Collections.Generic;

namespace MachineTestAssestManagement.Models
{
    public partial class AssetMasterTable
    {
        public int AmId { get; set; }
        public string AmAtypeId { get; set; }
        public int? AmMakerId { get; set; }
        public int? AmAddId { get; set; }
        public string AmModel { get; set; }
        public string AmSnumber { get; set; }
        public string AmMyyear { get; set; }
        public DateTime? AmPdate { get; set; }
        public string AmWarranty { get; set; }
        public DateTime? AmFrom { get; set; }
        public DateTime? AmTo { get; set; }
    }
}
