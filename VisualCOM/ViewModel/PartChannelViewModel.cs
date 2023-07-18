using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCOM.ViewModel
{
    public class PartChannelViewModel:ObservableObject
    {

        public PartChannelViewModel()
        {
            ChannelTitle = "通道1";
            dataTypes =new List<string>() { "byte","int","long","float","double"};
			DataType = dataTypes[0];
        }

        public int CountNumber { get; set; }

        private string channelTitle;

		public string ChannelTitle
		{
			get { return channelTitle; }
			set { channelTitle = value;OnPropertyChanged(); }
		}


		private List<string> dataTypes;

		public List<string> DataTypes
		{
			get { return dataTypes; }
			set { dataTypes = value;OnPropertyChanged(); }
		}

		private string dataType;

		public string DataType
		{
			get { return dataType; }
			set { dataType = value;OnPropertyChanged();}
		}

	}
}
