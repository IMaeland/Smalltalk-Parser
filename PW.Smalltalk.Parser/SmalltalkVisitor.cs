using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace PW.Smalltalk.Parser
{
    public class SmalltalkVisitor : SmalltalkBaseVisitor<object>
    {
        public List<object> Lines = new List<object>();

        public override object VisitSourceFile([NotNull] SmalltalkParser.SourceFileContext context)
        {
            return base.VisitSourceFile(context);
        }

        public override object VisitClassDefinition([NotNull] SmalltalkParser.ClassDefinitionContext context)
        {
            return base.VisitClassDefinition(context);
        }

        public override object VisitUnarySend([NotNull] SmalltalkParser.UnarySendContext context)
        {
            return base.VisitUnarySend(context);
        }

        public override object VisitMethod([NotNull] SmalltalkParser.MethodContext context)
        {
            return base.VisitMethod(context);
        }

        public override object VisitBinaryMessage([NotNull] SmalltalkParser.BinaryMessageContext context)
        {
            return base.VisitBinaryMessage(context);
        }

        public override object VisitKeywordSend([NotNull] SmalltalkParser.KeywordSendContext context)
        {
            return base.VisitKeywordSend(context);
        }
    }
}
