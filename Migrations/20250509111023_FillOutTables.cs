using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EternalPeace.Migrations
{
    /// <inheritdoc />
    public partial class FillOutTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, new DateOnly(2025, 1, 10), "Гастрит", 2, 1, new DateOnly(2025, 1, 5), "Выписан", 17500, 1 },
                    { 2, new DateOnly(2025, 1, 14), "Вирусный Гепатит", 4, 2, new DateOnly(2025, 1, 6), "Выписан", 35000, 4 },
                    { 3, new DateOnly(2025, 1, 11), "Синдром раздражённого кишечника", 2, 3, new DateOnly(2025, 1, 6), "Выписан", 12000, 3 },
                    { 4, new DateOnly(2025, 1, 16), "Камни в желчном пузыре", 2, 4, new DateOnly(2025, 1, 6), "Выписан", 25000, 1 },
                    { 5, new DateOnly(2025, 1, 13), "Жёлтуха", 8, 5, new DateOnly(2025, 1, 7), "Выписан", 18500, 2 },
                    { 6, new DateOnly(2025, 1, 16), "Колит", 7, 6, new DateOnly(2025, 1, 9), "Выписан", 22000, 2 },
                    { 7, new DateOnly(2025, 1, 14), "Инфекционное заболевание почек", 6, 7, new DateOnly(2025, 1, 9), "Выписан", 20000, 1 },
                    { 8, new DateOnly(2025, 1, 18), "Порок сердца", 1, 8, new DateOnly(2025, 1, 10), "Выписан", 58000, 4 },
                    { 9, new DateOnly(2025, 1, 15), "Стеатоз", 4, 9, new DateOnly(2025, 1, 10), "Выписан", 20000, 1 },
                    { 10, new DateOnly(2025, 1, 16), "Гипертония", 1, 10, new DateOnly(2025, 1, 11), "Выписан", 19500, 1 },
                    { 11, new DateOnly(2025, 1, 20), "Ишемическая болезнь сердца", 1, 11, new DateOnly(2025, 1, 13), "Выписан", 43500, 3 },
                    { 12, new DateOnly(2025, 1, 23), "Инфаркт миокарда", 1, 12, new DateOnly(2025, 1, 13), "Выписан", 120000, 5 },
                    { 13, new DateOnly(2025, 1, 24), "Гломерулонефрит", 1, 13, new DateOnly(2025, 1, 14), "Выписан", 30000, 3 },
                    { 14, new DateOnly(2025, 1, 20), "Гастрит", 7, 14, new DateOnly(2025, 1, 15), "Выписан", 11500, 2 },
                    { 15, new DateOnly(2025, 1, 26), "Сердечная недостаточность", 5, 15, new DateOnly(2025, 1, 16), "В плате", 83000, 6 },
                    { 16, new DateOnly(2025, 1, 23), "Нефролитиаз", 6, 16, new DateOnly(2025, 1, 18), "Выписан", 25000, 1 },
                    { 17, new DateOnly(2025, 1, 26), "Пиелонефрит", 5, 17, new DateOnly(2025, 1, 19), "В плате", 28500, 1 },
                    { 18, new DateOnly(2025, 1, 24), "Гастрит", 7, 2, new DateOnly(2025, 1, 19), "В плате", 10000, 2 },
                    { 19, new DateOnly(2025, 1, 30), "Холестаз", 8, 18, new DateOnly(2025, 1, 20), "В плате", 35000, 4 },
                    { 20, new DateOnly(2025, 1, 28), "Гипертония", 5, 19, new DateOnly(2025, 1, 21), "В плате", 18000, 2 },
                    { 21, new DateOnly(2025, 1, 30), "Камни в желчном пузыре", 7, 8, new DateOnly(2025, 1, 21), "В плате", 45000, 2 },
                    { 22, new DateOnly(2025, 1, 29), "Поликистоз почек", 6, 20, new DateOnly(2025, 1, 22), "В плате", 32500, 3 },
                    { 23, new DateOnly(2025, 1, 27), "Инфекционные заболевания почек", 3, 5, new DateOnly(2025, 1, 22), "В плате", 18500, 2 },
                    { 24, new DateOnly(2025, 1, 30), "Язвенная болезнь желудка", 7, 6, new DateOnly(2025, 1, 23), "В плате", 22500, 2 },
                    { 25, new DateOnly(2025, 1, 30), "Гипертония", 1, 6, new DateOnly(2025, 1, 23), "В плате", 16500, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "MedHistories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Wards",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
