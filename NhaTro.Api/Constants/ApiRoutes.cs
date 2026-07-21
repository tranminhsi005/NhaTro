namespace NhaTro.Api.Constants
{
    public class ApiRoutes
    {
        private const string Base = "api/v1";

        public static class Auth
        {
            public const string Base = $"{ApiRoutes.Base}/auth";
            public const string Register = "register";
            public const string Login = "login";
        }

        public static class Phong
        {
            public const string Base = $"{ApiRoutes.Base}/phong";
            public const string ById = "{id}";
            public const string UploadAnh = "{id}/anh";
        }

        public static class HopDong
        {
            public const string Base = $"{ApiRoutes.Base}/hop-dong";
        }

        public static class HoaDon
        {
            public const string Base = $"{ApiRoutes.Base}/hoa-don";
        }

        public static class KhachThue
        {
            public const string Base = $"{ApiRoutes.Base}/khach-thue";
        }
    }
}
