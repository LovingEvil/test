using BlazorApp.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Web.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Company
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, CompanyName = "Adatech" });
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 2, CompanyName = "Ramwellcom" });
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 3, CompanyName = "Rosko" });
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 4, CompanyName = "RinoSoft" });
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 5, CompanyName = "Totor" });
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 6, CompanyName = "Engala" });

            //Employee
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FirstName = "Яков",
                LastName = "Хохорин",
                PatronymicName = "Андриянович",
                PhoneNumber = "+79025873827",
                CompanyId = 1
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                FirstName = "Светлана",
                LastName = "Зарубина",
                PatronymicName = "Захаровна",
                PhoneNumber = "+79023675410",
                CompanyId = 3
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                FirstName = "Галина",
                LastName = "Сутулина",
                PatronymicName = "Владиленовна",
                PhoneNumber = "+79024708102",
                CompanyId = 2
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 4,
                FirstName = "Никита",
                LastName = "Рощин",
                PatronymicName = "Еремеевич",
                PhoneNumber = "+79029648037",
                CompanyId = 4
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 5,
                FirstName = "Авдей",
                LastName = "Расторгуев",
                PatronymicName = "Евгениевич",
                PhoneNumber = "+79022480750",
                CompanyId = 3
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 6,
                FirstName = "Онуфрий",
                LastName = "Эрнет",
                PatronymicName = "Леонович",
                PhoneNumber = "+79022756964",
                CompanyId = 5
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 7,
                FirstName = "Кир",
                LastName = "Бысов",
                PatronymicName = "Миронович",
                PhoneNumber = "+79024425555",
                CompanyId = 3
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 8,
                FirstName = "Евстигней",
                LastName = "Александрин",
                PatronymicName = "Андриянович",
                PhoneNumber = "+79022032307",
                CompanyId = 2
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 9,
                FirstName = "Кир",
                LastName = "Жиленков",
                PatronymicName = "Миронович",
                PhoneNumber = "+79024661261",
                CompanyId = 6
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 10,
                FirstName = "Людмила",
                LastName = "Яцкевича",
                PatronymicName = "Кузьмевна",
                PhoneNumber = "+79024714458",
                CompanyId = 1
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 11,
                FirstName = "Григорий",
                LastName = "Петров",
                PatronymicName = "Потапович",
                PhoneNumber = "+79022839322",
                CompanyId = 2
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 12,
                FirstName = "Инесса",
                LastName = "Сайтахметова",
                PatronymicName = "Тимофеевна",
                PhoneNumber = "+79029903421",
                CompanyId = 5
            });
        }
    }
}