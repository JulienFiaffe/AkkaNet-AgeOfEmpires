﻿using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit;
using AkkaOfEmpires.Domain;
using AkkaOfEmpires.Domain.Commands;
using AkkaOfEmpires.Supervisors;
using AkkaOfEmpires.Tests.Helpers;
using AkkaOfEmpires.Units;
using Shouldly;
using TechTalk.SpecFlow;

namespace AkkaOfEmpires.Tests.Scenarios.Villager
{
    [Binding]
    public sealed class VillagerSteps : TestKit
    {
        [AfterScenario]
        public void AfterScenario()
        {
            Shutdown();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _resourcesSupervisor = ActorOfAsTestActorRef<ResourcesSupervisorActor>();
        }

        private TestActorRef<VillagerActor> _villagerActor;
        private TestActorRef<ResourcesSupervisorActor> _resourcesSupervisor;

        [Given(@"I have a villager")]
        public void GivenIHaveAVillager()
        {
            var props = Props.Create<VillagerActor>(_resourcesSupervisor);
            _villagerActor = ActorOfAsTestActorRef<VillagerActor>(props);
        }

        [When(@"he becomes a gatherer")]
        public void WhenHeBecomesAGatherer()
        {
            _villagerActor.Tell(VillagerOrders.GatherFruits);
        }

        [When(@"he becomes a shepherd")]
        public void WhenHeBecomesAShepherd()
        {
            _villagerActor.Tell(VillagerOrders.ShepherdFlock);
        }

        [When(@"he becomes a hunter")]
        public void WhenHeBecomesAHunter()
        {
            _villagerActor.Tell(VillagerOrders.HuntPrey);
        }

        [When(@"he becomes a farmer")]
        public void WhenHeBecomesAFarmer()
        {
            _villagerActor.Tell(VillagerOrders.FarmCrops);
        }

        [When(@"he becomes a fisherman")]
        public void WhenHeBecomesAFisherman()
        {
            _villagerActor.Tell(VillagerOrders.CatchFish);
        }

        [Then(@"he recolts food")]
        public void ThenHeWillRecoltFood()
        {
            _villagerActor.UnderlyingActor.ResourceToRecolt.ShouldBe(Resource.Food);
        }
    }
}
