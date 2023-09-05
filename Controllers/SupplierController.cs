using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ehsproject.Entities;
using ehsproject.Helper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace ehsproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly EHS_Context _dbContext;
        private readonly JwtServices _jwtServices;
        public SupplierController(EHS_Context dbContext, JwtServices jwtServices)
        {
            _dbContext = dbContext;
            _jwtServices = jwtServices;
        }
        [HttpPost]
        public IActionResult AddSupplier(Supplier supplier)
        {
            var supData = new Supplier
            {
                SupplierCode = supplier.SupplierCode,
                Pass = BCrypt.Net.BCrypt.HashPassword(supplier.Pass),
            };
            _dbContext.Suppliers.Add(supData);
            _dbContext.SaveChanges();
            return Ok("Success");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Supplier supplier)
        {
            var data = _dbContext.Suppliers.FirstOrDefault(u => u.SupplierCode == supplier.SupplierCode);
            if (data == null)
            {
                return BadRequest("Email not exists");
            }
            if (!supplier.Pass.Equals(data.Pass))
            {
                return BadRequest(new
                {
                    Message = "Invalid Credentials"
                });
            }
            var jwt = _jwtServices.generate(data.SupplierCode);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(new
            {
                message = "Success",
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "Oke"
            });
        }

        [HttpGet]
        public IActionResult Supplier()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtServices.Verify(jwt);
                string supplierCode = token.Issuer;

                var supplier = _dbContext.Suppliers.Find(supplierCode);
                return Ok(supplier);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
        [HttpPut]
        public IActionResult UpdatePassword(string oldPassword, string newPassword)
        {
            try
            {
                // Kiểm tra xem oldPassword và newPassword có hợp lệ không
                if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
                {
                    return BadRequest("Mật khẩu không hợp lệ.");
                }

                var jwt = Request.Cookies["jwt"];
                var token = _jwtServices.Verify(jwt);
                string supplierCode = token.Issuer;

                var supplier = _dbContext.Suppliers.Find(supplierCode);
                if (supplier != null)
                {
                    // Xác thực mật khẩu cũ
                    if (!oldPassword.Equals(supplier.Pass))
                    {
                        return Unauthorized("Mật khẩu cũ không đúng.");
                    }
                    supplier.Pass = newPassword;
                    _dbContext.SaveChanges();
                    return Ok("Cập nhật mật khẩu thành công.");
                }

                return NotFound("Không tìm thấy nhà cung cấp.");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và ghi log
                Console.WriteLine($"Lỗi: {ex.Message}");
                return StatusCode(500, "Đã xảy ra lỗi không mong muốn.");
            }
        }
    }
}
