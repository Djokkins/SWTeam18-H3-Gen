using System;
using System.Collections.Generic;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MicrowaveOven.Integration.Test
{
    [TestFixture]
    class PowerTube_IT1
    {
        private IButton powerButton;
        private IButton timeButton;
        private IButton startCancelButton;
        private IDoor door;
        private IUserInterface ui;
        private ILight light;
        private ICookController cooker;
        private IOutput output;
        private ITimer timer;
        private IPowerTube _uut;
        private IDisplay display;
        private Button button;

        [SetUp]
        public void SetUp()
        {
            _uut = new PowerTube(output);
            powerButton = new Button();
            timeButton = new Button();
            startCancelButton = new Button();
            door = new Door();
            output = new Output();
            display = new Display(output);
            light = new Light(output);
            timer = new Timer();
            cooker = new CookController(timer, display, _uut);
            ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cooker);
        }

        [Test]
        public void powertube_activation() // tester om powertube bliver aktiveret af cookcontroller
        {
            int power = 90;
         //   cooker.StartCooking(power, TimeSpan.FromMinutes(1));
            Assert.That(_uut, Is.EqualTo(power));
        }

        //[Test]
        //public void Powertube_feedback() // tester om powertube melder power tilbage
        //{

        //}
    }
}