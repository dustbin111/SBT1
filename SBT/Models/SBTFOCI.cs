using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SBT.Models
{
    public class SBTFOCI
    {
        public string FOCIMitigationInstrument { get; set; }
        
        //Board Resolution for Indebtedness
        public string FOCIBRIndebtCountry { get; set; }
        
        //Board Resolution for minority ownership
        public string FOCIMinorityShareholder { get; set; }
        public string FOCIMinorityShareholderCountry { get; set; }
        public string FOCIMinorityStockType { get; set; }
        public string FOCIMinorityStockAmount { get; set; }

        //SCAs
        public string FOCISCAForeignOwnerName { get; set; }
        public string FOCISCAForeignOwnerCountry { get; set; }
        public string FOCISCAOutsideDirector { get; set; }

        //SSAs
        public string FOCISSAForeignOwnerName { get; set; }
        public string FOCISSAForeignOwnerCountry { get; set; }
        public string FOCISSAOutsideDirector { get; set; }

        //NIDs
        public string NIDs { get; set; }
        public string NIDPrescribedInfo { get; set; }
        public string NIDContractNumber { get; set; }

        //Proxy Agreement
        public string FOCIProxyOwnerName { get; set; }
        public string FOCIProxyOwnerCountry { get; set; }
        public string FOCIProxyHolders { get; set; }

        //Voting Trust
        public string FOCIVTOwnerName { get; set; }
        public string FOCIVTOwnerCountry { get; set; }
        public string FOCIVTTrustees { get; set; }

    }
}