namespace Recipes.Models.Entity.Response.UserLogin
{
    public class sp_Select_USR_UserLogin_Results
    {
        public int usr_Id { get; set; }
        public string? usr_Name { get; set; }
        public string? rol_Id { get; set; }
        public string? rol_Name { get; set; }
        public int rol_ViewSharedEntries { get; set; }
        public int rol_AddEditDeleteSharedEntries { get; set; }
        public int rol_ApproveSharingMyGroups { get; set; }
        public int rol_ApproveSharingAllGroups { get; set; }
        public int rol_ManageUsers { get; set; }
        public int rol_ManageAllEntries { get; set; }
        public int rol_ManageForms { get; set; }
    }
}
