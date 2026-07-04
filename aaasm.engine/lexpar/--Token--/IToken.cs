using System;
using aaasm.engine.help;

namespace aaasm.engine.lexpar
{
    public interface IToken
    {
        /// <summary>Reference point</summary>
        public RefPnt RefPnt { get; }
    }
}
