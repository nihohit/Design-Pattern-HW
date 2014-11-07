namespace Ex00.GarageLogic
{
    /// <summary>
    /// The state of the vehicle in the garage
    /// </summary>
    public enum eVehicleState
    {
        UnderRepair,
        Repaired,
        Paid
    }

    /// <summary>
    /// the type of the fuel
    /// </summary>
    public enum eFuelType
    {
        Soler,
        Octan96,
        Octan95,
        Octan98,
    }

    /// <summary>
    /// license type for motorcycles
    /// </summary>
    public enum eLicense
    {
        A1,
        A3,
        B1,
        C
    }

    /// <summary>
    /// car color.
    /// </summary>
    public enum eColor
    {
        Green,
        Yellow,
        Blue,
        Black
    }
}