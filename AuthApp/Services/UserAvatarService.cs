using AuthApp.Models;

namespace AuthApp.Services
{
    public class UserAvatarService : IUserAvatar<AvatarUser>
    {
        public string FindAvatar(int idUser, string srcImage)
        {
            return File.Exists(srcImage) ? srcImage : string.Empty;
        }

        public string CreateAvatar(int idUser, IFormFile image)
        {
            if (image == null || image.Length == 0) return string.Empty;


            var fileName = $"{idUser}_{Guid.NewGuid()}_{image.FileName}";
            var filePath = Path.Combine("wwwroot/images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return $"/images/{fileName}";
        }

        public string EditAvatar(int idUser, IFormFile image)
        {
            return CreateAvatar(idUser, image);
        }

        public bool DeleteAvatar(int idUser, string srcImage)
        {
            var filePath = Path.Combine("wwwroot", srcImage.TrimStart('/'));
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
    }
}
