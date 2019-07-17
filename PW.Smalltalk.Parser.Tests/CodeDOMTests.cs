using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PW.Smalltalk.Parser.Tests
{
    [TestClass]
    public class CodeDOMTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var code = CodeDOM.CodeGenerator.CreateCode();
            var cs = CodeDOM.CodeGenerator.GenerateCSharpCode(code);
        }
    }
}
