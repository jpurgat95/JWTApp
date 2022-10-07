using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Library.Dto;

public class AuthResponseDto
{
    public bool Success { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime TokenExpires { get; set; }
}
