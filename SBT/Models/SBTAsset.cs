using System;
using System.ComponentModel.DataAnnotations;


namespace SBT.Models
{
    public class SBTAsset
    {
        // our internal Guid
        public Guid Id { get; set; }

        public string assetID { get; set; }
        [Required]
        public string assetName { get; set; }
        public string assetDescription { get; set; }

        public string assetCatIBTL { get; set; }
        //Get data from IBTL.xml

        public string assetCatIBTLSub { get; set; }
        //Get data from IBTL.xml

        public string assetCatPIEFAOS { get; set; }
        //Get data from PIEFAOS.xml
        //People: do not collect against individual peoples.

        public string assetUSG { get; set; }
        //Is this a USG or Commercial program?

        public string assetITAR { get; set; }
        //is there  an ITAR/EAR Nexus?

        public string assetCatForeign { get; set; }
        //Foreign, Domestic, or Both?

        public string assetCPI { get; set; }

        public string assetProgramName { get; set; }
        public string assetProgramClass { get; set; }
        //Get data from Class.xml
        public string assetContractNumber { get; set; }
        public string assetCustomerPOCName { get; set; }
        public string assetCustomerPOCTitle { get; set; }
        public string assetCustomerPOCPhone { get; set; }
        public string assetCustomerPOCEmail { get; set; }

        public string assetControl { get; set; }
        public string assetControlSource { get; set; }

        public string assetOther { get; set; }

    }
}