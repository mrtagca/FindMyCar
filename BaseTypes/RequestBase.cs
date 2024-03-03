using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes
{
    public class RequestBase : IDisposable
    {
        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
