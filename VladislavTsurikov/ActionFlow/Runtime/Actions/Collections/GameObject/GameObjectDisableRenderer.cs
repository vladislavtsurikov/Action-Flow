using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.GameObject
{
    [Name("GameObject/Disable Renderer")]
    public class GameObjectDisableRenderer : GameObjectAction
    {
        public override string Name => $"Disable Renderer on {GameObject}";

        protected override UniTask Run(CancellationToken token)
        {
            Renderer renderer = GameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
            return UniTask.CompletedTask;
        }
    }
}