using PdfMaker.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PdfService>();
builder.Services.AddScoped<DocumentService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PDF Maker Apis");
    c.RoutePrefix = "";
});
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
