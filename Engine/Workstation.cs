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

        public override string ToString()
        {
            return String.Format("(Stanowisko {0}):", Number);
        }

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
                result += String.Format("{0} {1} podchodzi do stanowiska{2}", this, currentPatient.Name, Environment.NewLine);
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
                        result += String.Format("{0} {1} zaczyna awanturę!{2}", this, currentPatient.Name, Environment.NewLine);
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
                            result += String.Format("{0} {1} pacyfikuje awanturnika{2}", this, CurrentEmployee.Name, Environment.NewLine);
                        }
                        else
                        {
                            // Nie udało się. Aggro trwa nadal
                            result += String.Format("{0} Awantura trwa! {1}{2}", this, currentPatient.AggroText, Environment.NewLine);
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
                        result += sellOTCItem();
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
                result = String.Format("{0} {1}{2}", this, CurrentEmployee.IdleText, Environment.NewLine);
                status = StatusEnum.Wolne;
            }

            return result;
        }

        private string sellOTCItem()
        {
            string result = "";
            InventoryItem wantedItem = currentPatient.OTCList.Dequeue();
            InventoryItem inventoryItem = pharmacy.itemFromInventoryByID(wantedItem.Details.ID);

            if (inventoryItem != null && inventoryItem.Quantity > 0 )
            {
                inventoryItem.Quantity -= wantedItem.Quantity;
                pharmacy.Balance += wantedItem.Details.SellPrice;
                pharmacy.Reputation += 1;
                result += String.Format("{0} {1} kupuje {2} za {3}{4}", this, currentPatient.Name, wantedItem.Details.Name,
                                        wantedItem.Details.SellPrice.ToString("c"), Environment.NewLine);
            }
            else
            {
                result = String.Format("{0} {1} chciał kupić {2} ale nie było (a za komuny to, panie, wszystko było!){3}", this, currentPatient.Name, wantedItem.Details.Name, Environment.NewLine);
                pharmacy.Reputation -= 1;
            }

            return result;
        }

 
    }
}
