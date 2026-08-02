using aaasm.engine.col;

namespace aaasm.engine.lxpr
{
    /// <summary>Represents a macro definition</summary>
    public class Macro
    {
        #region init

        internal Macro(
            string name, bool bracketed, ImmNullHashSet<string> @params, RefPnt refPnt, 
            ImmNullArray<RoughToken> body)
        {
            f_Name = name;
            f_IsFuncLike = bracketed;
            f_Params = @params;
            f_RefPnt = refPnt;
            f_Body = body;
        }

        #endregion
        
        #region fields

        private readonly string f_Name;
        private readonly bool f_IsFuncLike;
        private readonly ImmNullHashSet<string> f_Params;
        private readonly RefPnt f_RefPnt;
        private readonly ImmNullArray<RoughToken> f_Body;

        #endregion
        
        #region properties

        /// <summary>Macro name</summary>
        public string Name => f_Name;

        /// <summary>Whether or not the macro is "function like"</summary>
        public bool IsFuncLike => f_IsFuncLike;

        /// <summary>Macro parameters</summary>
        public ImmNullHashSet<string> Params => f_Params;

        /// <summary>Point of reference</summary>
        public RefPnt RefPnt => f_RefPnt;

        /// <summary>Macro body</summary>
        public ImmNullArray<RoughToken> Body => f_Body;

        #endregion
    }
}
