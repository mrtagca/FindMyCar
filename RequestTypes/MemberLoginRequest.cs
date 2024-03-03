using BaseTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestTypes
{
    public class MemberLoginRequest : RequestBase
    {
        public string Phone { get; set; }
    }
}
