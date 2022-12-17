using Settings.Job;

namespace Core.Job
{
    public interface IApplicant
    {
        EducationResultType Education { get; }
        
        float GetSkillValue(SkillType type);
        float GetExperience(Position position);
    }
}