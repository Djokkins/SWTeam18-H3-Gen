using NUnit.Framework;
using System;
using System.Collections.Generic;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrowaveOven.Integration.Test
{
    [TestFixture]
    class Timer
    {
        class Timer_IT
        {
            private IButton powerButton;
            private IButton timeButton;
            private IButton startCancelButton;
            private IDoor door;
            private IUserInterface ui;
            private ILight light;
            private ICookController cooker;
            private IOutput output;
            private ITimer _uut;
            private IPowerTube powertube;
            private IDisplay display;
            private Button button;

            [SetUp]
            public void SetUp()
            {
                powertube = new PowerTube(output);
                powerButton = new Button();
                timeButton = new Button();
                startCancelButton = new Button();
                door = new Door();
                output = new Output();
                display = new Display(output);
                light = new Light(output);
                _uut = new Timer();
                cooker = new CookController(_uut, display, powertube);
                ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cooker);
                //evt lav fakes, det gør programmet nemmere at teste. IT test er en "unittest" af controlleren. 
            }
            [Test]
            public void timer_activation()
            {
                int time = 5;
                cooker.StartCooking(50, TimeSpan.FromMinutes(time));
                Assert.That(_uut.TimeRemaining, Is.EqualTo(time));
            }

            [Test]
            public void timer_feedback()
            {
                // _uut.TimerTick
            }

        }
    }
}
