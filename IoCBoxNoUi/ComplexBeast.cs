using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCBoxNoUi
{
    public class ComplexBeast
    {
        public ComplexBeast(ISimple simple)
        {
            this.Simple = simple;
        }
        public ISimple Simple { get; private set; }
    }
}
