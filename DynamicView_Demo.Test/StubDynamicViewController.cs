using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicView_Demo.Controllers;

namespace DynamicView_Demo.Test
{
    public class StubDynamicViewController : DynamicViewController
    {
        public StubDynamicViewController()
        {
            base.ControllerContext = this.ControllerContext;
        }

        public void GetDynamicViewForTest(string pageName, string id)
        {
            
        }
    }
}
