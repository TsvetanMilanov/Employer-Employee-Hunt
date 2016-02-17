namespace EmployerEmployeeHuntSystem.Data.DataImporters
{
    using Models;

    public class SkillsDataImporter : IDataImporter
    {
        public void SeedData(EmployerEmployeeHuntDbContext context)
        {
            var skills = new string[]
                   {
                    "C#",
                    "JavaScript",
                    "Java", "HTML",
                    "CSS",
                    "Objective-C",
                    "Swift", "C++",
                    "ASP",
                    "Handlebars",
                    "PowerShell",
                    "Shell",
                    "SQLPL",
                    "PHP",
                    "TypeScript",
                    "Smalltalk",
                    "CoffeeScript",
                    "Groff",
                    "Ruby",
                    "Python",
                    "OOP",
                    "HQC"
                   };

            foreach (var skillName in skills)
            {
                context.Skills.Add(new Skill
                {
                    Name = skillName
                });
            }

            context.SaveChanges();
        }
    }
}
