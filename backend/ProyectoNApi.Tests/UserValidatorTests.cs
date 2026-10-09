
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using ProyectoNApi.Context;
using ProyectoNApi.Entities;
using ProyectoNApi.Validators;
    
namespace ProyectoNApi.Tests
{
    public class UserValidatorTests
    {

        /// <summary>
        /// Creates a new, isolated in-memory Entity Framework Core database instance for testing purposes, ensuring test independence by using a unique database name.
        /// </summary>
        private ProyectoNDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ProyectoNDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            return new ProyectoNDbContext(options);
        }

        [Theory]
        [InlineData("")]
        [InlineData("1234567890")]
        [InlineData("12345678X")]
        public async Task Dni_WhenInvalid_ShouldHaveValidationError(string invalidDni)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            UserValidator validator = new(context);

            User user = new User
            {
                UserId = 1,
                Dni = invalidDni,
                Name = "Pepe",
                LastName = "Pérez",
                Email = "email@email.com",
                PhoneNumber = "123456789"
            };

            var result = await validator.TestValidateAsync(user);

            result.ShouldHaveValidationErrorFor(u => u.Dni);
        }


        [Theory]
        [InlineData("89533424J")]
        public async Task Dni_WhenAlreadyExists_ShouldHaveValidationError(string existingDni)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();

            context.User.Add(new User
            {
                UserId = 1,
                Dni = existingDni, 
                Name = "Antiguo",
                LastName = "User",
                Email = "antiguo@email.com",
                PhoneNumber = "+34611111111"
            });

            await context.SaveChangesAsync();

            UserValidator validator = new(context);

            User user = new User
            {
                UserId = 2,
                Dni = existingDni, 
                Name = "Nuevo",
                LastName = "User",
                Email = "nuevoo@email.com",
                PhoneNumber = "+3461111234"
            };

            var result = await validator.TestValidateAsync(user);
            result.ShouldHaveValidationErrorFor(u => u.Dni);
        }

        [Theory]
        [InlineData("")]
        [InlineData("EPfTWFhBztpHhdPBAnAgFmNbLMNxdAxtYZNMHJbOWIhaWRgVroGg")]
        [InlineData("Pe/-pe")]
        [InlineData("   ")]
        public async Task Name_WhenInvalid_ShouldHaveValidationError(string invalidName)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            UserValidator validator = new(context);

            User user = new User
            {
                UserId = 1,
                Dni = "53946757G",
                Name = invalidName,
                LastName = "Pérez",
                Email = "email@email.com",
                PhoneNumber = "123456789"
            };

            var result = await validator.TestValidateAsync(user);

            result.ShouldHaveValidationErrorFor(u => u.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("EPfTWFhBztpHhdPBAnAgFmNbLMNxdAxtYZNMHJbOWIhaWRgVroGgEPfTWFhBztpHhdPBAnAgFmNbLMNxdAxtYZNMHJbOWIhaWRgVroGg")]
        [InlineData("Pe/-pe")]
        [InlineData("   ")]
        public async Task LastName_WhenInvalid_ShouldHaveValidationError(string invalidLastName)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            UserValidator validator = new(context);

            User user = new User
            {
                UserId = 1,
                Dni = "53946757G",
                Name = "Pepe",
                LastName = invalidLastName,
                Email = "email@email.com",
                PhoneNumber = "123456789"
            };

            var result = await validator.TestValidateAsync(user);

            result.ShouldHaveValidationErrorFor(u => u.LastName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("usuario.altamente.especializado.y.completamente.autenticado.99.autenticado.autenticado.autenticado.autenticado.autenticado.autenticado.autenticado.autenticado.autenticado@complejo.com")]
        [InlineData("invalidEmailAddress")]
        public async Task Email_WhenInvalid_ShouldHaveValidationError(string invalidEmail)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            UserValidator validator = new(context);

            User user = new User
            {
                UserId = 1,
                Dni = "53946757G",
                Name = "Pepe",
                LastName = "Pérez",
                Email = invalidEmail,
                PhoneNumber = "123456789"
            };

            var result = await validator.TestValidateAsync(user);
            result.ShouldHaveValidationErrorFor(u => u.Email);
        }

        [Theory]
        [InlineData("existingemail@email.com")]
        public async Task Email_WhenAlreadyExists_ShouldHaveValidationError(string existingEmail)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();

            context.User.Add(new User
            {
                UserId = 1,
                Dni = "53946757G",
                Name = "Antiguo",
                LastName = "Pérez",
                Email = existingEmail,
                PhoneNumber = "123456789"
            });

            await context.SaveChangesAsync();

            UserValidator validator = new(context);

            User user = new User
            {
                UserId = 1,
                Dni = "53946757G",
                Name = "Antiguo",
                LastName = "Pérez",
                Email = existingEmail,
                PhoneNumber = "123456789"
            };

            var result = await validator.TestValidateAsync(user);
            result.ShouldHaveValidationErrorFor(u => u.Email);
        }

        [Theory]
        [InlineData("")]
        [InlineData("658 374938")]
        [InlineData("8934789349834839082397893427398720843849028883")]
        [InlineData("845-353-355")]
        public async Task PhoneNumber_WhenInvalid_ShouldHaveValidationError(string invalidPhoneNumber)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            UserValidator validator = new(context);

            User user = new User
            {
                UserId = 1,
                Dni = "53946757G",
                Name = "Pepe",
                LastName = "Pérez",
                Email = "email@email.com",
                PhoneNumber = invalidPhoneNumber
            };

            var result = await validator.TestValidateAsync(user);

            result.ShouldHaveValidationErrorFor(u => u.PhoneNumber);
        }

        [Theory]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin tristique elit sed lorem imperdiet, a egestas risus aliquet. Quisque pellentesque, ipsum ac dictum vestibulum, sapien tellus pretium erat, sit amet vestibulum nunc mi pharetra mi. Vivamus iaculis purus feugiat magna elementum rhoncus. Mauris pretium non augue id interdum. Phasellus vulputate risus ex, a iaculis urna consequat vel. Nam vulputate nulla tellus, vel accumsan diam condimentum sodales. Vestibulum in augue non erat volutpat consequat ut efficitur metus. Ut scelerisque nisl quis varius accumsan. Curabitur sed luctus mi. Aliquam pulvinar sem vitae libero semper efficitur. Phasellus a accumsan ex. Nunc facilisis sodales sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Maecenas lacinia tellus vel dictum varius. Donec a lectus erat. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Proin vitae accumsan tellus, vitae commodo quam. Cras nec erat at metus congue hendrerit. Phasellus vestibulum, leo sed posuere lobortis, nisl metus porttitor justo, et aliquam nisi urna scelerisque massa. Nulla ac facilisis libero, eget aliquet dolor. Proin fringilla, ipsum sed scelerisque tempus, elit lorem feugiat lacus, non gravida massa purus sollicitudin augue. Proin convallis dolor arcu, sed tempor nunc rhoncus ac. Proin feugiat, erat id facilisis tempor, magna nunc porttitor nisl, eu cursus lorem orci eu ante. Duis non augue diam. Maecenas sodales ligula volutpat augue accumsan, ac porttitor nisl maximus. Nam sodales eleifend massa ut dapibus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Duis vitae quam et tellus volutpat rhoncus eget a elit. Curabitur dictum sem rhoncus interdum elementum. In congue risus eu finibus dictum. Praesent tincidunt eros dolor, non ultrices nisl pretium et. In interdum est eget accumsan pellentesque. In in felis diam. Donec id nunc eu arcu eleifend tempus eget sed enim. Aliquam nec efficitur turpis. Sed interdum nisl ac neque tincidunt hendrerit. Vivamus tempor erat eu turpis scelerisque rhoncus.")]
        public async Task PhotoUrl_WhenInvalid_ShouldHaveValidationError(string invalidPhotoUrl)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            UserValidator validator = new(context);

            User user = new User
            {
                UserId = 1,
                Dni = "53946757G",
                Name = "Pepe",
                LastName = "Pérez",
                Email = "email@email.com",
                PhoneNumber = "+34547395729",
                PhotoUrl = invalidPhotoUrl
            };

            var result = await validator.TestValidateAsync(user);

            result.ShouldHaveValidationErrorFor(u => u.PhotoUrl);
        }
    }
}


