namespace Glare.Loader.Data
{
    #region

    using System.Collections.ObjectModel;
    using System.ComponentModel;

    #endregion

    public static class Logs
    {
        public static Log MainLog = new Log();
    }

    public class Log : INotifyPropertyChanged
    {
        private ObservableCollection<LogItem> _items = new ObservableCollection<LogItem>();

        public ObservableCollection<LogItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
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

    public class LogItem : INotifyPropertyChanged
    {
        private string _message;
        private string _source;
        private string _status;

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public string Source
        {
            get { return _source; }
            set
            {
                _source = value;
                OnPropertyChanged("Source");
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
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

    public static class LogStatus
    {
        public static string Ok
        {
            get { return "Ok"; }
        }

        public static string Info
        {
            get { return "Info"; }
        }

        public static string Error
        {
            get { return "Error"; }
        }

        public static string Skipped
        {
            get { return "Skipped"; }
        }
    }
}