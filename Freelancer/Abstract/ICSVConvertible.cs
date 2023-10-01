namespace Freelancer.Abstract
{
    internal interface ICSVConvertible
    {
        string GetValuesCSV();
        void SetValuesCSV(string csv);
    }
}
