namespace Freelancer.Abstract
{
    public interface ICSVConvertible
    {
        string GetValuesCSV();
        void SetValuesCSV(string csv);
    }
}
