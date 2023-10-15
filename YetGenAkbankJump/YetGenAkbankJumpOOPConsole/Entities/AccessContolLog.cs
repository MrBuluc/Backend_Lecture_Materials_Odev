using YetGenAkbankJumpOOPConsole.Common;
using YetGenAkbankJumpOOPConsole.Enums;

namespace YetGenAkbankJumpOOPConsole.Entities
{
    public class AccessContolLog : EntityBase<Guid>
    {
        public AccessType AccessType { get; set; }
        public DateTime LogTime { get; set; }
        public long PersonId { get; set; }
        public string DeviceSerialNo { get; set; }

        public static AccessType ConvertStringToAccessType(string accessType)
        {
            return accessType switch
            {
                "FP" => AccessType.FingerPrint,
                "FACE" => AccessType.Face,
                "CARD" => AccessType.Card,
                _ => throw new Exception("CiYuAydi"),
            };
        }
    }
}
