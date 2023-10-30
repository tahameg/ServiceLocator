using System;

namespace TahaCore.ServiceLocator.Demo.ExampleServices
{
    [Serializable]
    public class ActorInfo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Health { get; private set; }
        
        public ActorInfo(int id, string name, int health)
        {
            Id = id;
            Name = name;
            Health = health;
        }
    }
}