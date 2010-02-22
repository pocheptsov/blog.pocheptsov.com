#region

using System;

#endregion

namespace Singleton.Singletons
{
    public class SimpleSingleton : ISingleton
    {
        private static volatile SimpleSingleton instance;
        private readonly Random random = new Random((int) DateTime.Now.Ticks);
        private int value;

        protected SimpleSingleton()
        {
        }

        public static SimpleSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SimpleSingleton();
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