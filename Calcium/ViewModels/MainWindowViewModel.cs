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
        protected Visibility _MiddlelayVisibility = Visibility.Hidden;
        protected Visibility _OverlayVisibility = Visibility.Visible;
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

        public string Notifications
        {
            get
            {
                return string.Join("\r\n\r\n", Errors);
            }
        }

        public Visibility MiddlelayVisibility
        {
            get
            {
                return _MiddlelayVisibility;
            }
            set
            {
                if (_MiddlelayVisibility != value)
                {
                    _MiddlelayVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public Visibility OverlayVisibility
        {
            get
            {
                return _OverlayVisibility;
            }
            set
            {
                if (_OverlayVisibility != value)
                {
                    _OverlayVisibility = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Events
        private void ErrorManager_ErrorReport(object sender, IError reported)
        {
            NoticeBadgeCount++;
            Errors.Add(reported.ToString());
            OnPropertyChanged("Notifications");
        }
        #endregion

        #region Methods
        public void ListenForErrors()
        {
            ErrorManager.ErrorReport += ErrorManager_ErrorReport;
        }

        public void ClearNotifications()
        {
            NoticeBadgeCount = 0;
            Errors.Clear();
            OnPropertyChanged("Notifications");
        }
        #endregion
    }
}
