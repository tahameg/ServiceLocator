using System.Collections.Generic;
using UnityEngine;

namespace TahaCore.ServiceLocator
{
    public class ObjectRegistrationScope : RegistrationScopeBase
    {
        [SerializeField] private List<ObjectRegistrationInfo> objectsToRegister;
        protected override void Configure(IServiceLocator serviceLocator)
        {
            
        }

        private void RegisterObjects(IServiceLocator serviceLocator)
        {
            if(objectsToRegister == null) return;

            foreach (var objectInfo in objectsToRegister)
            {
                serviceLocator.Register(objectInfo.SelectedType);
            }
        }
    }
}