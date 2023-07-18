using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisualCOM.Model;

namespace VisualCOM.ViewModel
{

    public class MorePageViewModel : ObservableObject
    {

        List<string> _channelNames = new List<string>() { "通道1" };
        public MorePageViewModel()
        {
            channelCounts = new List<string>() { "1", "2", "3", "4" };
            channelCount = channelCounts[0];

            channelModel.Add(new PartChannelViewModel() { ChannelTitle = "通道" + 1, CountNumber = 1 });

            BuffSizes = new List<string>() { "1k", "2k", "3k", "5k", "1M", "2M", "3M", "5M" };
            BuffSize = buffSizes[0];
            SaveArgsCommand = new RelayCommand(() => SaveArgs());

            ChooseChannelCommand = new RelayCommand<string>(ChooseChannel);
        }


        #region method

        private void ChooseChannel(string count)
        {
            if (count == null)
            {
                return;
            }

            int count1 = System.Convert.ToInt32(count);
            List<PartChannelViewModel> list = new List<PartChannelViewModel>();
            _channelNames = new List<string>();
            for (int i = 0; i < count1; i++)
            {
                list.Add(new PartChannelViewModel() { ChannelTitle = "通道" + (i + 1), CountNumber = i + 1 });
                _channelNames.Add("通道" + (i + 1));
            }
            ChannelModel = list;
        }
        private void SaveArgs()
        {

            //!校验数据
            //if (Head.Equals("None") || Tail.Equals("None") || Separator.Equals("None"))
            //{
            //    WeakReferenceMessenger.Default.Send<InfoMessage>(new InfoMessage() { MessageTitle = MessageHead.DataUtilError });
            //    return;
            //}

            DataUtil dataUtil=null;
            if (DataFormat == Format.Hex)
            {
                dataUtil = new DataUtil(ChannelModel.Count);
                dataUtil.utilFormatValue = DataUtil.UtilFormat.Hex;
            }
            else if (DataFormat == Format.String)
            {
                dataUtil = new DataUtil(Head, Tail, Separator, ChannelModel.Count);
                dataUtil.utilFormatValue= DataUtil.UtilFormat.String;
            }
            foreach (var channel in ChannelModel)
            {
                dataUtil.SetType(GetChannelType(channel));
            }

            //To ChartsPage
            WeakReferenceMessenger.Default.Send<DataUtil>(dataUtil);

            //To SettingPageViewModel&ChartsPageViewModel
            WeakReferenceMessenger.Default.Send(_channelNames);

            WeakReferenceMessenger.Default.Send<InfoMessage>(new InfoMessage() { MessageTitle = MessageHead.DataUtilArgSetting });
        }



        private Type GetChannelType(PartChannelViewModel vm)
        {
            Type t = null;

            switch (vm.DataType)
            {
                case "byte": t = typeof(byte); break;
                case "int": t = typeof(int); break;
                case "long": t = typeof(long); break;
                case "float": t = typeof(float); break;
                case "double": t = typeof(double); break;
                default: t = typeof(byte); break;
            }
            return t;
        }
        #endregion

        #region property

        private Format dataFormat = Format.Hex;

        public Format DataFormat
        {
            get { return dataFormat; }
            set { dataFormat = value; OnPropertyChanged(); }
        }


        private List<PartChannelViewModel> channelModel = new List<PartChannelViewModel>();

        public List<PartChannelViewModel> ChannelModel
        {
            get { return channelModel; }
            set { channelModel = value; OnPropertyChanged(); }
        }


        private string buffSize;

        public string BuffSize
        {
            get { return buffSize; }
            set { SetProperty(ref buffSize, value); }
        }

        private string channelCount;

        public string ChannelCount
        {
            get { return channelCount; }
            set { channelCount = value; OnPropertyChanged(); }
        }
        private string head = "None";

        public string Head
        {
            get { return head; }
            set { head = value; OnPropertyChanged(); }
        }

        private string tail = "None";

        public string Tail
        {
            get { return tail; }
            set { tail = value; OnPropertyChanged(); }
        }
        private string separator = "None";

        public string Separator
        {
            get { return separator; }
            set { separator = value; OnPropertyChanged(); }
        }

        #endregion

        #region propertys
        private List<string> channelCounts;

        public List<string> ChannelCounts
        {
            get { return channelCounts; }
            set { channelCounts = value; SetProperty(ref channelCounts, value); }
        }

        private List<string> buffSizes;

        public List<string> BuffSizes
        {
            get { return buffSizes; }
            set { buffSizes = value; SetProperty(ref buffSizes, value); }
        }



        #endregion


        #region command
        public ICommand SaveArgsCommand { get; private set; }

        public ICommand ChooseChannelCommand { get; private set; }
        #endregion

    }
    public enum Format
    {
        Hex,
        String
    }
}
