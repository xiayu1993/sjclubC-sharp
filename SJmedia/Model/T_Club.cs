using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJmedia.Model
{
    public class T_Club
    {
        public Guid Id { get; set; }
        public string ClubName { get; set; }
        public string ClubIntroduction { get; set; }
        public string ClubRelatedInformation { get; set; }
        public string ClubResources { get; set; }
        public string ClubRoute { get; set; }
        public string ClubLogo { get; set; }
        public string ClubLink { get; set; }
    }
}
