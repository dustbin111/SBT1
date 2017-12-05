using System.Collections.Generic;

namespace SBT.Models
{
    public class SessionViewModel
    {
        //This is where we are storing all the cross-view variables.
        public SessionViewModel()
        {
            WarningBanner = new SBTWarningBanner();
            Facility = new SBTFacility();
            Asset = new SBTAsset();
            Assets = new List<SBTAsset>();
        }

        public SBTWarningBanner WarningBanner { get; set; }
        public SBTFacility Facility { get; set; }
        public SBTAsset Asset { get; set; }

        public List<SBTAsset> Assets { get; set; }

    }
}