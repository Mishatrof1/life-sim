using System;
using Components;
using Core;
using Leopotam.Ecs;
using Modules;
using UnityEngine;

namespace Systems
{
    public class CharacterFinances : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<CharacterComponent> _characterFilter;
        private EcsFilter<NextWorldDateIteration> _nextIterationFilter;

        public void Init()
        {
        }

        public void Run()
        {
            if (_nextIterationFilter.IsEmpty())
                return;

            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                switch (character.CurrentOccupation)
                {
                    case WorkService service:
                        character.Parameters.Get(ParameterType.Balance.ToString())
                            .Inc(GetIncreaseBalanceValue(service.Salary / WorldDate.MonthsInYear));
                        break;
                    case SimpleWorkService service:
                        character.Parameters.Get(ParameterType.Balance.ToString())
                            .Inc(GetIncreaseBalanceValue(service.Salary / WorldDate.MonthsInYear));
                        break;
                    case MilitaryService service:
                        character.Parameters.Get(ParameterType.Balance.ToString())
                            .Inc(GetIncreaseBalanceValue(service.Salary ));
                        break;
                }

                switch (character.CurrentPartTimeOccupations)
                {
                    case PartTimeServices service:
                        var increaseSalaryValue = service.Salary * service.PartTimePositionConfiguration.HoursPerWeek * 17;
                        if (increaseSalaryValue > 0)
                        {
                            character.Parameters.Get(ParameterType.Balance.ToString()).Inc(increaseSalaryValue);
                        }
                        break;
                }
            }
            foreach (var i in _characterFilter)
            {
                var character = _characterFilter.Get1(i).Character;
                switch (character.CurrentPartTimeOccupations)
                {
                    case PartTimeServices service:
                        character.Parameters.Get(ParameterType.Balance.ToString())
                            .Inc(GetIncreaseBalanceValue(service.Salary / WorldDate.MonthsInYear));
                        break;
                }
            }
        }

        private float GetIncreaseBalanceValue(float monthSalary)
        {
            return monthSalary * (WorldDateModule.Mode switch
            {
                WorldDateMode.FullYear => WorldDate.MonthsInYear,
                WorldDateMode.HalfYear => WorldDate.MonthsInYear / 2,
                _ => throw new ArgumentOutOfRangeException()
            });
        }
    }
}