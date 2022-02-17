﻿using BGTG.Entities.BGTG;
using BGTG.Entities.POS;
using BGTG.Entities.POS.CalendarPlanToolEntities;
using BGTG.Entities.POS.DurationByLCToolEntities;
using BGTG.Entities.POS.DurationByTCPToolEntities;
using BGTG.Entities.POS.EnergyAndWaterToolEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BGTG.Data
{
    public interface IApplicationDbContext
    {
        DbSet<ConstructionObjectEntity> ConstructionObjects { get; set; }
        DbSet<POSEntity> POSes { get; set; }

        #region POS

        DbSet<CalendarPlanEntity> CalendarPlans { get; set; }

        DbSet<PreparatoryCalendarWorkEntity> PreparatoryCalendarWorks { get; set; }

        DbSet<MainCalendarWorkEntity> MainCalendarWorks { get; set; }

        DbSet<PreparatoryConstructionMonthEntity> PreparatoryConstructionMonths { get; set; }

        DbSet<MainConstructionMonthEntity> MainConstructionMonths { get; set; }

        DbSet<DurationByLCEntity> DurationByLCs { get; set; }

        DbSet<ExtrapolationDurationByTCPEntity> ExtrapolationDurationByTCPs { get; set; }

        DbSet<ExtrapolationPipelineStandardEntity> ExtrapolationPipelineStandards { get; set; }

        DbSet<InterpolationDurationByTCPEntity> InterpolationDurationByTCPs { get; set; }

        DbSet<InterpolationPipelineStandardEntity> InterpolationPipelineStandards { get; set; }

        DbSet<StepwiseExtrapolationDurationByTCPEntity> StepwiseExtrapolationDurationByTCPs { get; set; }

        DbSet<StepwiseExtrapolationPipelineStandardEntity> StepwiseExtrapolationPipelineStandards { get; set; }

        DbSet<StepwisePipelineStandardEntity> StepwisePipelineStandards { get; set; }

        DbSet<EnergyAndWaterEntity> EnergyAndWaters { get; set; }

        #endregion

        #region System

        DatabaseFacade Database { get; }

        ChangeTracker ChangeTracker { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        #endregion
    }
}