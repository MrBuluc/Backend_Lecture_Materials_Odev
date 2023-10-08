namespace Freelancer.Abstract
{
    public interface IJSONConvertible
    {
        void FromJSON(Dictionary<string, dynamic> json);
        Dictionary<string, dynamic> ToJSON();
    }
}
