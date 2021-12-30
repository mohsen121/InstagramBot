using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramBot.Core.ViewModels
{
    public class InstagramPostViewModel
    {
        public string PostId { get; set; }
        public string Caption { get; set; }
        public string[] Images { get; set; }
    }
}
