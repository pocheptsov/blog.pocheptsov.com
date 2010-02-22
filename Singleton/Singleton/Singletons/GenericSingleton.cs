#region

using Singleton.Helpers;

#endregion

namespace Singleton.Singletons
{
    public abstract class GenericSingleton<T> : ISingleton where T : class
    {
        protected GenericSingleton()
        {
        }

        public static T Instance
        {
            get { return SingletonManager<T>.CreatorInstance; }
        }

        #region ISingleton Members

        public abstract void Do();

        #endregion

        // ReSharper disable ClassNeverInstantiated.Local

        #region Nested type: SingletonManager

        private sealed class SingletonManager<TSingleton> where TSingleton : class
        {
            private static readonly TSingleton instance;

            static SingletonManager()
            {
                instance = ReflectionHelper<TSingleton>.CreateType();
            }

            public static TSingleton CreatorInstance
            {
                get { return instance; }
            }
        }

        #endregion

        // ReSharper restore ClassNeverInstantiated.Local
    }
}