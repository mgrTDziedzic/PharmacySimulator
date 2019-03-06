using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class FlavorText
    {
        private static string[] idleText = 
        {
            "obija się",
            "dłubie w nosie",
            "kontempluje stan polskiego aptekarstwa",
            "obserwuje czubek chodaka",
            "czyta na Wikipedii o działaniu silnika indukcyjnego",
            "przegląda Ratlerka",
            "obgryza paznokcie",
            "grzebie pilnikiem pod paznokciami",
            "duma nad sensem życia",
            "trolluje na Ryneczku",
            "ogląda Wikifeet",
            "liczy guziki fartucha",
            "fantazjuje o Sashy Grey"
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

        public static string IdleMessage(Employee employee, Workstation workstation)
        {
            int randomIndex = RandomNumberGenerator.NumberBetween(0, idleText.Length - 1);

            return String.Format("{0} {1} na stanowisku {2}" + Environment.NewLine, employee.Name, idleText[randomIndex], workstation.Number);
        }
    }
}
