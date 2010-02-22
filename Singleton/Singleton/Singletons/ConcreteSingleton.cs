#region

using System;

#endregion

namespace Singleton.Singletons
{
    public class ConcreteSingleton : ISingleton
    {
        private readonly Random random = new Random((int) DateTime.Now.Ticks);

        protected ConcreteSingleton()
        {
        }

        #region ISingleton Members

        public void Do()
        {
            Console.Out.WriteLine(random.Next());
        }

        #endregion
    }
}