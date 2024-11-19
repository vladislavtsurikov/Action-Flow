using System.Threading;
using Cysharp.Threading.Tasks;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Log
{
    [Name("Debug/Comment")]
    public class Comment : Action
    {
        public override string Name => "Pause Editor";

        protected override UniTask Run(CancellationToken token)
        {
            return UniTask.CompletedTask;
        }
    }
}