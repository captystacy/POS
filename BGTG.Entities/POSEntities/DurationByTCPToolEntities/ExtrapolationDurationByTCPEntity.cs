﻿using System.Collections.Generic;

namespace BGTG.Entities.POSEntities.DurationByTCPToolEntities
{
    public class ExtrapolationDurationByTCPEntity : DurationByTCPEntity
    {
        public decimal VolumeChangePercent { get; set; }
        public decimal StandardChangePercent { get; set; }
        public ICollection<ExtrapolationPipelineStandardEntity> CalculationPipelineStandards { get; set; }
    }
}
