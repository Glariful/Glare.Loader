namespace Glare.Loader.Data
{
    #region
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Input;
    using System.Xml.Serialization;
    using Glare.Loader.Class;
    #endregion

    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Config : INotifyPropertyChanged
    {
        [XmlIgnore] public static Config Instance;
        private string _selectedLanguage;
        private bool _tosAccepted;
        private bool _firstRun = true;

        public string Username { get; set; }
        public string Password { get; set; }

        public bool TosAccepted
        {
            get { return _tosAccepted; }
            set
            {
                _tosAccepted = value;
                OnPropertyChanged("TosAccepted");
            }
        }

        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged("SelectedLanguage");
            }
        }

        public bool FirstRun
        {
            get { return _firstRun; }
            set
            {
                _firstRun = value;
                OnPropertyChanged("FirstRun");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }   
    }
