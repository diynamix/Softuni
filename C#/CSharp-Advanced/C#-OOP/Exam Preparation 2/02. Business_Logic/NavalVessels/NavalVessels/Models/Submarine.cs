namespace NavalVessels.Models
{
    using Contracts;
    using System.Text;

    public class Submarine : Vessel, ISubmarine
    {
        private const double DefaultArmorThickness = 200;
        private const double MainWeaponCaliberChange = 40;
        private const double SpeedChange = 4;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, DefaultArmorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            ArmorThickness = DefaultArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;

            if (SubmergeMode)
            {
                MainWeaponCaliber += MainWeaponCaliberChange;
                Speed -= SpeedChange;
            }
            else
            {
                MainWeaponCaliber -= MainWeaponCaliberChange;
                Speed += SpeedChange;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
