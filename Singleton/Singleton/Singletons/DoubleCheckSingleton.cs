#region

using System;

#endregion

namespace Singleton.Singletons
{
    public class DoubleCheckSingleton : ISingleton
    {
        // Lock sync object
        private static readonly object syncRoot = new object();
        //instance variable
        private static volatile DoubleCheckSingleton instance;
        private readonly Random random = new Random((int) DateTime.Now.Ticks);

        protected DoubleCheckSingleton()
        {
        }

        public static DoubleCheckSingleton Instance
        {
            get
            {
                // Support multithreaded applications through
                // 'Double checked locking' pattern which (once
                // the instance exists) avoids locking each
                // time the method is invoked

                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DoubleCheckSingleton();
                        }
                    }
                }

                return instance;
            }
        }

        #region ISingleton Members

        public void Do()
        {
            Console.Out.WriteLine(random.Next());
        }

        #endregion
    }
}