using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VisualCOM.ViewModel
{
    public class HomePageViewModel: ObservableObject
    {
        public HomePageViewModel()
        {
            Console.WriteLine("这是Homepage");
        }

    }
}
