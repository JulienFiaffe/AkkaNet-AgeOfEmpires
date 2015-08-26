﻿using AkkaOfEmpires.Domain.Commands;

namespace AkkaOfEmpires.Tests.Helpers
{
    public static class VillagerOrders
    {
        public static readonly ShepherdFlock ShepherdFlock = new ShepherdFlock();
        public static readonly GatherFruits GatherFruits = new GatherFruits();
        public static readonly HuntPrey HuntPrey = new HuntPrey();
        public static readonly FarmCrops FarmCrops = new FarmCrops();
        public static readonly CatchFish CatchFish = new CatchFish();
    }
}
