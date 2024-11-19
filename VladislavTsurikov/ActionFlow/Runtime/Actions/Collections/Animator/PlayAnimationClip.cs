using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VladislavTsurikov.ComponentStack.Runtime.AdvancedComponentStack;

namespace VladislavTsurikov.ActionFlow.Runtime.Actions.Animator
{
    [Name("Animator/Play Animation")]
    public class PlayAnimationClip : ActionAnimator
    {
        [SerializeField]
        private AnimationClip _clip;

        public override string Name => $"Play Animation {_clip?.name}";

        protected override UniTask Run(CancellationToken token)
        {
            if (_clip != null)
            {
                Animator.Play(_clip.name);
            }
            return UniTask.CompletedTask;
        }
    }
}