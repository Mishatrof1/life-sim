using System.Collections.Generic;
using Settings.Job;

namespace Core.Job
{
    public interface IEmployer
    {
        string Id { get; }
        OrganizationType OrganizationType { get; }
        ScopeType ScopeType { get; }
        List<Vacancy> Vacancies { get; set; }

        bool TryGetJob();
        List<Vacancy> AvailableVacancies(PositionChainSet positionChainSet);
    }
}