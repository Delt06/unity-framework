using UnityEngine;

namespace Framework.Core.Objects.Components
{
    [AddComponentMenu("Extra Cache")]
    public sealed class ExtraCache : DependentComponent
    {
        [SerializeField] private Object[] _objects = default;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            foreach (var obj in _objects)
            {
                Base.Cache(obj);
            }
        }
    }
}