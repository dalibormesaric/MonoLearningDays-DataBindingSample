using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MonoDemo.WPF.ViewModels
{
    public abstract class BaseNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise the PropertyChanged event
        /// </summary>
        public void RaisePropertyChanged(string propertyName)
        {
            try
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Raise the PropertyChanged event based on some expression (extract the 
        /// name of the property to ensure strongly typedness)
        /// </summary>
        public void RaisePropertyChanged<TValue>(Expression<Func<TValue>> propertySelector)
        {
            try
            {
                var memberExpression = propertySelector.Body as MemberExpression;
                if (memberExpression != null)
                {
                    RaisePropertyChanged(memberExpression.Member.Name);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}