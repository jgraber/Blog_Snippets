using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSubstituteDemo.BusinessLogic
{
    public class DataService
    {
        private readonly IDataAccess dataAccess;

        public DataService(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public DemoDto GetEntryById(int id)
        {
            var entry = this.dataAccess.GetById(id);
            return entry;
        }

        public int Add(DemoDto demoDto)
        {
            var newId = this.dataAccess.Add(demoDto);
            return newId;
        }

        public List<DemoDto> GetAllEntries()
        {
            var entries = this.dataAccess.All();
            return entries;
        }
    }
}
