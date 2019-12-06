using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
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
            _uut = new PowerTube(fake_output);
            fake_output = new Output();
            fake_display = new Display(fake_output);
            fake_timer = new MicrowaveOvenClasses.Boundary.Timer();
            cooker = new CookController(fake_timer, fake_display, _uut);
        }

        [Test]
        public void powertube_activation_50() // tester om powertube bliver aktiveret af cookcontroller
        {
            int power = 50;
            cooker.StartCooking(power, 1);
            Assert.That(fake_output, Is.EqualTo(power));
        }

        [Test]
        public void powertube_activation_150() // tester om powertube bliver aktiveret af cookcontroller
        {
            int power = 150;
            cooker.StartCooking(power, 1);
            Assert.That(fake_output, Is.EqualTo(power));
        }

        [Test]
        public void powertube_activation_700() // tester om powertube bliver aktiveret af cookcontroller
        {
            int power = 700;
            cooker.StartCooking(power, 1);
            Assert.That(fake_output, Is.EqualTo(power));
        }

        [Test]
        public void powertube_activation_negative3() // tester om powertube bliver aktiveret af cookcontroller
        {
            int power = -3;
            cooker.StartCooking(power, 1);
            Assert.That(fake_output, Is.EqualTo(power));
        }

        [Test]
        public void powertube_stop_50()
        {
            cooker.StartCooking(50, 1);
            cooker.Stop();
            Assert.That(_uut, Is.EqualTo(0) );
        }

        [Test]
        public void powertube_stop_60()
        {
            cooker.StartCooking(60, 1);
            cooker.Stop();
            Assert.That(fake_output, Is.EqualTo(0));
        }
    }
}