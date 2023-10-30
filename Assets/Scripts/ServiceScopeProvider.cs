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

        public static IServiceScope Scope { get; internal set; }

        private void Awake()
        {
            if (Scope != null)
            {
                return;
            }

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