using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.GameObject
{
    [Name("GameObject/Disable Collider")]
    public class GameObjectDisableCollider : GameObjectAction
    {
        public override string Name => $"Disable Collider on {GameObject}";

        protected override UniTask Run(CancellationToken token)
        {
            Collider collider = GameObject.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
            return UniTask.CompletedTask;
        }
    }
}