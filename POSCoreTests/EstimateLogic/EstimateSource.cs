﻿using System;
using System.Collections.Generic;
using POS.EstimateLogic;

namespace POSTests.EstimateLogic
{
    public static class EstimateSource
    {
        public readonly static Estimate Estimate548VAT = new Estimate(new List<EstimateWork>
            {
                new EstimateWork("Вынос трассы в натуру", 0, 0.013M, 0.013M, 1),
                new EstimateWork("Одд на период производства работ", 0, 0, 0.005M, 8),
                new EstimateWork("Временные здания и сооружения 8,56х0,93 - 7,961%", 0, 0, 0.012M, 8),
            },
            new List<EstimateWork>
            {
                new EstimateWork("Электрохимическая защита", 0.04M, 0, 0.632M, 2),
                new EstimateWork("Благоустройство территории", 0, 0, 0.02M, 7),
                new EstimateWork("Всего по сводному сметному расчету", 0.041M, 2.536M, 3.226M, 12),
            }, new DateTime(2022, 8, 1), 1, "5.5-20.548", 16);

        public readonly static Estimate Estimate158VAT = new Estimate(new List<EstimateWork>
            {
                new EstimateWork("Демонтажные работы", 0, 11.537M, 107.797M, 1),
                new EstimateWork("Подготовительные работы", 0, 0, 3.266M, 1),
                new EstimateWork("Обследование строительных конструкций с ндс", 0, 18.131M, 18.131M, 1),
                new EstimateWork("Организация дорожного движения на период строительства", 0, 0, 0.063M, 8),
                new EstimateWork("Временные здания и сооружения 3,76х0,86 - 3,234%", 0, 0, 19.889M, 8),
            },
            new List<EstimateWork>
            {
                new EstimateWork("Здание гаражей с блоком бытовых помещений и складами", 66.611M, 1.673M, 688.948M, 2),
                new EstimateWork("Абк", 277.031M, 3.051M, 1440.621M, 2),
                new EstimateWork("Склад материалов", 0, 0.544M, 100.598M, 2),
                new EstimateWork("Склад баллонов", 68.38M, 0.827M, 277.016M, 2),
                new EstimateWork("Навес для машин на 8 м/мест", 0, 0, 88.493M, 4),
                new EstimateWork("Эстакада", 0, 0, 26.782M, 4),
                new EstimateWork("Внутриплощадочные сети электроснабжения", 26.123M, 0, 50.086M, 4),
                new EstimateWork("Внутриплощадочные сети автоматизации", 0, 0, 6.945M, 4),
                new EstimateWork("Внутриплощадочные сети телемеханизации", 0, 0, 3.928M, 4),
                new EstimateWork("Электроснабжение. подстанции", 3.206M, 0, 3.572M, 4),
                new EstimateWork("Внутриплощадочные сети системы контроля и управления доступом", 6.458M, 0, 16.049M, 5),
                new EstimateWork("Внутриплощадочные сети пожарной сигнализации", 0.195M, 0, 14.013M, 5),
                new EstimateWork("Внутриплощадочные сети видеонаблюдения", 3.8M, 0, 12.013M, 5),
                new EstimateWork("Организация дорожного движения на период эксплуатации", 0, 0, 1.204M, 5),
                new EstimateWork("Внутриплощадочные сети связи", 0, 0, 2.196M, 5),
                new EstimateWork("Системы радиосвязи", 0, 0, 2.319M, 5),
                new EstimateWork("Газоснабжение. наружные газопроводы", 0, 0, 7.667M, 6),
                new EstimateWork("Узел редуцирования", 0.069M, 0, 3.254M, 6),
                new EstimateWork("Наружные сети водоснабжения и канализации", 2.202M, 0.018M, 74.368M, 6),
                new EstimateWork("Тепловые сети", 0.048M, 0, 20.679M, 6),
                new EstimateWork("Благоустройство", 0, 13.617M, 782.52M, 7),
                new EstimateWork("Всего по сводному сметному расчету", 465.022M, 1789.066M, 5614.264M, 12),
            }, new DateTime(2019, 7, 1), 6, "5.4-18.158", 79827);

        public readonly static Estimate Estimate158VATFree = new Estimate(new List<EstimateWork>
            {
                new EstimateWork("Демонтажные работы", 0, 0.122M, 1.677M, 1),
                new EstimateWork("Подготовительные работы", 0, 0, 0.828M, 1),
                new EstimateWork("Временные здания и сооружения 3,76х0,86 - 3,234%", 0, 0, 3.709M, 8),
            },
            new List<EstimateWork>
            {
                new EstimateWork("Здание гаражей с блоком бытовых помещений и складами", 46.258M, 1.251M, 409.239M, 2),
                new EstimateWork("Внутриплощадочные сети электроснабжения", 0.016M, 0, 1.99M, 4),
                new EstimateWork("Внутриплощадочные сети автоматизации", 0, 0, 0.329M, 4),
                new EstimateWork("Внутриплощадочные сети пожарной сигнализации", 0.059M, 0, 2.008M, 5),
                new EstimateWork("Газоснабжение. наружные газопроводы", 0, 0, 1.136M, 6),
                new EstimateWork("Узел редуцирования", 0.019M, 0, 0.836M, 6),
                new EstimateWork("Благоустройство", 0, 4.803M, 282.087M, 7),
                new EstimateWork("Всего по сводному сметному расчету", 47.492M, 111.785M, 828.585M, 12),
            }, new DateTime(2019, 7, 1), 6, "5.4-18.158", 283);
    }
}
