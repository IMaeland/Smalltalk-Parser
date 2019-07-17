using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PW.Smalltalk.Parser.CodeDOM
{
   public class TranslationContext
    {
        public CodeCompileUnit CompileUnit { get; } = new CodeCompileUnit();

    }
}
