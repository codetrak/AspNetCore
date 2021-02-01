namespace AspNetCore.API.Auth
{
    public enum RoleStatus
    {
        Approved = 400,
        Suspended = 300,
        Revoked = 200,
        Pending = 100
    }
}