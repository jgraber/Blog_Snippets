namespace DeadCode
{
    /// <summary>
    /// Sample class to explain the problem
    /// <see cref="http://programmers.stackexchange.com/questions/45378/is-commented-out-code-really-always-bad"/>
    /// </summary>
    public class Demo
    {
        /// <summary>
        /// Field to store postal codes like SW1A 2AX
        /// </summary>
        public int Postcode { get; set; }


        /// <summary>
        /// Exhausting, but barely tolerable
        /// </summary>
        /// <returns></returns>
        public int NotSoBad()
        {
            var i = 0;
            var j = 10;
            var sum = 0;

            //for (; i < j; i++)
            /*{
                sum += i;*/
            //}

            sum = i + j;

            return sum;
        }

        /// <summary>
        /// Hard to read, easy to make a mistake
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="d"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int MaintenanceNightmare(int a, int b, /*int c, */ bool d, bool c)
        {
            if (a > b && c /*> a*/ || d /*< b*/)
            {
                a = b;
            }

            return a;
        }

        /// <summary>
        /// Delete code that is commented out
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="d"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Better(int a, int b, bool d, bool c)
        {
            if (a > b && c || d )
            {
                a = b;
            }

            return a;
        }
    }
}
