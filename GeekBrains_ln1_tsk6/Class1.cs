using System;

namespace ExtensionMethods
{
    //add reference to .dll file to use ExtensionMethods
    public static class Helpers
    {
        //Ремизов Павел
        /*
         * *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
        */
        public static bool isNaN(this string msg)
        {
            double value;
            return double.TryParse(msg, out value);
        }
    }
}
