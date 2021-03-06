﻿using System;
using System.Diagnostics.Contracts;

namespace Base
{
    public static class Guard
    {
        public static void AgainstNullOrEmpty(string value)
        {
            Contract.Requires<ArgumentNullException>(value.IsNotNullOrEmpty());
        }

        public static void AgainstNullOrEmpty(Guid value)
        {
            Contract.Requires<ArgumentNullException>(value != Guid.Empty);
        }

        public static void AgainstNullOrEmpty(object value)
        {
            Contract.Requires<ArgumentNullException>(value != null);
        }
    }
}