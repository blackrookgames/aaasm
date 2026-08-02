namespace aaasm.engine.lxpr
{
    /// <summary>Represents an expression node return type</summary>
    public partial class ENodeValueType
    {
        #region init

        internal ENodeValueType(EType type)
        {
            f_Type = type;
            f_Literal = null;
        }

        internal ENodeValueType(EValue literal)
        {
            f_Type = literal.Type;
            f_Literal = literal;
        }

        #endregion
        
        #region fields

        private readonly EType f_Type;
        private readonly EValue? f_Literal;

        #endregion

        #region properties

        /// <summary>Expression value type</summary>
        public EType Type => f_Type;

        /// <summary>Value literal (if node represents a literal)</summary>
        public EValue? Literal => f_Literal;

        #endregion
    }
}