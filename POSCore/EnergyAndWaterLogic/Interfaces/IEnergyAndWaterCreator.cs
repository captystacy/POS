﻿namespace POSCore.EnergyAndWaterLogic.Interfaces
{
    public interface IEnergyAndWaterCreator
    {
        EnergyAndWater Create(decimal totalCostIncludingCAIW, int constructionYear);
    }
}
