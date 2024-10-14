namespace AuthApp.Services
{
    public interface IUserAvatar<T>
    {
        public string FindAvatar(int idUser, string srcImage);
        public string CreateAvatar(int idUser, IFormFile srcImage);
        public string EditAvatar(int idUser, IFormFile srcImage);
        public bool DeleteAvatar(int idUser, string srcImage);
    }
}
