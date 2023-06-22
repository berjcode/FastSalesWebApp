using QuickSalesApp.WebApi.Configurations;
using QuickSalesApp.WebApi.MiddleWare;

var builder = WebApplication.CreateBuilder(args);



builder.Services.InstallServices(
    builder.Configuration, typeof(IServiceInstaller).Assembly);



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionMiddleware();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.MapControllers();

//using (var scoped = app.Services.CreateScope())
//{
//    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
//    if (!userManager.Users.Any())
//    {
//        userManager.CreateAsync(new AppUser
//        {
//            UserName = "abdullah",
//            Email = "abdblk2525@gmail.com",
//            Id= Guid.NewGuid().ToString(),
//            Name = "Abdullah",
//            SurName = "Balýkçý"
//        },"Password12*").Wait();
//    }
//}

app.Run();
