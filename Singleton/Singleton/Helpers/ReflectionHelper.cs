#region

using System;
using System.Reflection;

#endregion

namespace Singleton.Helpers
{
    internal static class ReflectionHelper<T>
    {
        internal static T CreateType()
        {
            ConstructorInfo constructor = typeof (T).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new Type[0],
                new ParameterModifier[0]);

            try
            {
                return (T) constructor.Invoke(null);
            }
            catch (Exception exception)
            {
                throw new TypeCreationException(
                    "Type " + typeof (T).FullName + "does not have parameterless constructor", exception);
            }
        }
    }
}