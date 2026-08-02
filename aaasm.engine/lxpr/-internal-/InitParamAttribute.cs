using System;

#pragma warning disable CS9113

namespace aaasm.engine.lxpr
{
    /// <summary>Used by InitParams.py to determine what properties need to be accounted for</summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class InitParamAttribute(string name = "", string type = "",  string value = "", bool set = true) : Attribute 
    { }
}

#pragma warning restore CS9113