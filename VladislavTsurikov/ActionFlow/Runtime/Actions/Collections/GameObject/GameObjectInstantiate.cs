using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.GameObject
{
    [Name("GameObject/Instantiate")]
    public class GameObjectInstantiate : GameObjectAction
    {
        [SerializeField]
        private UnityEngine.GameObject _prefab;

        [SerializeField]
        private UnityEngine.GameObject _parent;

        [SerializeField]
        private Transform _point;
        
        public override string Name => $"Instantiate {_prefab}";
        
        protected override UniTask Run(CancellationToken token)
        {
            if (_prefab == null)
            {
                return UniTask.CompletedTask;
            }

            Vector3 position = _point != null ? _point.position : Vector3.zero;
            Quaternion rotation = _point != null ? _point.rotation : Quaternion.identity;

            UnityEngine.GameObject instance = Object.Instantiate(_prefab, position, rotation);

            if (_parent != null)
            {
                instance.transform.SetParent(_parent.transform);
            }

            return UniTask.CompletedTask;
        }
    }
}