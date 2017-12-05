using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SBT.Models
{
    public class SBTFacility
    {
        [Required, StringLength(5, MinimumLength = 5)]
        public string FacilityCAGE { get; set; }

        [Required]
        public string FacilityName { get; set; }
        public string FacilityAddress1 { get; set; }
        public string FacilityAddress2 { get; set; }
        public string FacilityCity { get; set; }
        public string FacilityState { get; set; }
        public string FacilityZIP { get; set; }

        public bool FacilityComplete()
        {
            return !string.IsNullOrEmpty(FacilityCAGE)
                   && !string.IsNullOrEmpty(FacilityName);
            //&& !string.IsNullOrEmpty(FacilityAddress1) 
            //&& !string.IsNullOrEmpty(FacilityAddress2) 
            //&& !string.IsNullOrEmpty(FacilityZIP);
        }
    }
}