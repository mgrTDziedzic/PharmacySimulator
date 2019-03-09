using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class FlavorText
    {
        public static string[] combinedMaleText
        {
            get
            {
                string[] combined = new string[genericIdleText.Length + maleIdleText.Length];
                Array.Copy(genericIdleText, combined, genericIdleText.Length);
                Array.Copy(maleIdleText, 0, combined, genericIdleText.Length, maleIdleText.Length);
                return combined;
            }
        }

        public static string[] combinedFemaleText
        {
            get
            {
                string[]combined = new string[genericIdleText.Length + femaleIdleText.Length];
                Array.Copy(genericIdleText, combined, genericIdleText.Length);
                Array.Copy(femaleIdleText, 0, combined, genericIdleText.Length, femaleIdleText.Length);
                return combined;
            }
        }

        private static string[] genericIdleText = 
        {
            "obija się",
            "dłubie w nosie",
            "kontempluje stan polskiego aptekarstwa",
            "obserwuje czubek chodaka",
            "obgryza paznokcie",
            "duma nad sensem życia",
            "trolluje na Ryneczku",
            "liczy guziki fartucha",            
        };

        private static string[] maleIdleText =
        {
            "czyta na Wikipedii o działaniu silnika indukcyjnego",
            "fantazjuje o Sashy Grey",
            "ogląda Wikifeet"
        };

        private static string[] femaleIdleText =
        {
            "maluje paznokcie",
            "grzebie pilnikiem pod paznokciami",
            "przegląda Ratlerka"
        };

        public static string[] AggroTexts =
        {
            "czerwienieje ze złości",
            "zaraz dostanie zawału",
            "gotuje się",
            "pulta się",
            "grzeje się strasznie",
            "zaraz wybuchnie",
            "straszy WIFem",
            "straszy donosem do NFZ",
            "straszy donosem do MPO",
            "straszy znajomościami w Nadleśnictwie",
            "straszy TVNem",
            "wypowiada groźby karalne",
            "grozi, że więcej nie przyjdzie",
            "grozi prawnikiem",
            "grozi pozwem",
            "żąda oświadczeń na piśmie",
            "żąda rozmowy z właścicielem"
        };

        /*
        public static string IdleMessage(Employee employee, Workstation workstation)
        {
            int randomIndex = RandomNumberGenerator.NumberBetween(0, idleText.Length - 1);

            return String.Format("{0} {1} na stanowisku {2}" + Environment.NewLine, employee.Name, idleText[randomIndex], workstation.Number);
        }
        */
    }
}
