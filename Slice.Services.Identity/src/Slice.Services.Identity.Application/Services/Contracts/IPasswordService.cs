namespace Slice.Services.Identity.Application.Services.Contracts
{
    public interface IPasswordService
    {
        bool IsValid(string hash, string password);

        string Hash(string password);
    }
}
