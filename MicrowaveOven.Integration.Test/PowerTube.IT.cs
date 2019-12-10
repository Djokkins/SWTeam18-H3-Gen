using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace MicrowaveOven.Integration.Test
{
    [TestFixture]
    class PowerTube_IT1
    {
        private ICookController cooker;
        private IOutput fake_output;
        private ITimer fake_timer;
        private IPowerTube _uut;
        private IDisplay fake_display;

        [SetUp]
        public void SetUp()
        {
            fake_output = Substitute.For<IOutput>();
            fake_display = Substitute.For<IDisplay>();
            _uut = new PowerTube(fake_output);
            fake_timer = Substitute.For<ITimer>();
            cooker = new CookController(fake_timer, fake_display, _uut);
        }

        [Test]
        public void powertube_activation_50() // tester om powertube bliver aktiveret af cookcontroller
        {
            int power = 50;
            cooker.StartCooking(power, 1);
            fake_output.Received().OutputLine($"PowerTube works with {power} W");
        }

        [Test]
        public void powertube_activation_150() // tester om powertube bliver aktiveret af cookcontroller
        {
            int power = 150;
            cooker.StartCooking(power, 1);
            fake_output.Received().OutputLine($"PowerTube works with {power} W");
        }

        [Test]
        public void powertube_activation_700() // tester om powertube bliver aktiveret af cookcontroller
        {
            int power = 700;
            cooker.StartCooking(power, 1);
            fake_output.Received().OutputLine($"PowerTube works with {power} W");
        }

        [Test]
        public void powertube_stop_50()
        {
            int power = 50;
            cooker.StartCooking(power, 1);
            cooker.Stop();
            fake_output.Received().OutputLine($"PowerTube turned off");
        }

        [Test]
        public void powertube_stop_60()
        {
            int power = 60;
            cooker.StartCooking(power, 1);
            cooker.Stop();
            fake_output.Received().OutputLine($"PowerTube turned off");
        }

    }
}