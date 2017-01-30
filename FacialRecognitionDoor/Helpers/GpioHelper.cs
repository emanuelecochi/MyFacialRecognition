using System;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using System.Diagnostics;
using Windows.UI.Xaml;

namespace FacialRecognitionDoor.Helpers
{
    /// <summary>
    /// Interacts with device GPIO controller in order to control door lock and monitor doorbell
    /// </summary>
    public class GpioHelper
    {
        private GpioController gpioController;
        private GpioPin sensorPIRPin;
        private GpioPin doorLockPin;
        private GpioPin pinEcho;
        private GpioPin pinTrigger;
        

        /// <summary>
        /// Attempts to initialize Gpio for application. This includes doorbell interaction and locking/unlccking of door.
        /// Returns true if initialization is successful and Gpio can be utilized. Returns false otherwise.
        /// </summary>
        public bool Initialize()
        {
            // Gets the GpioController
            gpioController = GpioController.GetDefault();
            if(gpioController == null)
            {
                // There is no Gpio Controller on this device, return false.
                return false;
            }

            // Opens the GPIO pin that interacts with the doorbel button
            sensorPIRPin = gpioController.OpenPin(GpioConstants.pinPIR);

            if (sensorPIRPin == null)
            {
                // Pin wasn't opened properly, return false
                return false;
            }

            // Set a debounce timeout to filter out switch bounce noise from a button press
            sensorPIRPin.DebounceTimeout = TimeSpan.FromMilliseconds(25);
            sensorPIRPin.SetDriveMode(GpioPinDriveMode.Input);
            /*
            if (sensorPIRPin.IsDriveModeSupported(GpioPinDriveMode.InputPullUp))
            {
                // Take advantage of built in pull-up resistors of Raspberry Pi 2 and DragonBoard 410c
                sensorPIRPin.SetDriveMode(GpioPinDriveMode.InputPullUp);
            }
            else
            {
                // MBM does not support PullUp as it does not have built in pull-up resistors 
                sensorPIRPin.SetDriveMode(GpioPinDriveMode.Input);
            }
            */

            // Opens the GPIO pin that interacts with the door lock system
            doorLockPin = gpioController.OpenPin(GpioConstants.DoorLockPinID);
            if(doorLockPin == null)
            {
                // Pin wasn't opened properly, return false
                return false;
            }
            // Sets doorbell pin drive mode to output as pin will be used to output information to lock
            doorLockPin.SetDriveMode(GpioPinDriveMode.Output);
            // Initializes pin to high voltage. This locks the door. 
            doorLockPin.Write(GpioPinValue.High);

            // Opens the GPIO pin that interacts with the sensor ultrasonic
            pinEcho = gpioController.OpenPin(GpioConstants.ECHO_PIN);
            pinTrigger = gpioController.OpenPin(GpioConstants.TRIGGER_PIN);

            pinTrigger.SetDriveMode(GpioPinDriveMode.Output);
            pinEcho.SetDriveMode(GpioPinDriveMode.Input);

            Debug.WriteLine("GPIO controller and pins initialized successfully.");

            pinTrigger.Write(GpioPinValue.Low);

            Task.Delay(100);

            //Initialization was successfull, return true
            return true;
        }

        /// <summary>
        /// Returns the GpioPin that handles the doorbell button. Intended to be used in order to setup event handler when user pressed Doorbell.
        /// </summary>
        public GpioPin GetDoorBellPin()
        {
            return sensorPIRPin;
        }

        public GpioPin GetPinEcho()
        {
            return pinEcho;
        }

        public GpioPin GetPinTrigger()
        {
            return pinTrigger;
        }

        /// <summary>
        /// Unlocks door for time specified in GpioConstants class
        /// </summary>
        public async void UnlockDoor()
        {
            // Unlock door
            doorLockPin.Write(GpioPinValue.Low);
            // Wait for specified length
            await Task.Delay(TimeSpan.FromSeconds(GpioConstants.DoorLockOpenDurationSeconds));
            // Lock door
            doorLockPin.Write(GpioPinValue.High);
        }

    }
}
