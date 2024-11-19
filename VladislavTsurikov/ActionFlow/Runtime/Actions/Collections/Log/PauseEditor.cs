using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Log
{
    [Name("Debug/Pause Editor")]
    public class PauseEditor : Action
    {
        public override string Name => "Pause Editor";

        protected override UniTask Run(CancellationToken token)
        {
#if UNITY_EDITOR
            Debug.Break();
#endif
            return UniTask.CompletedTask;
        }
    }
}