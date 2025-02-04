using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Log
{
    [Name("Debug/Log Text")]
    public class LogTextAction : Action
    {
        [SerializeField]
        private string _message = "My message"; 

        public override string Name => $"Log: {_message}";

        protected override UniTask Run(CancellationToken token)
        {
            Debug.Log(_message);
            return UniTask.CompletedTask;
        }
    }
}