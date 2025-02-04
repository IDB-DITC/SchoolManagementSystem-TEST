using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sp_student_Resport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2025, 2, 11, 12, 1, 30, 752, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2025, 2, 11, 12, 1, 30, 752, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2025, 2, 11, 12, 1, 30, 752, DateTimeKind.Local).AddTicks(893));


            string sql = @"create or alter proc sp_studentDetails
@studentid int
as

select st.AdmissionNo, st.StudentName, sd.StandardName,st.StudentDOB, iif(st.StudentGender=1,'Female', 'Male') as Gender
from Student as st
inner join Standard as sd
on st.StandardId = sd.StandardId
where st.StudentId = @studentid";
            migrationBuilder.Sql(sql);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 6, 4, 15, 44, 20, 185, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 6, 4, 15, 44, 20, 185, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 6, 4, 15, 44, 20, 185, DateTimeKind.Local).AddTicks(9352));



            string dropSql = @"IF (OBJECT_ID('sp_studentDetails') IS NOT NULL)
  DROP PROC sp_studentDetails";


            migrationBuilder.Sql(dropSql);
        }
    }
}
