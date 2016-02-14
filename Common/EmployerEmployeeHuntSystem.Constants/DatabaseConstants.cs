﻿namespace EmployerEmployeeHuntSystem.Constants
{
    public class DatabaseConstants
    {
        public const string GithubLinkRegex = @"^(http|https):\/\/github.com\/[A-z]+";

        public const int MinCanditatesForJobOffer = 0;

        public const int MinSkillNameLength = 1;
        public const int MaxSkillNameLength = 200;

        public const int MinProjectNameLength = 1;
        public const int MaxProjectNameLength = 100;

        public const int MinProjectDescriptionLength = 10;
        public const int MaxProjectDescriptionLength = 1000;

        public const int MinProjectLinkLength = 1;
        public const int MaxProjectLinkLength = 200;

#if DEBUG
        public const string DbConnectionStringName = "DefaultConnection";
#else
        public const string DbConnectionStringName = "ProductionConnectionString";
#endif
    }
}