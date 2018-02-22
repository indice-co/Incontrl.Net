namespace Incontrl.Sdk.Models
{
    public class MemberInfo
    {
        public string Id { get; set; }
        public MemberType Type { get; set; }
        public MemberRoleType Role { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
    }

    /// <summary>
    /// The type of subscription member.
    /// </summary>
    public enum MemberType
    {
        /// <summary>
        /// Application
        /// </summary>
        Application,

        /// <summary>
        /// User
        /// </summary>
        User
    }

    /// <summary>
    /// The type of the role of the subscription member.
    /// </summary>
    public enum MemberRoleType
    {
        /// <summary>
        /// Member
        /// </summary>
        Member = 0,

        /// <summary>
        /// Contributor
        /// </summary>
        Contributor = 1,

        /// <summary>
        /// Owner
        /// </summary>
        Owner = 2
    }
}
