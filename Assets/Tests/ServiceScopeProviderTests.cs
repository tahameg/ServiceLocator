using System.Collections;
using NUnit.Framework;
using TahaCore.ServiceLocator.Demo.ServiceScopes;
using UnityEngine;
using UnityEngine.TestTools;

namespace TahaCore.ServiceLocator.Demo.Tests
{
    public class ServiceScopeProviderTests
    {
        public ServiceScopeProviderTests()
        {
            if(ServiceScopeProvider.Instance != null)
            {
                Object.DestroyImmediate(ServiceScopeProvider.Instance.gameObject);
            }
            var serviceScopeProvider = new GameObject("TestServiceScopeProviderHost")
                .AddComponent<ServiceScopeProvider>();
            serviceScopeProvider.Scope = new MockServiceScope();
            ServiceScopeProvider.Instance = serviceScopeProvider;
        }
        
        [UnityTest]
        public IEnumerator ServiceScopeProviderMockTest()
        {
            GameObject enemyObject = new GameObject();
            enemyObject.AddComponent<Enemy>();
            var enemy = enemyObject.GetComponent<Enemy>();
            Assert.IsNotNull(enemy.Info);
            yield return null;
        }
    }
}
