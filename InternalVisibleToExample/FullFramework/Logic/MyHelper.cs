namespace Logic
{
    public class MyHelper
    {
        public string PublicMethod()
        {
            return "Everyone can call this method";
        }

        private string PrivateMethod()
        {
            return "you should not be able to call this directly";
        }

        internal string InternalMethod()
        {
            return "should only be visible to the class itself & tests";
        }
    }
}
