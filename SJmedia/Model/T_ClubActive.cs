using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJmedia.Model
{
    public class T_ClubActive
    {
        #region 基本数据
        public Guid Id { get; set; }
        public Guid ClubId { get; set; }
        public string ActiveHead { get; set; }
        public string ActiveContent { get; set; }
        public string ActiveTime { get; set; }
        public DateTime ActiveEndTime{get;set;}
        public string ActivePosterRoute { get; set; }
        public string ActivePosterName { get; set; }
        #endregion
    }
}
