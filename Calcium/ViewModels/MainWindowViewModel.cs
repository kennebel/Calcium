﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calcium
{
    public class MainWindowViewModel : BaseNotify
    {
        #region Fields
        protected int _NoticeBadgeCount = 0;
        protected List<string> _Errors = new List<string>();
        #endregion

        #region Properties
        public int NoticeBadgeCount
        {
            get
            {
                return _NoticeBadgeCount;
            }
            set
            {
                if (_NoticeBadgeCount != value)
                {
                    _NoticeBadgeCount = value;
                    OnPropertyChanged();
                    OnPropertyChanged("NoticeBadgeVisibility");
                }
            }
        }

        public Visibility NoticeBadgeVisibility
        {
            get { return NoticeBadgeCount > 0 ? Visibility.Visible : Visibility.Hidden; }
        }

        public List<string> Errors
        {
            get
            {
                return _Errors;
            }
            set
            {
                _Errors = value ?? new List<string>();
            }
        }
        #endregion

        #region Methods
        public void ListenForErrors()
        {
            ErrorManager.ErrorReport += ErrorManager_ErrorReport;
        }

        private void ErrorManager_ErrorReport(object sender, IError reported)
        {
            NoticeBadgeCount++;
            Errors.Add(reported.ToString());
        }
        #endregion
    }
}
