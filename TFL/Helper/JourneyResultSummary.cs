using System;

namespace TFL
{
    public class JourneyResultSummary
    {
        public string JourneyResultsHeader { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime LeavingTravelTime { get; set; }
        public string EditJourney { get; set; }
        public string AddFavourite { get; set; }
        public string Leaving { get; set; }
        public string FastestJourneyByPublicTransport { get; set; }
        public string MapView { get; set; }
        public string ViewDetails { get; set; }

    }
}
