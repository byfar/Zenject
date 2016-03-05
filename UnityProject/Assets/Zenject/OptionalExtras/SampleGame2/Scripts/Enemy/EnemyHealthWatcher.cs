using UnityEngine;
using Zenject;

namespace ModestTree
{
    public class EnemyHealthWatcher : ITickable
    {
        readonly Explosion.Factory _explosionFactory;
        readonly CompositionRoot _compRoot;
        readonly EnemyModel _model;

        public EnemyHealthWatcher(
            EnemyModel model,
            CompositionRoot compRoot,
            Explosion.Factory explosionFactory)
        {
            _explosionFactory = explosionFactory;
            _compRoot = compRoot;
            _model = model;
        }

        public void Tick()
        {
            if (_model.Health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            var explosion = _explosionFactory.Create();
            explosion.transform.position = _model.Position;

            GameObject.Destroy(_compRoot.gameObject);
        }
    }
}