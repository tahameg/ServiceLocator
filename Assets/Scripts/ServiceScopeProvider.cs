using TahaCore.ServiceLocator.Demo.ServiceScopes;
using UnityEngine;

namespace TahaCore.ServiceLocator.Demo
{
    public enum ServiceContext
    {
        Development,
        Production
    }
    
    [DefaultExecutionOrder(-1)]
    public class ServiceScopeProvider : MonoBehaviour
    {
        [SerializeField] ServiceContext context;

        public IServiceScope Scope { get; internal set; }
        public static ServiceScopeProvider Instance { get; internal set; }

        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }
            
            Instance = this;
            
            if (context == ServiceContext.Development)
            {
                Scope = new DevelopmentServiceScope();
            }
            else
            {
                Scope = new ProductionServiceScope();
            }

        }
    }
}