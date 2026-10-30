using DooKamp.Application.Features.Lessons.GetLessons;
using DooKamp.Application.Interfaces.Lessons;
using DooKamp.Infrastructure.Persistence;
using DooKamp.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using DooKamp.Application.Validators;
using DooKamp.Api.Exceptions;
using DooKamp.Application.Features.Lessons.GetLesson;


// 1. builder 생성 - 앱 시작점, 각종 설정 불러옴
var builder = WebApplication.CreateBuilder(args);


// 2. Register Services - builder.Services: 나중에 필요한 객체들 미리 등록하는 장소.아직 객체는 만들어지지 않는다
builder.Services.AddControllers();
builder.Services.AddDbContext<DooKampDbContext>(opt => 
{
	opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Repository and Handler Registration
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<GetLessonsHandler>();
builder.Services.AddScoped<GetLessonHandler>();

// FluentValidation validators Registration
builder.Services.AddValidatorsFromAssemblyContaining<GetLessonsQueryValidator>();

// Global Exception Handler Registration
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


// 3. 앱 생성. builder -> app
var app = builder.Build();


// 4. Database 초기화 
using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<DooKampDbContext>();
	await DbInitializer.InitializeAsync(dbContext);
}


// 5. Middleware 연결
app.UseExceptionHandler();


// 6. 엔드포인드 연결. 요청 처리 규칙 설정
app.MapControllers();


// 7. 서버 실행 - ASP.NET Core 기본 서버는 Kestrel 실행 
app.Run();

public partial class Program { }