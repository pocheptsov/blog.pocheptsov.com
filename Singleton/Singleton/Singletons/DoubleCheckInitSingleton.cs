#region

using System;

#endregion

namespace Singleton.Singletons
{
    /// <summary>
    /// Based on double check technique class support initialization of singleton instance
    /// </summary>
    public class DoubleCheckInitSingleton : ISingleton
    {
        // Lock sync object
        private static readonly object syncRoot = new object();
        //instance variable
        private static volatile DoubleCheckInitSingleton instance;
        private readonly Random random = new Random((int) DateTime.Now.Ticks);

        protected DoubleCheckInitSingleton()
        {
        }

        #region ISingleton Members

        public void Do()
        {
            Console.Out.WriteLine(random.Next());
        }

        #endregion

        /// <summary>
        /// Get Singleton Instance with some initialization of instance
        /// </summary>
        /// <param name="initAction">Initialization instance on first creation</param>
        /// <returns>Singleton Instance</returns>
        public static DoubleCheckInitSingleton GetInstance(Action<ISingleton> initAction)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new DoubleCheckInitSingleton();
                        if (initAction != null)
                        {
                            initAction(instance);
                        }
                    }
                }
            }

            return instance;
        }
    }
}