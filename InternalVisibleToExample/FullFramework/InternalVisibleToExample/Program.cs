using Logic;

namespace InternalVisibleToExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new MyHelper();
            helper.PublicMethod();
        }
    }
}
