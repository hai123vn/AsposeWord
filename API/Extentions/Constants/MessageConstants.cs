
namespace API.Extentions.Constants
{
    public static class UserSystem
    {
        public static string UsernameConnected;
    }
    public static class MessageConstants
    {

        // Login Authentication
        public static string UsernameNotFound = "Username không tồn tại";
        public static string PasswordWrong = "Sai mật khẩu";
        public static string Your_Account_Is_Locked = "Tài khoản của bạn đã bị khoá? Liên hệ Administrator để mở khoá";

        // Add 
        public static string Add_Success = "Thêm mới thành công";
        public static string Add_Error = "Thêm mới thất bại";

        //Update

        public static string Update_Success = "Cập nhật thành công";
        public static string Update_Error = "Cập nhật thất bại";

        // Remove
        public static string Remove_Success = "Xoá thành công";
        public static string Remove_Error = "Xoá thất bại";

        // Exist
        public static string Existed = "Đối tượng này đã tồn tại.";
        public static string Used = "Đối tượng này đang được sử dụng";
        public static string None_Existed = "Đối tượng này không tồn tại.";

        public static string Invalid = "Không hợp lệ!";
        public static string Password_Not_Exactly = "Mật khẩu cũ không chính xác !";
        public static string Change_Password_Success = "Thay đổi mật khẩu thành công !";
        public static string Change_Password_Error = "Thay đổi mật khẩu thất bại !";

    }
}