/*******************************************************************************
 * Singleton
 * Ensures a class has only one instance, and provides a global point of access
 * to it
 ******************************************************************************/


using System;
namespace DesignPatterns.Lib
{
    public class Singleton
    {
        private static Singleton _uniqueInstance;

        public static Singleton Instance => _uniqueInstance ?? (_uniqueInstance = new Singleton());

        private Singleton() { }
    }
}
