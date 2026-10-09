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

        [Theory]
        [InlineData(99)]
        [InlineData(-1)]
        public async Task Gender_WhenInvalid_ShouldHaveValidationErrors(int invalidGender)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

                Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = (Gender)invalidGender,
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
            result.ShouldHaveValidationErrorFor(p => p.Gender);

        }
        [Theory]
        [InlineData(Gender.Male)]
        [InlineData(Gender.Female)]
        public async Task Gender_WhenValid_ShouldNotHaveValidationErrors(Gender validGender)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

                Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = validGender,
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
            result.ShouldNotHaveValidationErrorFor(p => p.Gender);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras sed ligula id leo finibus varius. Proin id tellus vel puru.")]
        [InlineData("   ")]
        public async Task Occupation_WhenInvalid_ShouldHaveValidationErrors(string invalidOccupation)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

                Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = invalidOccupation,
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
            result.ShouldHaveValidationErrorFor(p => p.Occupation);
        }

        [Theory]
        [InlineData("")]
        [InlineData("paciente.altamente.especializado.y.completamente.autenticado.99.autenticado.autenticado.autenticado.autenticado.autenticado.autenticado.autenticado.autenticado.autenticado@complejo.com")]
        [InlineData("invalidEmailAddress")]
        public async Task Email_WhenInvalid_ShouldHaveValidationErrors(string invalidEmail)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = invalidEmail,
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
            result.ShouldHaveValidationErrorFor(p => p.Email);
        }

        [Theory]
        [InlineData("existingemail@email.com")]
        public async Task Email_WhenAlreadyExists_ShouldHaveValidationError(string existingEmail)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();

            context.Patient.Add(new Patient
            {
                PatientId = 1,
                Dni = "42735168A",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = existingEmail,
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
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = existingEmail,
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
            result.ShouldHaveValidationErrorFor(p => p.Email);
        }

        [Theory]
        [InlineData("")]
        [InlineData("658 374938")]
        [InlineData("8934789349834839082397893427398720843849028883")]
        [InlineData("845-353-355")]
        public async Task PhoneNumber_WhenInvalid_ShouldHaveValidationError(string invalidPhoneNumber)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = invalidPhoneNumber,
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

            result.ShouldHaveValidationErrorFor(p => p.PhoneNumber);
        }
        
        [Theory]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc. Sed in felis ut sem aliquet sodales id in lorem. Quisque scelerisque risus vitae urna laoreet euismod. Proin iaculis lacus sit amet lobortis congue. Vestibulum suscipit justo id purus aliquam, vitae finibus elit scelerisque. Curabitur elementum arcu vel interdum tincidunt. Duis lacinia magna sed ex laoreet, id accumsan tortor eleifend. Phasellus sit amet eleifend ante. Nam.")]
        public async Task Street_WhenInvalid_ShouldHaveValidationError(string invalidStreet)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
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
                Street = invalidStreet,
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

            result.ShouldHaveValidationErrorFor(p => p.Street);
        }
        [Theory]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc.")]
        public async Task StreetNumber_WhenInvalid_ShouldHaveValidationError(string invalidStreetNumber)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
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
                StreetNumber = invalidStreetNumber,
                FloorOrDoor = "3º B",
                City = "Madrid",
                PostalCode = "28001",
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);

            result.ShouldHaveValidationErrorFor(p => p.StreetNumber);
        }

        [Theory]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc.")]
        public async Task FloorOrDoor_WhenInvalid_ShouldHaveValidationError(string invalidFloorOrDoor)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
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
                StreetNumber = "2",
                FloorOrDoor = invalidFloorOrDoor,
                City = "Madrid",
                PostalCode = "28001",
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);

            result.ShouldHaveValidationErrorFor(p => p.FloorOrDoor);
        }
        
        [Theory]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc. Sed in felis ut sem aliquet sodales id in lorem. Quisque scelerisque risus vitae urna laoreet euismod. Proin iaculis lacus sit amet lobortis congue. Vestibulum suscipit justo id purus aliquam, vitae finibus elit scelerisque. Curabitur elementum arcu vel interdum tincidunt. Duis lacinia magna sed ex laoreet, id accumsan tortor eleifend. Phasellus sit amet eleifend ante. Nam.")]
        public async Task City_WhenInvalid_ShouldHaveValidationError(string invalidCity)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
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
                StreetNumber = "2",
                FloorOrDoor = "2ºB",
                City = invalidCity,
                PostalCode = "28001",
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);

            result.ShouldHaveValidationErrorFor(p => p.City);
        }

        [Theory]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc.")]
        public async Task PostalCode_WhenInvalid_ShouldHaveValidationError(string invalidPostalCode)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
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
                StreetNumber = "2",
                FloorOrDoor = "2ªB",
                City = "Madrid",
                PostalCode = invalidPostalCode,
                Province = "Madrid",
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);

            result.ShouldHaveValidationErrorFor(p => p.PostalCode);
        }

        [Theory]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc. Sed in felis ut sem aliquet sodales id in lorem. Quisque scelerisque risus vitae urna laoreet euismod. Proin iaculis lacus sit amet lobortis congue. Vestibulum suscipit justo id purus aliquam, vitae finibus elit scelerisque. Curabitur elementum arcu vel interdum tincidunt. Duis lacinia magna sed ex laoreet, id accumsan tortor eleifend. Phasellus sit amet eleifend ante. Nam.")]
        public async Task Province_WhenInvalid_ShouldHaveValidationError(string invalidProvince)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
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
                StreetNumber = "2",
                FloorOrDoor = "2ºB",
                City = "Madrid",
                PostalCode = "28001",
                Province = invalidProvince,
                Country = "España",
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);

            result.ShouldHaveValidationErrorFor(p => p.Province);
        }

        [Theory]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc. Sed in felis ut sem aliquet sodales id in lorem. Quisque scelerisque risus vitae urna laoreet euismod. Proin iaculis lacus sit amet lobortis congue. Vestibulum suscipit justo id purus aliquam, vitae finibus elit scelerisque. Curabitur elementum arcu vel interdum tincidunt. Duis lacinia magna sed ex laoreet, id accumsan tortor eleifend. Phasellus sit amet eleifend ante. Nam.")]
        public async Task Contry_WhenInvalid_ShouldHaveValidationError(string invalidCountry)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

            Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
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
                StreetNumber = "2",
                FloorOrDoor = "2ºB",
                City = "Madrid",
                PostalCode = "28001",
                Province = "Madrid",
                Country = invalidCountry,
                Observations = "El paciente presenta buena predisposición al tratamiento inicial.",

                SpecialDiet = SpecialDiet.Normal
            };

            var result = await validator.TestValidateAsync(patient);

            result.ShouldHaveValidationErrorFor(p => p.Country);
        }

        [Theory]
        [InlineData(99)]
        [InlineData(-1)]
        public async Task PhysicalActivity_WhenInvalid_ShouldHaveValidationErrors(int invalidPhysicalActivity)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

                Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = (PhysicalActivity)invalidPhysicalActivity,
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
            result.ShouldHaveValidationErrorFor(p => p.PhysicalActivity);

        }
        
        [Theory]
        [InlineData(PhysicalActivity.ExtremelyActive)]
        [InlineData(PhysicalActivity.Sedentary)]
        public async Task PhysicalActivity_WhenValid_ShouldNotHaveValidationErrors(PhysicalActivity validPhysicalActivity)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

                Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = validPhysicalActivity,
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
            result.ShouldNotHaveValidationErrorFor(p => p.PhysicalActivity);
        }

        [Theory]
        [InlineData(99)]
        [InlineData(-1)]
        public async Task Approach_WhenInvalid_ShouldHaveValidationErrors(int invalidApproach)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

                Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.ExtremelyActive,
                AlcoholConsumption = false,
                TobaccoConsumption = false,
                Approach = (Approach)invalidApproach,
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
            result.ShouldHaveValidationErrorFor(p => p.Approach);

        }
        
        [Theory]
        [InlineData(Approach.Clinical)]
        [InlineData(Approach.MuscleGain)]
        public async Task Approach_WhenValid_ShouldNotHaveValidationErrors(Approach validApproach)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

                Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.ExtremelyActive,
                AlcoholConsumption = false,
                TobaccoConsumption = false,
                Approach = validApproach,
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
            result.ShouldNotHaveValidationErrorFor(p => p.Approach);
        }

        [Theory]
        [InlineData(99)]
        [InlineData(-1)]
        public async Task SpecialDiet_WhenInvalid_ShouldHaveValidationErrors(int invalidSpecialDiet)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

                Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.ExtremelyActive,
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

                SpecialDiet = (SpecialDiet)invalidSpecialDiet
            };

            var result = await validator.TestValidateAsync(patient);
            result.ShouldHaveValidationErrorFor(p => p.SpecialDiet);

        }

        [Theory]
        [InlineData(SpecialDiet.Fodmap)]
        [InlineData(SpecialDiet.Normal)]
        public async Task SpecialDiet_WhenValid_ShouldNotHaveValidationErrors(SpecialDiet validSpecialDiet)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

                Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.ExtremelyActive,
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

                SpecialDiet = validSpecialDiet
            };

            var result = await validator.TestValidateAsync(patient);
            result.ShouldNotHaveValidationErrorFor(p => p.SpecialDiet);
        }

        [Theory]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc. Sed in felis ut sem aliquet sodales id in lorem. Quisque scelerisque risus vitae urna laoreet euismod. Proin iaculis lacus sit amet lobortis congue. Vestibulum suscipit justo id purus aliquam, vitae finibus elit scelerisque. Curabitur elementum arcu vel interdum tincidunt. Duis lacinia magna sed ex laoreet, id accumsan tortor eleifend. Phasellus sit amet eleifend ante. Nam nec sem ut sem efficitur finibus. Cras pulvinar feugiat dictum. Vestibulum sit amet molestie leo, ac varius turpis. Morbi pretium iaculis enim, sit amet convallis arcu. Phasellus scelerisque rhoncus dui eget finibus. Aenean cursus condimentum elit, ut porttitor nunc scelerisque eget. Aliquam tempus sem risus, non dictum ligula efficitur eget. Proin dictum erat vel erat ultrices auctor. Vestibulum sit amet nisl tellus. Morbi lacinia metus sit amet nisi dapibus finibus. Vivamus lobortis dictum mauris. Proin quis pharetra ante. Aenean tempus mauris mi, et elementum ex fermentum scelerisque. Mauris interdum, justo vel pulvinar rutrum, eros mauris vulputate eros, ac vulputate leo ex sit amet erat. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce pretium luctus finibus. Quisque vel leo varius, feugiat ipsum aliquet, interdum mi. In congue sodales lectus at gravida. Nullam condimentum ex lacus, ac hendrerit diam bibendum eu. Cras tempor urna id dictum vestibulum. Aliquam erat volutpat. Ut luctus, ex at scelerisque laoreet, dolor ipsum gravida ipsum, in vestibulum felis lorem sed tellus. Phasellus at erat rhoncus, egestas ipsum convallis, tristique dolor. Praesent lacinia dolor quis elit aliquam luctus. Morbi vel sodales elit, id mattis sem. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc. Sed in felis ut sem aliquet sodales id in lorem. Quisque scelerisque risus vitae urna laoreet euismod. Proin iaculis lacus sit amet lobortis congue. Vestibulum suscipit justo id purus aliquam, vitae finibus elit scelerisque. Curabitur elementum arcu vel interdum tincidunt. Duis lacinia magna sed ex laoreet, id accumsan tortor eleifend. Phasellus sit amet eleifend ante. Nam nec sem ut sem efficitur finibus. Cras pulvinar feugiat dictum. Vestibulum sit amet molestie leo, ac varius turpis. Morbi pretium iaculis enim, sit amet convallis arcu. Phasellus scelerisque rhoncus dui eget finibus. Aenean cursus condimentum elit, ut porttitor nunc scelerisque eget. Aliquam tempus sem risus, non dictum ligula efficitur eget. Proin dictum erat vel erat ultrices auctor. Vestibulum sit amet nisl tellus. Morbi lacinia metus sit amet nisi dapibus finibus. Vivamus lobortis dictum mauris. Proin quis pharetra ante. Aenean tempus mauris mi, et elementum ex fermentum scelerisque. Mauris interdum, justo vel pulvinar rutrum, eros mauris vulputate eros, ac vulputate leo ex sit amet erat. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce pretium luctus finibus. Quisque vel leo varius, feugiat ipsum aliquet, interdum mi. In congue sodales lectus at gravida. Nullam condimentum ex lacus, ac hendrerit diam bibendum eu. Cras tempor urna id dictum vestibulum. Aliquam erat volutpat. Ut luctus, ex at scelerisque laoreet, dolor ipsum gravida ipsum, in vestibulum felis lorem sed tellus. Phasellus at erat rhoncus, egestas ipsum convallis, tristique dolor. Praesent lacinia dolor quis elit aliquam luctus. Morbi vel sodales elit, id mattis sem. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc. Sed in felis ut sem aliquet sodales id in lorem. Quisque scelerisque risus vitae urna laoreet euismod. Proin iaculis lacus sit amet lobortis congue. Vestibulum suscipit justo id purus aliquam, vitae finibus elit scelerisque. Curabitur elementum arcu vel interdum tincidunt. Duis lacinia magna sed ex laoreet, id accumsan tortor eleifend. Phasellus sit amet eleifend ante. Nam nec sem ut sem efficitur finibus. Cras pulvinar feugiat dictum. Vestibulum sit amet molestie leo, ac varius turpis. Morbi pretium iaculis enim, sit amet convallis arcu. Phasellus scelerisque rhoncus dui eget finibus. Aenean cursus condimentum elit, ut porttitor nunc scelerisque eget. Aliquam tempus sem risus, non dictum ligula efficitur eget. Proin dictum erat vel erat ultrices auctor. Vestibulum sit amet nisl tellus. Morbi lacinia metus sit amet nisi dapibus finibus. Vivamus lobortis dictum mauris. Proin quis pharetra ante. Aenean tempus mauris mi, et elementum ex fermentum scelerisque. Mauris interdum, justo vel pulvinar rutrum, eros mauris vulputate eros, ac vulputate leo ex sit amet erat. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce pretium luctus finibus. Quisque vel leo varius, feugiat ipsum aliquet, interdum mi. In congue sodales lectus at gravida. Nullam condimentum ex lacus, ac hendrerit diam bibendum eu. Cras tempor urna id dictum vestibulum. Aliquam erat volutpat. Ut luctus, ex at scelerisque laoreet, dolor ipsum gravida ipsum, in vestibulum felis lorem sed tellus. Phasellus at erat rhoncus, egestas ipsum convallis, tristique dolor. Praesent lacinia dolor quis elit aliquam luctus. Morbi vel sodales elit, id mattis sem. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat, urna at volutpat elementum, elit nulla mattis justo, id dignissim dui lorem vel nunc. Sed in felis ut sem aliquet sodales id in lorem. Quisque scelerisque risus vitae urna laoreet euismod. Proin iaculis lacus sit amet lobortis congue. Vestibulum suscipit justo id purus aliquam, vitae finibus elit scelerisque. Curabitur elementum arcu vel interdum tincidunt. Duis lacinia magna sed ex laoreet, id accumsan tortor eleifend. Phasellus sit amet eleifend ante. Nam nec sem ut sem efficitur finibus. Cras pulvinar feugiat dictum. Vestibulum sit amet molestie leo, ac varius turpis. Morbi pretium iaculis enim, sit amet convallis arcu. Phasellus scelerisque rhoncus dui eget finibus. Aenean cursus condimentum elit, ut porttitor nunc scelerisque eget. Aliquam tempus sem risus, non dictum ligula efficitur eget. Proin dictum erat vel erat ultrices auctor. Vestibulum sit amet nisl tellus. Morbi lacinia metus sit amet nisi dapibus finibus. Vivamus lobortis dictum mauris. Proin quis pharetra ante. Aenean tempus mauris mi, et elementum ex fermentum scelerisque. Mauris interdum, justo vel pulvinar rutrum, eros mauris vulputate eros, ac vulputate leo ex sit amet erat. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce pretium l")]
        public async Task Observations_WhenValid_ShouldHaveValidationErrors(string invalidObservations)
        {
            ProyectoNDbContext context = GetInMemoryDbContext();
            PatientValidator validator = new(context);

                Patient patient = new Patient
            {
                PatientId = 2,
                Dni = "89533424J",
                Name = "Alejandro",
                LastName = "García López",
                Birthdate = new DateOnly(1990, 5, 15),
                Gender = Gender.Male,
                Occupation = "Ingeniero de Software",
                Email = "alejandro.garcia2@email.com",
                PhoneNumber = "+34600123456",
                PhysicalActivity = PhysicalActivity.ExtremelyActive,
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
                Observations = invalidObservations,

                SpecialDiet = SpecialDiet.Fodmap
            };

            var result = await validator.TestValidateAsync(patient);
            result.ShouldHaveValidationErrorFor(p => p.Observations);
        }
    }
}