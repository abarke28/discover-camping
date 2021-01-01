using System;
using System.Collections.Generic;
using System.Text;

namespace discover_camping.Helpers
{
    public static class Constants
    {
        public const string DISCOVER_HOMEPAGE = "https://www.discovercamping.ca/BCCWeb/Default.aspx";
        public const string DISCOVER_BACKCOUNTRY_RESERVATIONS = "https://www.discovercamping.ca/BCCWeb/Facilities/TrailRiverCampingSearchView.aspx";

        public const string NOT_AVAILABLE = "Not Available";

        public const int AUGUST = 8;
        public const string SIX = "6";

        public const string SENDER_EMAIL = "SenderEmail";
        public const string SENDER_PW = "SenderPw";
        public const string EMAILS = "Emails";
        public const string SUBJECT = "Discover Camping Alert";
        public const string BODY = "Discover Camping Reservations are now available online at:\n {0}";

        public const string GMAIL = "smtp.gmail.com";
        public const int PORT = 587; 
    }
}