using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJmedia.Model
{
    public class T_Message
    {
        #region 基本信息
        public Guid Id { get; set; }
        public Guid SendUsersId { get; set; }
        public Guid ReceiveUsersId { get; set; }
        public string SendTime { get; set; }
        public string SendHead { get; set; }
        public string SendContent { get; set; }
        public Boolean IsCheck { get; set; }
        #endregion 

        #region 扩展信息
        public string SendUserName { get; set; }        //发件人昵称
        public string ReceiveUsersName { get; set; }    //收件人昵称
        #endregion
    }
}
