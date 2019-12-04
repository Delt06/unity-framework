using Framework.Core.Objects;
using UnityEngine;

namespace Framework.Core.Spawning.Pools
{
    [AddComponentMenu("Pools/Base Object Pool")]
    public class PoolComponent : MonoBehaviour, IPool<IBaseObject>
    {
        [SerializeField] private PoolBaseComponent _prefab = default;
        [SerializeField] private int _size = 50;
        
        private IPool<IBaseObject> _innerPool;

        private void Awake()
        {
            Initialize();
        }

        public IBaseObject Spawn() => _innerPool.Spawn();

        public int Size => _size;
        public bool Initialized => _innerPool != null && _innerPool.Initialized;

        public void Initialize()
        {
            if (Initialized) return;
            
            _innerPool = new BaseObjectPool(Size, () => Instantiate(_prefab, transform));
            _innerPool.Initialize();
        }
    }
}