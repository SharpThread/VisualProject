using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCOM.ViewModel
{
    public class ChartsPageViewModel:ObservableObject
    {
        public ChartsPageViewModel()
        {
            Console.WriteLine("这是绘图界面");
            ChannelNames =new List<string>() { "通道1"};
            ChannelName = ChannelNames[0];

            WeakReferenceMessenger.Default.Register<List<string>>(this, (r, m) =>
            {
                ChannelNames = m;
                ChannelName = ChannelNames[0];
            });
        }

        private string channelName;

        public string ChannelName
        {
            get { return channelName; }
            set { channelName = value;OnPropertyChanged(); }
        }

        private List<string> channelNames;

        public List<string> ChannelNames
        {
            get { return channelNames; }
            set { channelNames = value;OnPropertyChanged(); }
        }


    }
}
