using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public class Startup
{
    public Startup(IConfigurationRoot configuration)
    {
        Configuration = configuration;
    }
    public IConfigurationRoot Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddDbContext<RecordStoreContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(x => x.MapControllers());
    }
}

public class RecordStoreContext : DbContext
{
    public RecordStoreContext(DbContextOptions<RecordStoreContext> options) : base(options)
    {
        // Nothing needed
    }

    public DbSet<Company> Company { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Products> Products { get; set;  }
}

public class Company
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public bool Hiring { get; set; }
    public string Location { get; set; }
}

public class Employee
{
    [Key]
    public int ID { get; set; }
    public string SSN { get; set; }
    public DateTime DOB { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Department { get; set; }
}
public class Products
{
    [Key]
    public string Name { get; set; }
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}
public class ProductsList
{
    public List<Products> ProductList { get; set; }
}

