using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCR_Test
{
    public class SetInfo
    {
        public int counts { get; set; }
        public bool duplicatable
        {
            get
            {
                if (counts > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
