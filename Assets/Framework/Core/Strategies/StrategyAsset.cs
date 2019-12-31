using UnityEngine;

namespace Framework.Core.Strategies
{
    public abstract class StrategyAsset<T> : ScriptableObject, IStrategy<T>
    {
        public abstract void Execute(T args);

        internal const string BuiltInPath = "Strategy/";
        protected internal const string CustomPath = BuiltInPath + "Custom/";
    }
}