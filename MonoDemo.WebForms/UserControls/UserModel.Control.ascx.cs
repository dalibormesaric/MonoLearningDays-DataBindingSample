using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonoDemo.WebForms.UserControls
{
    public partial class UserModel_Control : System.Web.UI.UserControl
    {
        public event EventHandler UserUpdated;

        #region Properties

        private int _userId = 0;
        public int UserId
        {
            get
            {
                if (_userId == 0 && !string.IsNullOrEmpty(fldUserId.Value))
                {
                    _userId = int.Parse(fldUserId.Value);
                }
                return _userId;
            }
            set
            {
                fldUserId.Value = value.ToString();
            }
        }

        #endregion

        protected void fvUserModel_CallingDataMethods(object sender, CallingDataMethodsEventArgs e)
        {
            e.DataMethodsObject = new MonoDemo.BLL.UserBLL();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            UserId = 0;
        }

        protected void fvUserModel_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            EventHandler handler = UserUpdated;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected void fvUserModel_ItemDeleted(object sender, FormViewDeletedEventArgs e)
        {
            EventHandler handler = UserUpdated;
            if (handler != null)
            {
                handler(this, e);
            }

            UserId = 0;
        }
    }
}