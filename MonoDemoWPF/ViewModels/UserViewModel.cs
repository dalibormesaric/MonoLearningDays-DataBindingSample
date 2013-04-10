using MonoDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonoDemo.WPF.ViewModels
{
    public class UserViewModel : BaseNotify
    {
        #region Properties

        private UserModel _userModel = null;
        public UserModel UserModel
        { 
            get
            {
                return _userModel;
            }
            set
            {
                if (_userModel != value)
                {
                    _userModel = value;
                    RaisePropertyChanged(() => UserModel);
                }
            }
        }

        #endregion

        #region Commands

        private readonly ICommand _saveUserCommand;
        public ICommand SaveUserCommand
        {
            get { return _saveUserCommand; }
        }

        #endregion

        #region Constructor

        private MonoDemo.Repositories.UserRepository _userRepository = new MonoDemo.Repositories.UserRepository();

        public UserViewModel()
        {
            _saveUserCommand = new BaseCommand(SaveUser) { IsEnabled = true };

            UserModel = _userRepository.CreateUser();
        }

        #endregion

        #region Methods

        public void SaveUser()
        {
            _userRepository.SaveUser(UserModel);

            UserModel = _userRepository.CreateUser();
        }

        #endregion
    }
}
