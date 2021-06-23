using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskFor66bit.BLL.Exceptions
{
    public class ExistException:Exception
    {
        public string Property { get; protected set; }
        public ExistException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
