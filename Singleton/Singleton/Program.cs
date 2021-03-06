﻿#region

using System;
using System.Threading;
using EnvDTE;
using Singleton.Singletons;
using VSLangProj;
using Thread=System.Threading.Thread;

#endregion

namespace Singleton
{
    internal class Program
    {
        private const int ThreadCount = 10;

        private static void Main(string[] args)
        {
            Thread[] threads = new Thread[ThreadCount];

            Func<ISingleton> func = () => SimpleSingleton.Instance;
            TestSingletonType(threads, func, "SimpleSingleton");

            func = () => DoubleCheckSingleton.Instance;
            TestSingletonType(threads, func, "DoubleCheckSingleton");

            func = () => NestedSingleton.Instance;
            TestSingletonType(threads, func, "NestedSingleton");

            func = () => GenericSingleton<ConcreteSingleton>.Instance;
            TestSingletonType(threads, func, "ConcreteSingleton");

            func = () => DoubleCheckInitSingleton.GetInstance(null);
            TestSingletonType(threads, func, "DoubleCheckInitSingleton");

            Console.ReadLine();
        }

        private static void TestSingletonType(Thread[] threads, Func<ISingleton> func, string singletonTypeName)
        {
            Console.Out.WriteLine("Start testing " + singletonTypeName);

            for (int ind = 0; ind < threads.Length; ind++)
            {
                threads[ind] = new Thread(new ParameterizedThreadStart(Run));
            }

            foreach (Thread thread in threads)
            {
                thread.Start(func);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            Console.Out.WriteLine("Finish testing " + singletonTypeName);
        }

        private static void Run(object obj)
        {
            Func<ISingleton> func = obj as Func<ISingleton>;
            if (func != null)
            {
                ISingleton singleton = func();
                singleton.Do();
            }
        }
    }


    internal class pr
    {

        static DTE dte;
        static Project Project;


        void Start()
        {
            IServiceProvider serviceProvider = Host as IServiceProvider;
            if (serviceProvider != null)
            {
                dte = serviceProvider.GetService(typeof(DTE)) as DTE;
            }

            // Fail if we couldn't get the DTE. This can happen when trying to run in TextTransform.exe
            if (dte == null)
            {
                throw new Exception("T4MVC can only execute through the Visual Studio host");
            }


            VSProject vsProj = (VSProject)dte.Solution.Projects.Item(0).Object;
            Project project = vsProj.References.ContainingProject;

            Project = GetProjectContainingT4File(Dte);
        }
    }
}