using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSubstituteDemo.BusinessLogic
{
    public interface IDataAccess
    { 
        DemoDto GetById(int id);

        int Add(DemoDto dto);

        List<DemoDto> All();

        bool IsConnectionReady();
    }
}
