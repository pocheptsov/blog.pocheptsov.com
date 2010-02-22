#region

using System;

#endregion

namespace Singleton.Singletons
{
    public class NestedSingleton : ISingleton
    {
        private readonly Random random = new Random((int) DateTime.Now.Ticks);

        protected NestedSingleton()
        {
        }

        public static NestedSingleton Instance
        {
            get { return SingletonManager.Instance; }
        }

        #region ISingleton Members

        public void Do()
        {
            Console.Out.WriteLine(random.Next());
        }

        #endregion

        // ReSharper disable ClassNeverInstantiated.Local

        #region Nested type: SingletonManager

        private sealed class SingletonManager

        {
            private static readonly NestedSingleton instance = new NestedSingleton();

            public static NestedSingleton Instance
            {
                get { return instance; }
            }
        }

        #endregion

        // ReSharper restore ClassNeverInstantiated.Local
    }
}