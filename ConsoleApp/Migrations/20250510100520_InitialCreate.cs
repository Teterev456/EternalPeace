using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EternalPeace.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Speciallity = table.Column<string>(type: "text", nullable: false),
                    WorkExperience = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InsuranceType = table.Column<string>(type: "text", nullable: false),
                    InsuranceExpDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumBeds = table.Column<int>(type: "integer", nullable: false),
                    WardType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Diseases = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    WardId = table.Column<int>(type: "integer", nullable: false),
                    TreatmentCost = table.Column<decimal>(type: "numeric", nullable: false),
                    RecordDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DischargeDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedHistories_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedHistories_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedHistories_Wards_WardId",
                        column: x => x.WardId,
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "BirthDate", "Name", "Sex", "Speciallity", "WorkExperience" },
                values: new object[,]
                {
                    { 1, new DateOnly(1986, 7, 3), "Терехов Александр Александрович", "Мужчина", "Кардиолог", 12 },
                    { 2, new DateOnly(1992, 5, 8), "Киселева Валерия Ивановна", "Женщина", "Гастроэнтеролог", 6 },
                    { 3, new DateOnly(1993, 1, 14), "Титова Арина Денисовна", "Женщина", "Нефролог", 5 },
                    { 4, new DateOnly(1981, 11, 27), "Маслов Ян Глебович", "Мужчина", "Гепатолог", 15 },
                    { 5, new DateOnly(1988, 3, 25), "Назарова София Юрьевна", "Женщина", "Кардиолог", 9 },
                    { 6, new DateOnly(1977, 3, 25), "Смирнов Максим Максимович", "Мужчина", "Нефролог", 20 },
                    { 7, new DateOnly(1989, 11, 3), "Осипова Дарья Ивановна", "Женщина", "Гастроэнтеролог", 4 },
                    { 8, new DateOnly(1970, 7, 7), "Быкова Вероника Дамировна", "Женщина", "Гепатолог", 4 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "BirthDate", "InsuranceExpDate", "InsuranceType", "Name", "Sex" },
                values: new object[,]
                {
                    { 1, "102А, Люблинская улица", new DateOnly(1990, 5, 1), null, "Полис ОМС", "Иванов Пётр Васильевич", "Мужчина" },
                    { 2, "24, Новозаводская улица", new DateOnly(1997, 9, 14), null, "Полис ОМС", "Денисова Амина Данииловна", "Женщина" },
                    { 3, "47, Деревня Чепелево", new DateOnly(2001, 1, 3), new DateOnly(2027, 12, 31), "ДМС", "Лаврентьев Даниил Кириллович", "Мужчина" },
                    { 4, "47, 2, Автозаводская улица", new DateOnly(1976, 8, 15), null, "Полис ОМС", "Жуков Алексей Матвеевич", "Мужчина" },
                    { 5, "21А, проспект 50 лет Октября", new DateOnly(1988, 2, 28), null, "Полис ОМС", "Токарева София Тимофеевна", "Женщина" },
                    { 6, "40Ж, Проезжая улица", new DateOnly(1993, 6, 11), null, "Полис ОМС", "Денисова Амина Данииловна", "Женщина" },
                    { 7, "18, улица 1 Мая", new DateOnly(2002, 6, 6), null, "Полис ОМС", "Морозов Карим Даниилович", "Мужчина" },
                    { 8, "8А, улица Руставели", new DateOnly(1996, 9, 8), new DateOnly(2025, 12, 31), "ДМС", "Суслова Полина Дмитриевна", "Женщина" },
                    { 9, "28, Пенягинская улица", new DateOnly(2005, 1, 18), null, "Полис ОМС", "Крюков Никита Романович", "Мужчина" },
                    { 10, "22, Олимпийский проспект", new DateOnly(1977, 8, 29), null, "Полис ОМС", "Гусев Михаил Богданович", "Мужчина" },
                    { 11, "9, Рябиновая улица", new DateOnly(1999, 3, 22), null, "-", "Макаров Марк Макарович", "Мужчина" },
                    { 12, "34, проспект 50 лет Октября", new DateOnly(1965, 4, 7), null, "Полис ОМС", "Новиков Алексей Артёмович", "Мужчина" },
                    { 13, "13, Гончарная улица", new DateOnly(1988, 5, 12), new DateOnly(2025, 3, 12), "ДМС", "Дроздов Степан Александрович", "Мужчина" },
                    { 14, "11, Коммунистическая улица", new DateOnly(2001, 1, 22), null, "Полис ОМС", "Кожевникова Виктория Семёновна", "Женщина" },
                    { 15, "9, Рябиновая улица", new DateOnly(1958, 10, 23), null, "Полис ОМС", "Никонова Лидия Марковна", "Женщина" },
                    { 16, "9, Рябиновая улица", new DateOnly(1959, 7, 1), null, "Полис ОМС", "Никонов Павел Витальевич", "Мужчина" },
                    { 17, "47, Пенягинская улица", new DateOnly(1973, 11, 15), null, "Полис ОМС", "Иванов Федот Павлович", "Мужчина" },
                    { 18, "87, Новозаводская улица", new DateOnly(1998, 11, 11), new DateOnly(2027, 2, 25), "ДМС", "Гусева Мария Богдановна", "Женщина" },
                    { 19, "13, 3-й Железнодорожный тупик", new DateOnly(1988, 4, 27), null, "Полис ОМС", "Петрова Мария Алексеевна", "Женщина" },
                    { 20, "32, Деревня Чепелево", new DateOnly(2000, 2, 2), null, "-", "Орлов Ян Викторович", "Мужчина" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { 1, "O2Esdae1BIpDX7bsgeUv+S1teVqLWpwXBw9qY8l6U7I=", "Admin" },
                    { 2, "phqK32ADh5Kiy4jmcLIFQKnWwsogSrdU/HaJUOeefTY=", "User" },
                    { 3, "xdfiUTEW4g6lVU5g39FwuyDFDTg6oI/Xe789IXQTncw=", "User2" }
                });

            migrationBuilder.InsertData(
                table: "Wards",
                columns: new[] { "Id", "NumBeds", "WardType" },
                values: new object[,]
                {
                    { 1, 4, "Общая палата" },
                    { 2, 4, "Общая палата" },
                    { 3, 2, "Двуместная палата" },
                    { 4, 2, "Двуместная палата" },
                    { 5, 1, "Одноместная палата" },
                    { 6, 1, "Одноместная палата" }
                });

            migrationBuilder.InsertData(
                table: "MedHistories",
                columns: new[] { "Id", "DischargeDate", "Diseases", "DoctorId", "PatientId", "RecordDate", "Status", "TreatmentCost", "WardId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 1, 10), "Гастрит", 2, 1, new DateOnly(2025, 1, 5), "Выписан", 17500m, 1 },
                    { 2, new DateOnly(2025, 1, 14), "Вирусный Гепатит", 4, 2, new DateOnly(2025, 1, 6), "Выписан", 35000m, 4 },
                    { 3, new DateOnly(2025, 1, 11), "Синдром раздражённого кишечника", 2, 3, new DateOnly(2025, 1, 6), "Выписан", 12000m, 3 },
                    { 4, new DateOnly(2025, 1, 16), "Камни в желчном пузыре", 2, 4, new DateOnly(2025, 1, 6), "Выписан", 25000m, 1 },
                    { 5, new DateOnly(2025, 1, 13), "Жёлтуха", 8, 5, new DateOnly(2025, 1, 7), "Выписан", 18500m, 2 },
                    { 6, new DateOnly(2025, 1, 16), "Колит", 7, 6, new DateOnly(2025, 1, 9), "Выписан", 22000m, 2 },
                    { 7, new DateOnly(2025, 1, 14), "Инфекционное заболевание почек", 6, 7, new DateOnly(2025, 1, 9), "Выписан", 20000m, 1 },
                    { 8, new DateOnly(2025, 1, 18), "Порок сердца", 1, 8, new DateOnly(2025, 1, 10), "Выписан", 58000m, 4 },
                    { 9, new DateOnly(2025, 1, 15), "Стеатоз", 4, 9, new DateOnly(2025, 1, 10), "Выписан", 20000m, 1 },
                    { 10, new DateOnly(2025, 1, 16), "Гипертония", 1, 10, new DateOnly(2025, 1, 11), "Выписан", 19500m, 1 },
                    { 11, new DateOnly(2025, 1, 20), "Ишемическая болезнь сердца", 1, 11, new DateOnly(2025, 1, 13), "Выписан", 43500m, 3 },
                    { 12, new DateOnly(2025, 1, 23), "Инфаркт миокарда", 1, 12, new DateOnly(2025, 1, 13), "Выписан", 120000m, 5 },
                    { 13, new DateOnly(2025, 1, 24), "Гломерулонефрит", 1, 13, new DateOnly(2025, 1, 14), "Выписан", 30000m, 3 },
                    { 14, new DateOnly(2025, 1, 20), "Гастрит", 7, 14, new DateOnly(2025, 1, 15), "Выписан", 11500m, 2 },
                    { 15, new DateOnly(2025, 1, 26), "Сердечная недостаточность", 5, 15, new DateOnly(2025, 1, 16), "В плате", 83000m, 6 },
                    { 16, new DateOnly(2025, 1, 23), "Нефролитиаз", 6, 16, new DateOnly(2025, 1, 18), "Выписан", 25000m, 1 },
                    { 17, new DateOnly(2025, 1, 26), "Пиелонефрит", 5, 17, new DateOnly(2025, 1, 19), "В плате", 28500m, 1 },
                    { 18, new DateOnly(2025, 1, 24), "Гастрит", 7, 2, new DateOnly(2025, 1, 19), "В плате", 10000m, 2 },
                    { 19, new DateOnly(2025, 1, 30), "Холестаз", 8, 18, new DateOnly(2025, 1, 20), "В плате", 35000m, 4 },
                    { 20, new DateOnly(2025, 1, 28), "Гипертония", 5, 19, new DateOnly(2025, 1, 21), "В плате", 18000m, 2 },
                    { 21, new DateOnly(2025, 1, 30), "Камни в желчном пузыре", 7, 8, new DateOnly(2025, 1, 21), "В плате", 45000m, 2 },
                    { 22, new DateOnly(2025, 1, 29), "Поликистоз почек", 6, 20, new DateOnly(2025, 1, 22), "В плате", 32500m, 3 },
                    { 23, new DateOnly(2025, 1, 27), "Инфекционные заболевания почек", 3, 5, new DateOnly(2025, 1, 22), "В плате", 18500m, 2 },
                    { 24, new DateOnly(2025, 1, 30), "Язвенная болезнь желудка", 7, 6, new DateOnly(2025, 1, 23), "В плате", 22500m, 2 },
                    { 25, new DateOnly(2025, 1, 30), "Гипертония", 1, 6, new DateOnly(2025, 1, 23), "В плате", 16500m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedHistories_DoctorId",
                table: "MedHistories",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedHistories_PatientId",
                table: "MedHistories",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedHistories_WardId",
                table: "MedHistories",
                column: "WardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedHistories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Wards");
        }
    }
}
