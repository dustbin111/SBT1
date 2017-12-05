using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBT.Models
{
    public class AssetViewModel
    {
        public SBTAsset Asset { get; set; }

        public IEnumerable<SelectListItem> CatIBTL { get; set; }
        public IEnumerable<SelectListItem> CatIBTLSub { get; set; }

        public IEnumerable<SelectListItem> CatPiefaos { get; set; }
        
    }
}