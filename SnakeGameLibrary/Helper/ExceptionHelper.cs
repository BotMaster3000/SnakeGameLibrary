using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGameLibrary.Helper
{
    internal static class ExceptionHelper
    {
        internal static void ThrowArgumentOutOfRangeIfZeroOrLower(string parameterName, int value, bool allowZero = false)
        {
            if ((allowZero && value < 0)
                || (!allowZero && value <= 0))
            {
                throw new ArgumentOutOfRangeException($"Invalid Parameter: {parameterName}={value}");
            }
        }
    }
}
