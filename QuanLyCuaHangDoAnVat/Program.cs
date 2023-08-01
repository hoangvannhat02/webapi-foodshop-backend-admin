using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Model;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ISanPhamBusiness, SanPhamBusiness>();
builder.Services.AddTransient<ISanPhamDAL, SanPhamDAL>();
builder.Services.AddTransient<IHoaDonNhapBLL, HoaDonNhapBLL>();
builder.Services.AddTransient<IHoaDonBanBLL, HoaDonBanBLL>();
builder.Services.AddTransient<IHoaDonBanDAL, HoaDonBanDAL>();
builder.Services.AddTransient<IHoaDonNhapDAL, HoaDonNhapDAL>();
builder.Services.AddTransient<ILoaiSanPhamBLL, LoaiSanPhamBLL>();
builder.Services.AddTransient<ILoaiSanPhamDAL, LoaiSanPhamDAL>();
builder.Services.AddTransient<INhaCungCapBLL, NhaCungCapBLL>();
builder.Services.AddTransient<INhaCungCapDAL, NhaCungCapDAL>();
builder.Services.AddTransient<IDataHelper,DatabaseAccess>();
builder.Services.AddTransient<INguoiDungBLL, NguoiDungBLL>();
builder.Services.AddTransient<ILogin, NguoiDungDAL>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// configure strongly typed settings objects
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
// configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

                   

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware Cấu hình thư mục uploads để được phép truy cập qua HTTP
app.UseStaticFiles();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication(); //sử dụng xác thực người dùng

app.UseAuthorization(); //Sử dụng xác thực và quyền truy cập

app.MapControllers();

app.Run();




