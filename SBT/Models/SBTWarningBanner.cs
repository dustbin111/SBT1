using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SBT.Models
{
    public class SBTWarningBanner
    {
        [Required]
        public bool WarningGovt { get; set; }
        [Required]
        public bool WarningAccreditted { get; set; }
        [Required]
        public bool WarningClassified { get; set; }
        [Required]
        public bool WarningStored { get; set; }
        [Required]
        public bool WarningUse { get; set; }

        public bool WarningBannerConsent()
        {
            return WarningGovt && WarningAccreditted && WarningClassified && WarningStored && WarningUse;
        }
    }
}