using MonoDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.ModelBinding;
using System.Web.UI.WebControls;

namespace MonoDemo.BLL
{
    public class UserBLL
    {
        #region Constructor

        private MonoDemo.Repositories.UserRepository _userRepository = new MonoDemo.Repositories.UserRepository();

        public UserBLL()
        {

        }

        #endregion

        #region Methods

        public UserModel fvUserModel_GetItem([Control("fldUserId", "Value")]string userId)
        {
            if (!string.IsNullOrEmpty(userId) && userId != "0")
            {
                return _userRepository.GetUser(int.Parse(userId));
            }
            else
            {
                return _userRepository.CreateUser();
            }
        }

        public void fvUserModel_InsertItem(ModelMethodContext context)
        {
            var userModel = _userRepository.CreateUser();

            context.TryUpdateModel(userModel);
            if (context.ModelState.IsValid)
            {
                _userRepository.SaveUser(userModel);
            }
        }

        public void fvUserModel_UpdateItem(ModelMethodContext context, [Control("fldUserId", "Value")]string userId)
        {
            var userModel = string.IsNullOrEmpty(userId) || userId == "0" ? _userRepository.CreateUser() : _userRepository.GetUser(int.Parse(userId));

            context.TryUpdateModel(userModel);
            if (context.ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(userId) || userId == "0")
                {
                    _userRepository.SaveUser(userModel);
                }
                else
                {
                    _userRepository.UpdateUser(userModel);
                }
            }
        }

        public void fvUserModel_DeleteItem([Control("fldUserId", "Value")]string userId)
        {
            _userRepository.DeleteUser(int.Parse(userId));
        }

        public IEnumerable<UserModel> lvUserModelList_GetData()
        {
            return _userRepository.GetUsers();
        }

        #endregion
    }
}
