


interface IBillable
{
    decimal CalculateCost();
    decimal MonthlyFee { get; }
    decimal TrafficMb  { get; }
    decimal PricePerMb { get; }
}