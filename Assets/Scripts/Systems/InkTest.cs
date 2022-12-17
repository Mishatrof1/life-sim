using System.Linq;
using Components;
using DialogSystem;
using Ink.Runtime;
using Leopotam.Ecs;
using Save;
using Settings;
using UnityEngine;

namespace Systems
{
    public class InkTest : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<NpcComponent> _npcFilter;

        public void Init()
        {
        }

        public void Run()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Core.Npc currentNpc = null;
                foreach (var i in _npcFilter)
                {
                    currentNpc = _npcFilter.Get1(i).Npc;
                }
                
                _world.NewEntity().Replace(new InkStoryComponent { StoryName = "TestAgeInkStory"});
            }
        }

    }
}
