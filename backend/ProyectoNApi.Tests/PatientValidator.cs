using Microsoft.EntityFrameworkCore;
using FluentValidation.TestHelper;
using System.Globalization;

using ProyectoNApi.Context;
using ProyectoNApi.Validators;
using ProyectoNApi.Entities;

namespace ProyectoNApi.Tests
{
    public class PatientValidatorTests
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
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 1,
                Dni = invalidDni,
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.LightlyActive,
                AlcoholConsumption = false,
                TobaccoConsumption = false,
                Approach = Approach.Clinical,
                IsActive = true,

                // Optional properties
                Street = "Avenida de la Constitución",
                StreetNumber = "45",
                FloorOrDoor = "3º B",
                City = "Madrid",
                PostalCode = "28001",
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);

            result.ShouldHaveValidationErrorFor(p => p.Dni);
        }


        [Theory]
        [InlineData("89533424J")]
        public async Task Dni_WhenAlreadyExists_ShouldHaveValidationError(string existingDni)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();

            context.Patient.Add(new Patient
            {
                PatientId = 1,
                Dni = existingDni,
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.LightlyActive,
                AlcoholConsumption = false,
                TobaccoConsumption = false,
                Approach = Approach.Clinical,
                IsActive = true,

                // Optional properties
                Street = "Avenida de la Constitución",
                StreetNumber = "45",
                FloorOrDoor = "3º B",
                City = "Madrid",
                PostalCode = "28001",
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            });

            await context.SaveChangesAsync();

            PatientValidator validator = new(context);

             Patient patient = new Patient
            {
                PatientId = 2,
                Dni = existingDni,
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.LightlyActive,
                AlcoholConsumption = false,
                TobaccoConsumption = false,
                Approach = Approach.Clinical,
                IsActive = true,

                // Optional properties
                Street = "Avenida de la Constitución",
                StreetNumber = "45",
                FloorOrDoor = "3º B",
                City = "Madrid",
                PostalCode = "28001",
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);

            result.ShouldHaveValidationErrorFor(p => p.Dni);
        }

        [Theory]
        [InlineData("")]
        [InlineData("EPfTWFhBztpHhdPBAnAgFmNbLMNxdAxtYZNMHJbOWIhaWRgVroGg")]
        [InlineData("Pe/-pe")]
        [InlineData("   ")]
        public async Task Name_WhenInvalid_ShouldHaveValidationError(string invalidName)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = invalidName,
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.LightlyActive,
                AlcoholConsumption = false,
                TobaccoConsumption = false,
                Approach = Approach.Clinical,
                IsActive = true,

                // Optional properties
                Street = "Avenida de la Constitución",
                StreetNumber = "45",
                FloorOrDoor = "3º B",
                City = "Madrid",
                PostalCode = "28001",
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);

            result.ShouldHaveValidationErrorFor(p => p.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("EPfTWFhBztpHhdPBAnAgFmNbLMNxdAxtYZNMHJbOWIhaWRgVroGgEPfTWFhBztpHhdPBAnAgFmNbLMNxdAxtYZNMHJbOWIhaWRgVroGg")]
        [InlineData("Pe/-pe")]
        [InlineData("   ")]
        public async Task LastName_WhenInvalid_ShouldHaveValidationError(string invalidLastName)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
               PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = invalidLastName,
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.LightlyActive,
                AlcoholConsumption = false,
                TobaccoConsumption = false,
                Approach = Approach.Clinical,
                IsActive = true,

                // Optional properties
                Street = "Avenida de la Constitución",
                StreetNumber = "45",
                FloorOrDoor = "3º B",
                City = "Madrid",
                PostalCode = "28001",
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);

            result.ShouldHaveValidationErrorFor(p => p.LastName);
        }

        [Theory]
        [InlineData("2050-01-01")]
        [InlineData("1800-01-01")]
        public async Task Birthdate_WhenInvalid_ShouldHaveValidationError(string invalidBirthdateString)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            DateOnly invalidBirthate = DateOnly.ParseExact(invalidBirthdateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = invalidBirthate,
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.LightlyActive,
                AlcoholConsumption = false,
                TobaccoConsumption = false,
                Approach = Approach.Clinical,
                IsActive = true,

                // Optional properties
                Street = "Avenida de la Constitución",
                StreetNumber = "45",
                FloorOrDoor = "3º B",
                City = "Madrid",
                PostalCode = "28001",
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);
            result.ShouldHaveValidationErrorFor(p => p.Birthdate);
        }

        [Fact]
public async Task Birthdate_WhenEmpty_ShouldHaveValidationError()
{
    ProyectoNDbContext context = GetInMemoryDbContext();
    PatientValidator validator = new(context);

    Patient patient = new Patient
    {
       PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = default,
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.LightlyActive,
                AlcoholConsumption = false,
                TobaccoConsumption = false,
                Approach = Approach.Clinical,
                IsActive = true,

                // Optional properties
                Street = "Avenida de la Constitución",
                StreetNumber = "45",
                FloorOrDoor = "3º B",
                City = "Madrid",
                PostalCode = "28001",
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
    };

    var result = await validator.TestValidateAsync(patient);
    result.ShouldHaveValidationErrorFor(p => p.Birthdate);
}
    }
}