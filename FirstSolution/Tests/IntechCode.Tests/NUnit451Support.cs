using System;
using System.Collections.Generic;
using System.Text;

#if NETCOREAPP1_0

namespace NUnit.Framework
{
    class TestAttribute : Attribute
    {
    }

    class TestFixtureAttribute : Attribute
    {
    }

}

#endif
