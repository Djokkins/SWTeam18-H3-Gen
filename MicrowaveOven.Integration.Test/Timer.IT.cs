//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using MicrowaveOvenClasses.Controllers;
//using MicrowaveOvenClasses.Boundary;
//using MicrowaveOvenClasses.Interfaces;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NSubstitute;

//namespace MicrowaveOven.Integration.Test
//{
//    [TestFixture]
//    class Timer
//    {
//        class Timer_IT
//        {
//            private ICookController cooker;
//            private IOutput fake_output;
//            private ITimer _uut;
//            private IPowerTube fake_powertube;
//            private IDisplay fake_display;

//            [SetUp]
//            public void SetUp()
//            {
//                fake_output = Substitute.For<IOutput>();
//                fake_display = Substitute.For<IDisplay>();
//                fake_powertube = Substitute.For<IPowerTube>();
//                _uut = new MicrowaveOvenClasses.Boundary.Timer();
//                cooker = new CookController(_uut, fake_display, fake_powertube);
//            }
//            [Test]
//            public void timer_activation()
//            {
//                int time = 5;
//                cooker.StartCooking(50, 1);
//                fake_output.Received().OutputLine($"PowerTube works with {time} %");
//            }

//            [Test]
//            public void timer_feedback()
//            {
//                // _uut.TimerTick
//            }

//        }
//    }
//}
