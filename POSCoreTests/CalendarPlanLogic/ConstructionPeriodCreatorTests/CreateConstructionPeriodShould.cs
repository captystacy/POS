﻿using NUnit.Framework;
using POSCore.CalendarPlanLogic;
using POSCore.CalendarPlanLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POSCoreTests.CalendarPlanLogic.ConstructionPeriodCreatorTests
{
    public class CreateConstructionPeriodShould
    {
        private IConstructionPeriodCreator _constructionPeriodCreator;

        [SetUp]
        public void SetUp()
        {
            _constructionPeriodCreator = new ConstructionPeriodCreator();
        }

        [Test]
        public void NotReturnNull()
        {
            var constructionPeriod = _constructionPeriodCreator.CreateConstructionPeriod(DateTime.Today, 0, 0, new decimal[] { 0 });

            Assert.NotNull(constructionPeriod);
        }

        [Test]
        public void ReturnConstructionPeriod_InWhichSetFirstConstructionMonthDateToInitialDate()
        {
            var initialDate = new DateTime(1999, 9, 21);
            var costructionPeriod = _constructionPeriodCreator.CreateConstructionPeriod(initialDate, 0, 0, new decimal[] { 1 });

            var constructionPeriodMonth = costructionPeriod.ConstructionMonths.First();

            Assert.AreEqual(constructionPeriodMonth.Date, initialDate);
        }

        [Test]
        public void ReturnConstructionPeriod_InWhichSetConstructionMonthsDatesInOrder()
        {
            var initialDate = new DateTime(1999, 9, 21);
            var costructionPeriod = _constructionPeriodCreator.CreateConstructionPeriod(initialDate, 0, 0, new decimal[] { 0, 0, 0 });

            var constructionPeriodMonths = costructionPeriod.ConstructionMonths.ToArray();

            for (int i = 0; i < constructionPeriodMonths.Length; i++)
            {
                Assert.AreEqual(constructionPeriodMonths[i].Date.Month, initialDate.Month + i);
            }
        }

        [Test]
        public void ReturnConstructionPeriod_InWhichConstructionMonthsDateYearEqualPassedInitialDateYear()
        {
            var initialDate = new DateTime(1999, 9, 21);

            var constructionPeriod = _constructionPeriodCreator.CreateConstructionPeriod(initialDate, 0, 0, new decimal[] { 0, 0, 0 });

            foreach (var consturctionMonth in constructionPeriod.ConstructionMonths)
            {
                Assert.AreEqual(initialDate.Year, consturctionMonth.Date.Year);
            }
        }

        [Test]
        public void ReturnConstructionPeriod_AddYearIfInitialDatesYearEnds()
        {
            var initialDate = new DateTime(1999, 12, 21);

            var percentages = new List<decimal>();
            for (int i = 1; i < 30; i++)
            {
                percentages.Add((decimal)i / 100);
            }

            var expectedYears = percentages.Select(x =>
                x == (decimal)0.01 ? initialDate.Year :
                x <= (decimal)0.13 ? initialDate.Year + 1 :
                x <= (decimal)0.25 ? initialDate.Year + 2 :
                initialDate.Year + 3).ToArray();

            var constructionPeriod = _constructionPeriodCreator.CreateConstructionPeriod(initialDate, 0, 0, percentages.ToArray());

            var constructionMonths = constructionPeriod.ConstructionMonths.ToArray();

            for (int i = 0; i < percentages.Count; i++)
            {
                Assert.AreEqual(expectedYears[i], constructionMonths[i].Date.Year);
            }
        }

        [Test]
        public void ReturnConstructionPeriod_InWhichCountOfConstructionMonthsEqualPassedPercentParameters()
        {
            var constructionPeriod = _constructionPeriodCreator.CreateConstructionPeriod(DateTime.Today, 0, 0, new decimal[] { 1, 1, 1 });

            Assert.AreEqual(3, constructionPeriod.ConstructionMonths.Count());
        }

        [Test]
        public void ReturnConstructionPeriod_InWhichSetFirstConstructionMonthPercentPartToFirstPassedPercent()
        {
            var totalCost = (decimal)123.124;
            var percent1 = (decimal)0.45;
            var constructionPeriod = _constructionPeriodCreator.CreateConstructionPeriod(DateTime.Today, totalCost, 0, new decimal[] { percent1 });

            Assert.AreEqual(percent1, constructionPeriod.ConstructionMonths.First().PercentePart);
        }

        [Test]
        public void ReturnConstructionPeriod_InWhichSetFirstConstructionMonthInvestmentVolume_ToPassedTotalCostMultiplyFirstPassedPercentDividedByOneHundred()
        {
            var totalCost = (decimal)123.124;
            var percent1 = (decimal)0.45;
            var constructionPeriod = _constructionPeriodCreator.CreateConstructionPeriod(DateTime.Today, totalCost, 0, new decimal[] { percent1 });

            Assert.AreEqual((decimal)55.406, constructionPeriod.ConstructionMonths.First().InvestmentVolume);
        }

        [Test]
        public void ReturnConstructionPeriod_InWhichSetFirstConstructionMonthContructionAndInstallationWorksVolume_ToPassedtotalCostIncludingContructionAndInstallationWorksMultiplyFirstPassedPercentDividedByOneHundred()
        {
            var totalCostIncludingContructionAndInstallationWorks = (decimal)123.124;
            var percent1 = (decimal)0.45;
            var constructionPeriod = _constructionPeriodCreator.CreateConstructionPeriod(DateTime.Today, 0, totalCostIncludingContructionAndInstallationWorks, new decimal[] { percent1 });

            Assert.AreEqual((decimal)55.406, constructionPeriod.ConstructionMonths.First().ContructionAndInstallationWorksVolume);
        }

        [Test]
        public void ReturnConstructionPeriod_InWhichSetCorrectConstructionMonthIndex()
        {
            var constructionPeriod = _constructionPeriodCreator.CreateConstructionPeriod(
                DateTime.Today, 
                0, 
                (decimal) 1.111, 
                new decimal[] 
                { 
                    0, (decimal)1.001, (decimal)-0.12, (decimal)0.34
                });

            var constructionMonth = constructionPeriod.ConstructionMonths.Single();

            Assert.AreEqual(3, constructionMonth.Index);
        }
    }
}
