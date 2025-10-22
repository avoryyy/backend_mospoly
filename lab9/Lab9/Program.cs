var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // В режиме разработки показываем детальные ошибки
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // В продакшене используем пользовательскую страницу ошибок
    app.UseExceptionHandler("/Home/Error");
    // Обработка ошибок статуса, например 404
    app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");
}

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
