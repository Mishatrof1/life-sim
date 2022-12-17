using System;
using System.Collections.Generic;
using Core.Job;
using Settings.Job;

namespace Core
{
    public class Organization : BaseObject
    {
        private List<Service> _services;
        public IReadOnlyList<Service> Services => _services.AsReadOnly();
        public List<Vacancy> Vacancies { get; }
        public List<global::Core.Job.Simple.Vacancy> SimpleVacancies { get; }
        public List<PartTimeVacancy> PartTimeVacancies { get; }
        public List<global::Core.Job.Simple.VacancyArmy> ArmyVacancies { get; }
        public Parameters Parameters { get; }
        
        public string Name { get; set; }
        public Location Location { get; set; }
        public OrganizationType Type { get; set; }
        public ScopeType ScopeType { get; set; }

        public float DislikeFactor { get; set; }
        public float TargetDislikeFactor { get; set; }

        public Organization(string id) : base(id)
        {
            _services = new List<Service>();
            Vacancies = new List<Vacancy>();
            SimpleVacancies = new List<global::Core.Job.Simple.Vacancy>();
            PartTimeVacancies = new List<PartTimeVacancy>();
            ArmyVacancies = new List<global::Core.Job.Simple.VacancyArmy>();
            Parameters = new Parameters();
        }



        public List<Vacancy> AvailableVacancies(PositionChainSet positionChainSet)
        {
            return new List<Vacancy>();
        }

        public void AddService(Service service)
        {
            _services.Add(service);
            service.Organization = this;
        }
        
        public void AddVacancy(Core.Job.Simple.Vacancy vacancy)
        {
            SimpleVacancies.Add(vacancy);
            vacancy.Organization = this;
        }
        public void AddPartTimeVacancy(PartTimeVacancy vacancy)
        {
            PartTimeVacancies.Add(vacancy);
            vacancy.Organization = this;
        }
        public void AddVacancyMilitary(Core.Job.Simple.VacancyArmy vacancy)
        {
            ArmyVacancies.Add(vacancy);
            vacancy.Organization = this;
        }
        public WorkService CreateWorkService(Position position)
        {
            return new WorkService(Guid.NewGuid().ToString())
            {
                HoursPerWeek = 40,
                Position = position,
                BaseSalary = CalculateBaseSalary(position)
            };
        }
        
        public WorkService CreateWorkService(Vacancy vacancy)
        {
            return new WorkService(Guid.NewGuid().ToString())
            {
                HoursPerWeek = 40,
                Position = vacancy.Position,
                BaseSalary = CalculateBaseSalary(vacancy.Position)
            };
        }

        private float CalculateBaseSalary(Position position)
        {
            return position.BaseSalary +
                   (position.BaseSalary * 0.5f * Parameters.Get(OrganizationParameter.Wealth.ToString()).Value);
        }
    }
}