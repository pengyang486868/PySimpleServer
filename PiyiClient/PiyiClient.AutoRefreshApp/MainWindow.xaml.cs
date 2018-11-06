using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using System.Windows;

namespace PiyiClient.AutoRefreshApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Init();
        }

        private void Init()
        {
            _heardWords = "no words";
            _systemTimer = new Timer(1000)
            {
                AutoReset = true
            };
            _systemTimer.Elapsed += Refresh;
        }

        private Timer _systemTimer;

        private string _heardWords;
        public string HeardWords
        {
            get => _heardWords;
            set
            {
                _heardWords = value;
                OnPropertyChanged();
            }
        }

        private string _serverAddress;
        public string ServerAddress
        {
            get => _serverAddress;
            set
            {
                _serverAddress = value;
                OnPropertyChanged();
            }
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _systemTimer.Start();
        }

        private void Refresh(object sender,ElapsedEventArgs e)
        {
            var pattern = "GetControlStr";

            //var request = (HttpWebRequest)WebRequest.Create(server + pattern);
            var request = WebRequest.Create(_serverAddress + pattern);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            var response = request.GetResponse();
            var stream = response.GetResponseStream();

            if (stream != null)
            {
                var sr = new StreamReader(stream, Encoding.UTF8);
                var retString = sr.ReadToEnd();
                HeardWords = retString;
                sr.Close();
                stream.Close();
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
