using System.Threading;
using Cysharp.Threading.Tasks;
using VladislavTsurikov.ComponentStack.Runtime.Core;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions
{
    public abstract class Action : Component
    {
        internal async UniTask RunAction(CancellationToken token)
        {
            if (Active)
            {
                await Run(token);
            }
        }
        
        protected abstract UniTask Run(CancellationToken token);
    }
}