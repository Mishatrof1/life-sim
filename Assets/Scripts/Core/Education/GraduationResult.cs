using Save;

namespace Core.Education
{
    public class GraduationResult
    {
        public GraduationResultType Type { get; private set; }
        public StudyDirectionType StudyDirection { get; private set; }
        public Parameter AcademicPerformance { get; private set; }
        public EducationService EducationService { get; set; }

        public GraduationResult(EducationService educationService, GraduationResultType type, StudyDirectionType studyDirection)
        {
            Type = type;
            StudyDirection = studyDirection;
            EducationService = educationService;
            AcademicPerformance = new Parameter(0, 0, 100);
        }

        public GraduationResult(GraduationResultSave saveData)
            : this(null, saveData.Type, saveData.StudyDirection)
        {
            Type = saveData.Type;
            StudyDirection = saveData.StudyDirection;
            AcademicPerformance = new Parameter(saveData.AcademicPerformance);
        }
    }

    public enum GraduationResultType
    {
        None                              = 0,
        HighSchoolCertificate             = 1,
        HighSchoolGraduationDiploma       = 2,
        CommunityCollegeGraduationDiploma = 3,
        UniversityGraduationDiploma       = 4
    }
}