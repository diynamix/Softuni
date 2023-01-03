namespace NavalVessels.Models
{
    using Contracts;
    using System.Text;

    public class Battleship : Vessel, IBattleship
    {
        private const double DefaultArmorThickness = 300;
        private const double MainWeaponCaliberChange = 40;
        private const double SpeedChange = 5;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, DefaultArmorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;

            if (SonarMode)
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

        public override void RepairVessel()
        {
            ArmorThickness = DefaultArmorThickness;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {(SonarMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
