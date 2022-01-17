﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using POS.CalendarPlanLogic;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace POSTests.CalendarPlanLogic
{
    [SetCulture("ru-RU")]
    public class CalendarPlanWriterTests
    {
        private CalendarPlanWriter _calendarPlanWriter;

        private const string _calendarPlanTemplatesDirectory = @"..\..\..\CalendarPlanLogic\CalendarPlanTemplates";

        [SetUp]
        public void SetUp()
        {
            _calendarPlanWriter = new CalendarPlanWriter();
        }

        [Test]
        public void Write_CalendarPlan548VAT_SaveCorrectCalendarPlan()
        {
            var expectedCalendarPlan = new CalendarPlan(
                CalendarPlanSource.CalendarPlan548.PreparatoryCalendarWorks.Select(x =>
                    new CalendarWork(x.WorkName, x.TotalCost, x.TotalCostIncludingCAIW, x.ConstructionMonths, 0)),
                CalendarPlanSource.CalendarPlan548.MainCalendarWorks.Select(x =>
                    new CalendarWork(x.WorkName, x.TotalCost, x.TotalCostIncludingCAIW, x.ConstructionMonths, 0)),
                CalendarPlanSource.CalendarPlan548.ConstructionStartDate, 1);

            var preparatoryTemplatePath = Path.Combine(_calendarPlanTemplatesDirectory, "PreparatoryCalendarPlanTemplate.docx");
            var mainTemplatePath = Path.Combine(_calendarPlanTemplatesDirectory, "MainCalendarPlanTemplate1.docx");

            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "CalendarPlan548VAT.docx");
            _calendarPlanWriter.Write(expectedCalendarPlan, preparatoryTemplatePath, mainTemplatePath, savePath);

            using (var document = DocX.Load(savePath))
            {
                var preparatoryCalendarPlanTable = document.Tables[0];
                var mainCalendarPlanTable = document.Tables[1];

                var actualCalendarPlan = ParseCalendarPlan(preparatoryCalendarPlanTable, mainCalendarPlanTable);

                Assert.That(actualCalendarPlan.PreparatoryCalendarWorks, Is.EquivalentTo(expectedCalendarPlan.PreparatoryCalendarWorks));
                Assert.That(actualCalendarPlan.MainCalendarWorks, Is.EquivalentTo(expectedCalendarPlan.MainCalendarWorks));
                Assert.AreEqual(expectedCalendarPlan, actualCalendarPlan);
            }
        }

        private CalendarPlan ParseCalendarPlan(Table preparatoryCalendarPlanTable, Table mainCalendarPlanTable)
        {
            var preparatoryDates = ParseDates(preparatoryCalendarPlanTable.Rows[1]);
            var mainDates = ParseDates(mainCalendarPlanTable.Rows[1]);

            var constructionStartDate = preparatoryDates.First() == mainDates.First()
                ? preparatoryDates.First()
                : default(DateTime);

            var preparatoryCalendarWorks = ParseCalendarWorks(preparatoryCalendarPlanTable, constructionStartDate);

            var mainCalendarWorks = ParseCalendarWorks(mainCalendarPlanTable, constructionStartDate);

            var constructionDurationCeiling = mainCalendarWorks.SingleOrDefault(x => x.WorkName == CalendarPlanInfo.TotalWorkName).ConstructionMonths.Count();

            return new CalendarPlan(preparatoryCalendarWorks, mainCalendarWorks, constructionStartDate, constructionDurationCeiling);
        }

        private IEnumerable<DateTime> ParseDates(Row dateRow)
        {
            var dates = new List<DateTime>();

            for (int i = 3; i < dateRow.ColumnCount; i++)
            {
                var dateStr = dateRow.Paragraphs[i].Text;
                var monthName = Regex.Match(dateStr, @"[А-Я-а-я]+").Value;
                var dateYear = int.Parse(Regex.Match(dateStr, @"\d+").Value);
                var month = Array.IndexOf(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, monthName) + 1;

                dates.Add(new DateTime(dateYear, month, 1));
            }

            return dates;
        }

        private IEnumerable<CalendarWork> ParseCalendarWorks(Table calendarPlanTable, DateTime constructionStartDate)
        {
            var calendarWorks = new List<CalendarWork>();

            for (int row = 2; row < calendarPlanTable.RowCount - 1; row += 2)
            {
                var workName = calendarPlanTable.Rows[row].Paragraphs[0].Text;
                var totalCost = decimal.Parse(calendarPlanTable.Rows[row].Paragraphs[1].Text);
                var totalCostIncludingCaiw = decimal.Parse(calendarPlanTable.Rows[row].Paragraphs[2].Text);

                var constructionMonths = new List<ConstructionMonth>();
                for (int column = 3; column < calendarPlanTable.ColumnCount; column++)
                {
                    decimal.TryParse(calendarPlanTable.Rows[row].Paragraphs[column].Text, out var investmentVolume);
                    decimal.TryParse(calendarPlanTable.Rows[row + 1].Paragraphs[column].Text, out var caiwVolume);

                    var percent = workName == CalendarPlanInfo.TotalWorkName && calendarWorks.Exists(x => x.WorkName == CalendarPlanInfo.MainOverallPreparatoryWorkName)
                        ? decimal.Parse(calendarPlanTable.Rows[row + 2].Paragraphs[column - 1].Text.Replace("%", string.Empty)) / 100
                        : investmentVolume / totalCost;

                    var constructionMonth = new ConstructionMonth(constructionStartDate.AddMonths(column - 3), investmentVolume, caiwVolume, percent, column - 3);
                    constructionMonths.Add(constructionMonth);
                }

                calendarWorks.Add(new CalendarWork(workName, totalCost, totalCostIncludingCaiw, constructionMonths, 0));
            }

            return calendarWorks;
        }
    }
}
