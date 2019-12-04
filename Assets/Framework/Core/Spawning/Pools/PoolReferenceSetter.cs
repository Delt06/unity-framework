using Framework.Core.Spawning.Assets;
using UnityEngine;

namespace Framework.Core.Spawning.Pools
{
    [AddComponentMenu("Pools/Base Object Pool Reference Setter")]
    public sealed class PoolReferenceSetter : MonoBehaviour
    {
        [SerializeField] private PoolReference _reference = default;
        [SerializeField] private PoolComponent _pool = default;

        private void Awake()
        {
            if (_reference == null)
            {
                Debug.LogError("Reference is not set.", gameObject);
                return;
            }

            if (_pool == null)
            {
                Debug.LogError("Pool is not set.", gameObject);
                return;
            }

            _reference.Pool = _pool;
        }
    }
}