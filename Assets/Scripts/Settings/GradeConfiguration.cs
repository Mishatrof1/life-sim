using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "GradeConfiguration", menuName = "LifeSim/Education/GradeConfiguration", order = 0)]
    public class GradeConfiguration : ScriptableObject
    {
        [SerializeField] private List<Range> PercentGrade;
        
        [Space]
        [SerializeField] private List<string> LetterGrade;
        [SerializeField] private List<string> Scale40;
        [SerializeField] private List<string> Score5;

        public LetterGradePresenter LetterGradePresenter => new LetterGradePresenter(LetterGrade, PercentGrade);
        public Scale40Presenter Scale40Presenter => new Scale40Presenter(Scale40, PercentGrade);
        public Score5Presenter Score5Presenter => new Score5Presenter(Score5, PercentGrade);
    }

    public abstract class GradePresenter
    {
        protected List<string> _grades;
        private List<Range> _percentGrade;
        
        public GradePresenter(List<string> grades, List<Range> percentGrade)
        {
            _grades = grades;
            _percentGrade = percentGrade;
        }

        public string GetValue(float gradeNormalized)
        {
            var index = GetGradeIndex(gradeNormalized);
            return index > _grades.Count - 1
                ? _grades[_grades.Count - 1]
                : _grades[index];
        }

        protected int GetGradeIndex(float gradeNormalized)
        {
            for (var i = 0; i < _percentGrade.Count; i++)
            {
                var range = _percentGrade[i];
                if (gradeNormalized.InRange(range.Min, range.Max, true, true))
                {
                    return i;
                }
            }

            throw new ArgumentOutOfRangeException();
        }
    }

    public class LetterGradePresenter : GradePresenter
    {
        public LetterGradePresenter(List<string> grades, List<Range> percentGrade) : base(grades, percentGrade) { }
    }

    public class Scale40Presenter : GradePresenter
    {
        public Scale40Presenter(List<string> grades, List<Range> percentGrade) : base(grades, percentGrade) { }
    }
    
    public class Score5Presenter : GradePresenter
    {
        public Score5Presenter(List<string> grades, List<Range> percentGrade) : base(grades, percentGrade) { }
    }
}