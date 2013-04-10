using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonoDemo.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userModelControl.UserUpdated += userModelControl_UserUpdated;
            userModelListControl.UserSelected += userModelListControl_UserSelected;
        }

        void userModelControl_UserUpdated(object sender, EventArgs e)
        {
            userModelListControl.DataBind();
        }

        void userModelListControl_UserSelected(object sender, int e)
        {
            userModelControl.UserId = e;
        }
    }
}