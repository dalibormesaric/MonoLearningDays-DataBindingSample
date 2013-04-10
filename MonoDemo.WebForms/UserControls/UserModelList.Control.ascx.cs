using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonoDemo.WebForms.UserControls
{
    public partial class UserModelList : System.Web.UI.UserControl
    {
        public event EventHandler<int> UserSelected;

        protected void lvUserModelList_CallingDataMethods(object sender, CallingDataMethodsEventArgs e)
        {
            e.DataMethodsObject = new MonoDemo.BLL.UserBLL();
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            EventHandler<int> handler = UserSelected;
            if (handler != null)
            {
                handler(this, int.Parse(((LinkButton)sender).CommandArgument));
            }
        }
    }
}