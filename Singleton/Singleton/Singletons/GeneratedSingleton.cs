#region

using System;

#endregion

namespace Singleton.Singletons
{
    public partial class GeneratedSingleton : ISingleton
    {
        private readonly Random random = new Random((int) DateTime.Now.Ticks);

        #region ISingleton Members

        public void Do()
        {
            Console.Out.WriteLine(random.Next());
        }

        #endregion
    }
}