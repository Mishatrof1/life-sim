using Components;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class CharacterHealth : IEcsRunSystem
    {
        private EcsFilter<CharacterComponent> _charactersFilter;
        private EcsFilter<NextWorldDateIteration> _nextWorldDateIterationFilter;
        public void Run()
        {
            if (_nextWorldDateIterationFilter.IsEmpty())
                return;

            foreach (var i in _charactersFilter)
            {
                var character = _charactersFilter.Get1(i).Character;
                var health = character.Parameters.Get(ParameterType.Health.ToString()).Value;
                var stress = character.Parameters.Get(ParameterType.Stress.ToString()).Value;
                var age = character.Age.TotalYears;

                health += Random.Range(1, 6);

                var chance = 0.5f;

                if (health > 50 && health <= 80) chance = 1;
                if (health > 25 && health <= 50) chance = 1.5f;
                if (health <= 25) chance = 2.5f;

                if (age > 80) chance += (age - 80) * 2;
                if (age > 60) chance += (Mathf.Clamp(age, 61, 80)) - 60;
                if (age > 45) chance += ((Mathf.Clamp(age, 46, 60)) - 45) * 0.5f;

                if (stress == 100)
                    health -= 10;

                if (Random.Range(0f, 100f) <= chance)
                    health -= 100;

                character.Parameters.Get(ParameterType.Health.ToString()).Set(health);
            }

        }
    }
}


