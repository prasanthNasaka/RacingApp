namespace infinitemoto.LookUps
{
    public enum UserRoles
    {
        RaceOrganizer = 1,
        RaceMarshal = 2,
        Scrutiny = 3,
        Timekeeper = 4,
        Rider = 5
    }

    public enum EventType
    {
        TwoWheelerPrescriptions = 6, // 2 wheelers
        FourWheelerPrescriptions = 7, // 4 wheelers
        Karting = 8,
        Grass_Roots = 9,
        ESPORTS = 10,
        Leisure_Tourism = 11,
        Recommended_Reading = 12,
        Environmental_Policy_Sustainability_Guidelines = 13,
        Anti_Harassment = 14
    }

    public enum Category
    {
        TwoWRacing = 15,
        TwoWStageRally = 16,
        TwoWSprintRally = 17,
        TwoWSupercross_Motocross_DirtTrack = 18,
        TwoWDragRacing = 19,
        TwoWHillClimb = 20,
        TwoWTSDRally = 21,
        FourWRacing = 22,
        FourWRally = 23,
        FourWTSDRally = 24,
        FourWRallySprint = 25,
        FourWCrossCountryRally = 26,
        FourWDragRacing = 27,
        FourWHillClimbRacing = 28,
        FourWAutoCross = 29,
        FourWTimeAttack = 30,
        FourWAutokhana = 31,
        CrossCars = 32,
        KartingTwoStroke = 33,
        KartingFourStroke = 34,
        FourWOpenKhana = 35,
        FourWDriveDash = 36,
        KartingSlalom = 37,
        KartingSpeedster = 38,
        TwoWRideRush = 39,
        GrassrootsTSD = 40,
        KartingSlalomGrass = 41
    }

    public enum AuthenticationRoles
    {
        Unknown = 42,
        SuperAdmin = 43,
        Admin = 44,
        Register = 45,
        Account = 46,
        Scrutiny = 47
    }

    public enum CategoryEnum
    {
        CC1600 = 48,
        CC1800 = 49
    }

    public enum BloodGroup
    {
        A_Positive = 50,
        A_Negative = 51,
        B_Positive = 52,
        B_Negative = 53,
        O_Positive = 54,
        O_Negative = 55,
        AB_Positive = 56,
        AB_Negative = 57
    }

    public enum VechDoc
    {
        Registration_Certificate = 58,
        Insurance_Certificate = 59,
        Pollution_Certificate = 60,
        Fitness_Certificate = 61,
        Permit_Certificate = 62,
        Tax_Certificate = 63,
        Other = 64
    }
}
