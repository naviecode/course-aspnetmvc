## Controller
- Là một lớp kế thừa từ lớp Controller : Microsfot.AspNetCore.Mvc.Controller
- Action trong controller là một phương thức public (không đc static)
- Action trả về bất kì kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào controller qua hàm tạo
## View
- là file .cshtml
- View cho Action lưu tại: /View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View:

//{0} -> tên action
//{1} -> tên controller
//{2} -> tên Area

## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData