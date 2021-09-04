using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FlyingDutchmanAirlines 
{
  class Startup 
  { 
    public void Configure(IApplicationBuilder app)
    {
      app.UseRouting();
      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
    }
        // "ConnectionStrings": {
        //    "sqlConnection": "server=localhost, 1433; database=CompanyEmployee; User Id=sa; Password=P@55word;"
        // },
  }
}
