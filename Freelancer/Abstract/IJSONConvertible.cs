namespace Freelancer.Abstract
{
    internal interface IJSONConvertible
    {
        void FromJSON(Dictionary<string, dynamic> json);
        Dictionary<string, dynamic> ToJSON();
    }
}
