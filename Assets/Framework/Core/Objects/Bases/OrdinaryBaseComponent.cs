namespace Framework.Core.Objects.Bases
{
    public class OrdinaryBaseComponent : BaseComponent
    {
        private bool _isDestroyed = false;

        public sealed override bool IsDestroyed => _isDestroyed;

        protected sealed override void DestroyWhenNotDestroyed()
        {
            _isDestroyed = true;
            Destroy(gameObject);
        }
    }
}