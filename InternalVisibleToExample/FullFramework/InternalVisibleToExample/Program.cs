﻿using Logic;

namespace InternalVisibleToExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var report = new MyHelper();
            report.PublicMethod();
        }
    }
}
