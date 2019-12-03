namespace Core.Objects.Bases
{
    public class OrdinaryBaseComponent : BaseComponent
    {
        public sealed override void Destroy()
        {
            Destroy(gameObject);
            
            OnDestroyed();
        }
    }
}