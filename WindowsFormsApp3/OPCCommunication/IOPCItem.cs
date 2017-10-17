using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OPCCommunication
{
    public interface IOPCItem
    {
        List<string> GetItemList();
        List<string> GetRealTimeItemList();
    }
}
