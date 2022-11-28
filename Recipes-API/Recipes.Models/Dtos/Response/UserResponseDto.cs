namespace Recipes.Models.Dtos.Response
{
    public class UserResponseDto
    {
        public Guid SessionId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public int ViewSharedEntries { get; set; }
        public int AddEditDeleteSharedEntries { get; set; }
        public int ApproveSharingMyGroups { get; set; }
        public int ApproveSharingAllGroups { get; set; }
        public int ManageUsers { get; set; }
        public int ManageAllEntries { get; set; }
        public int ManageForms { get; set; }
    }
}
