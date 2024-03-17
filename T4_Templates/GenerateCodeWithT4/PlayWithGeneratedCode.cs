using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.TestSubFolder;

namespace GenerateCodeWithT4
{
    internal class PlayWithGeneratedCode
    {
        public void Works()
        {
            var product = new ProductDto();
            var order = new OrderDto();
            order.Id = 1;
        }
    }
}
