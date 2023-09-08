using JobApplicationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobApplicationLibrary
{
    public class ApplicationEvaluator
    {
        private const int MinimumAge = 18;
        private const int AutoAcceptedYearsOfExperience = 15;
        private readonly List<string> techStackList = new List<string> { "C#", "Angular", ".Met" };

        public ApplicationResult Evaluate(JobApplication form)
        {
            if (IsUnderAge(form.Applicant.Age))
                return ApplicationResult.AutoRejected;

            var techStackSimilarityRate = GetTechStackSimilarityRate(form.TechStackList);

            if (techStackSimilarityRate < 25)
                return ApplicationResult.AutoRejected;
            if (techStackSimilarityRate < 75 && form.YearOfExperience > AutoAcceptedYearsOfExperience)
                return ApplicationResult.AutoAccepted;

            return ApplicationResult.AutoRejected; // Bu satırı değiştirdim
        }

        private bool IsUnderAge(int age)
        {
            return age < MinimumAge;
        }

        private int GetTechStackSimilarityRate(List<string> techStack)
        {
            if (techStack == null || techStack.Count == 0)
                return 0;

            var matchedCount = techStack
                .Count(i => techStackList.Contains(i, StringComparer.OrdinalIgnoreCase));

            return (int)((double)matchedCount / techStackList.Count * 100);
        }
    }
}

public enum ApplicationResult
{
    AutoRejected,
    TransfeerdToHr,
    TransfferedToCTO,
    AutoAccepted
}
