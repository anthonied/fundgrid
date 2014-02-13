using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundgrid.Data
{
    public interface DataObject<T>
    {
        T ToDomain();
    }
}
