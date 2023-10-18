using System;
using UnityEngine;

namespace Visitor
{
    public abstract class Enemy : MonoBehaviour
    {
        public event Action<Enemy> Died;        
        public abstract EnemyConfig Config { get; }

        //  ака€-то обща€ логика врага: перемещение, жизни и т.п.

        public void MoveTo(Vector3 position) => transform.position = position;

        public void Kill()
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
