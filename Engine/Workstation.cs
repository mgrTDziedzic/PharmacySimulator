using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Workstation
    {

        private StatusEnum status;
        private Pharmacy pharmacy;
        private Patient currentPatient;
        private bool aggroOccured;
        private int aggroCycle;

        public enum StatusEnum
        {
           Wolne,
           Obsługa,
           Awantura,
        }

        public int Number { get; private set; }        
        public Employee CurrentEmployee { get; set; }     

        public string PatientName
        {
            get
            {
                if (currentPatient != null)
                {
                    return currentPatient.Name;
                }               
                else
                {
                    return "<brak>";
                }
            }
        }

        public string EmployeeName
        {
            get
            {
                if (CurrentEmployee != null)
                {
                    return CurrentEmployee.Name;
                }
                else
                {
                    return "<brak>";
                }
            }
        }        

        public Workstation(int number, Pharmacy pharmacy)
        {
            status = StatusEnum.Wolne;
            Number = number;
            this.pharmacy = pharmacy;
        }

        public string GetStatus()
        {
            return status.ToString();
        }

        public string DoJob()
        {
            string result = "";

            // Jeśli stanowisko jest wolne a w kolejce są pacjenci
            if ((currentPatient == null) && (pharmacy.PatientsQueue.Count > 0))
            {
                // Podchodzi pacjent z kolejki
                currentPatient = pharmacy.PatientsQueue.Dequeue();
                result += currentPatient.Name + " podchodzi do stanowiska " + Number.ToString() + Environment.NewLine;
                status = StatusEnum.Obsługa;
                aggroOccured = false;
            }

            if (currentPatient != null)
            {
                // Jeśli na stanowisku nie ma awantury
                if (status != StatusEnum.Awantura)
                {
                    // Jeśli nie było jeszcze awantury, to sprawdzamy czy nie wybuchła
                    if (!aggroOccured && RandomNumberGenerator.Chance(currentPatient.Aggressiveness))
                    {
                        status = StatusEnum.Awantura;
                        aggroOccured = true;
                        aggroCycle = 0;
                        result += currentPatient.Name + " zaczyna awanturę na stanowisku " + Number + "!" + Environment.NewLine;
                    }
                }

                // Jeśli awantura już trwa
                if (status == StatusEnum.Awantura)
                {
                    aggroCycle++;

                    if (aggroCycle > 1)
                    {
                        // Pracownik próbuje pacyfikować awanturnika
                        if (RandomNumberGenerator.Chance(CurrentEmployee.Assertiveness))
                        {
                            // Udało się, zmieniamy status stanowiska
                            status = StatusEnum.Obsługa;
                            aggroCycle = 0;
                            result += CurrentEmployee.Name + " pacyfikuje awanturnika na stanowisku " + Number.ToString() + Environment.NewLine;
                        }
                        else
                        {
                            // Nie udało się. Aggro trwa nadal
                            result += "Trwa awantura na stanowisku " + Number.ToString() + "!" + " " + currentPatient.AggroText + Environment.NewLine;
                        }
                    }

                    if (aggroCycle > 4)
                    {
                        // Po 4 cyklach nieopanowanej awantury pacjent wychodzi
                        result += currentPatient.Name + " wychodzi z apteki, przeklinając pod nosem" + Environment.NewLine;
                        currentPatient = null;
                        status = StatusEnum.Wolne;
                    }                    
                }
                else
                {
                    if (currentPatient.OTCList.Count > 0)
                    {
                        InventoryItem wantedItem = currentPatient.OTCList.Dequeue();
                        pharmacy.Balance += wantedItem.Details.SellPrice;
                        pharmacy.Reputation += 1;
                        result += currentPatient.Name + " kupuje " + wantedItem.Details.Name + " na stanowisku " + Number.ToString() + " za " +
                                  wantedItem.Details.SellPrice.ToString("c") + Environment.NewLine;
                    }

                    if (currentPatient.OTCList.Count == 0)
                    {
                        result += currentPatient.Name + " wychodzi z apteki." + Environment.NewLine;
                        currentPatient = null;
                        status = StatusEnum.Wolne;
                    }
                }
            }            
            else
            {
                // Jeśli nie ma pacjenta, wyświetl losową wiadomość o wolnym stanowisku
                result = FlavorText.IdleMessage(CurrentEmployee, this);
                status = StatusEnum.Wolne;
            }

            return result;
        }
    }
}
