namespace Ex00.GarageLogic
{
    #region GarageEntry

    /// <summary>
    /// The information about a vehicle entered into the garage
    /// </summary>
    public class GarageEntry
    {
        #region properties

        public string OwnerName { get; private set; }

        public string OwnerPhoneNumber { get; private set; }

        public eVehicleState VehicleState { get; set; }

        public IVehicle Vehicle { get; private set; }

        #endregion properties

        #region constructors

        public GarageEntry(string i_OwnerName, string i_OwnerPhoneNumber, IVehicle i_Vehicle)
        {
            VehicleState = eVehicleState.UnderRepair;
            Vehicle = i_Vehicle;
            OwnerName = i_OwnerName;
            OwnerPhoneNumber = i_OwnerPhoneNumber;
        }

        #endregion constructors

        public override string ToString()
        {
            return string.Format(
                "{0}\nVehicle state: {1}\nOwner name: {2}\nOwner phone number: {3}",
                Vehicle,
                VehicleState,
                OwnerName,
                OwnerPhoneNumber);
        }
    }

    #endregion GarageEntry
}