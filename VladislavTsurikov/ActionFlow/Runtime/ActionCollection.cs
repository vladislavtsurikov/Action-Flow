using System.Threading;
using Cysharp.Threading.Tasks;
using VladislavTsurikov.ActionFlow.Runtime.Actions;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime
{
    public class ActionCollection : ComponentStackSupportSameType<Action>
    {
        public async UniTask Run(CancellationToken token)
        {
            foreach (var action in ElementList)
            {
                token.ThrowIfCancellationRequested();
                await action.RunAction(token);
            }
        }
    }
}