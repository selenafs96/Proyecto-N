using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProyectoNApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Recipe = table.Column<string>(type: "text", nullable: true),
                    TimeInMinutes = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Difficulty = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.MealId);
                });

            migrationBuilder.CreateTable(
                name: "Nutrient",
                columns: table => new
                {
                    NutrientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "text", nullable: false),
                    ReferenceIntake = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrient", x => x.NutrientId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dni = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    Occupation = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: true),
                    StreetNumber = table.Column<string>(type: "text", nullable: true),
                    FloorOrDoor = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Province = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    PhysicalActivity = table.Column<string>(type: "text", nullable: false),
                    AlcoholConsumption = table.Column<bool>(type: "boolean", nullable: false),
                    TobaccoConsumption = table.Column<bool>(type: "boolean", nullable: false),
                    Approach = table.Column<string>(type: "text", nullable: false),
                    SpecialDiet = table.Column<string>(type: "text", nullable: true),
                    Observations = table.Column<string>(type: "text", nullable: true),
                    RegisterDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "MealFood",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "integer", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: false),
                    QuantityInGrams = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealFood", x => new { x.MealId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_MealFood_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealFood_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutrientFood",
                columns: table => new
                {
                    NutrientId = table.Column<int>(type: "integer", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: false),
                    QuantityPer100g = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientFood", x => new { x.NutrientId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_NutrientFood_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutrientFood_Nutrient_NutrientId",
                        column: x => x.NutrientId,
                        principalTable: "Nutrient",
                        principalColumn: "NutrientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnthropometricMeasurement",
                columns: table => new
                {
                    MeasurementId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: true),
                    Height = table.Column<decimal>(type: "numeric", nullable: true),
                    FatPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    MusclePercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    Waist = table.Column<decimal>(type: "numeric", nullable: true),
                    Hip = table.Column<decimal>(type: "numeric", nullable: true),
                    Wrist = table.Column<decimal>(type: "numeric", nullable: true),
                    Thigh = table.Column<decimal>(type: "numeric", nullable: true),
                    Calf = table.Column<decimal>(type: "numeric", nullable: true),
                    RelaxedArm = table.Column<decimal>(type: "numeric", nullable: true),
                    ContractedArm = table.Column<decimal>(type: "numeric", nullable: true),
                    BicipitalSkinfold = table.Column<decimal>(type: "numeric", nullable: true),
                    TricipitalSkinfold = table.Column<decimal>(type: "numeric", nullable: true),
                    SubscapularSkinfold = table.Column<decimal>(type: "numeric", nullable: true),
                    SuprailiacSkinfold = table.Column<decimal>(type: "numeric", nullable: true),
                    AbdominalSkinfold = table.Column<decimal>(type: "numeric", nullable: true),
                    SupraspinalSkinfold = table.Column<decimal>(type: "numeric", nullable: true),
                    FrontThighSkinfold = table.Column<decimal>(type: "numeric", nullable: true),
                    MedialCalfSkinfold = table.Column<decimal>(type: "numeric", nullable: true),
                    Observations = table.Column<decimal>(type: "numeric", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnthropometricMeasurement", x => x.MeasurementId);
                    table.ForeignKey(
                        name: "FK_AnthropometricMeasurement_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Format = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Reminder = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalPlan",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Observations = table.Column<string>(type: "text", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalPlan", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_NutritionalPlan_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutritionalPlan_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientPathology",
                columns: table => new
                {
                    PathologyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPathology", x => x.PathologyId);
                    table.ForeignKey(
                        name: "FK_PatientPathology_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientTreatment",
                columns: table => new
                {
                    TreatmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Dose = table.Column<string>(type: "text", nullable: false),
                    Frequency = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTreatment", x => x.TreatmentId);
                    table.ForeignKey(
                        name: "FK_PatientTreatment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientUser",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientUser", x => new { x.PatientId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PatientUser_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restriction",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Observations = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restriction", x => new { x.FoodId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_Restriction_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restriction_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalPlanMeal",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "integer", nullable: false),
                    PlanId = table.Column<int>(type: "integer", nullable: false),
                    MealSlot = table.Column<string>(type: "text", nullable: false),
                    DayOfWeek = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalPlanMeal", x => new { x.MealId, x.PlanId });
                    table.ForeignKey(
                        name: "FK_NutritionalPlanMeal_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutritionalPlanMeal_NutritionalPlan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "NutritionalPlan",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnthropometricMeasurement_PatientId",
                table: "AnthropometricMeasurement",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealFood_FoodId",
                table: "MealFood",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_NutrientFood_FoodId",
                table: "NutrientFood",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalPlan_PatientId",
                table: "NutritionalPlan",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalPlan_UserId",
                table: "NutritionalPlan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalPlanMeal_PlanId",
                table: "NutritionalPlanMeal",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPathology_PatientId",
                table: "PatientPathology",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTreatment_PatientId",
                table: "PatientTreatment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientUser_UserId",
                table: "PatientUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restriction_PatientId",
                table: "Restriction",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnthropometricMeasurement");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "MealFood");

            migrationBuilder.DropTable(
                name: "NutrientFood");

            migrationBuilder.DropTable(
                name: "NutritionalPlanMeal");

            migrationBuilder.DropTable(
                name: "PatientPathology");

            migrationBuilder.DropTable(
                name: "PatientTreatment");

            migrationBuilder.DropTable(
                name: "PatientUser");

            migrationBuilder.DropTable(
                name: "Restriction");

            migrationBuilder.DropTable(
                name: "Nutrient");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "NutritionalPlan");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
