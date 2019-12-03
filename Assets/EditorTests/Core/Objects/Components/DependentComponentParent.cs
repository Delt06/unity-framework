using Core.Objects;

namespace EditorTests.Core.Objects.Components
{
    public class DependentComponentParent : IDependentObject
    {
        public bool Initialized { get; }
        public IBaseObject Base { get; }
        
        public void Initialize(IBaseObject baseObject)
        {
            throw new System.NotImplementedException();
        }
    }
}