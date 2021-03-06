using System;
using Calculatrice.Simple;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculatrice.Simple.Tests
{
    /// <summary>This class contains parameterized unit tests for SimpleCalculator</summary>
    [TestClass]
    [PexClass(typeof(SimpleCalculator))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SimpleCalculatorTest
    {

        /// <summary>Test stub for Div(Int32, Int32)</summary>
        [PexMethod]
        public int DivTest(
            [PexAssumeUnderTest] SimpleCalculator target,
            int _a,
            int _b
        )
        {
            int result = target.Div(_a, _b);
            return result;
        }
    }
}
