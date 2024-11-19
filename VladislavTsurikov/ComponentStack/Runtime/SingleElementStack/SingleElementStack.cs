using System;
using VladislavTsurikov.ComponentStack.Runtime.Core;

namespace Assemblies.VladislavTsurikov.ComponentStack.Runtime.SingleElementStack
{
    public class SingleElementStack<T> : ComponentStack<T> where T : Component
    {
        public override void OnRemoveInvalidElements()
        {
            if (_elementList.Count > 1)
            {
                RemoveAll();
            }
        }
        
        public void ReplaceElement(Type elementType)
        {
            RemoveAll();
            Create(elementType);
        }
        
        public void CreateFirstElementIfNecessary(Type elementType)
        {
            if (IsEmpty())
            {
                Create(elementType);
            }
        }
        
        public T GetElement()
        {
            return _elementList.Count > 0 ? _elementList[0] : null;
        }
        
        public bool IsEmpty()
        {
            return _elementList.Count == 0;
        }
    }
}