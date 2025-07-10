namespace Cimo.Models
{
    public class FeatureUserAccess
    {
        public int Id { get; set; }
        public byte[] RoleId { get; set; }
        public byte[] FeatureSettingId { get; set; }
        public bool IsActive { get; set; }

        public Role Role { get; set; } = null!;
        public FeatureSetting FeatureSetting { get; set; } = null!;
    }
}
