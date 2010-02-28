 

#region

using System;

#endregion

namespace Singleton.Singletons
{
    public partial class GeneratedSingleton
    {
        
        protected GeneratedSingleton()
        {
        }

        public static GeneratedSingleton Instance
        {
            get { return SingletonManager.Instance; }
        }

        #region Nested type: SingletonManager

        private sealed class SingletonManager

        {
            private static readonly GeneratedSingleton instance = new GeneratedSingleton();

            public static GeneratedSingleton Instance
            {
                get { return instance; }
            }
        }

        #endregion

    }
}

 
