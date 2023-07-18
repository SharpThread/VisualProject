using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCOM.Model
{
    public sealed class InfoMessage
    {
        public MessageHead MessageTitle { get; set; }
        public bool MessageCommand { get; set; }
        public string MessageBody { get; set; }
    }
}
