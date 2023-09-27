using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Tagesgeld
    {
        private Konto verrechnungskonto;
        private double guthaben = 0.0;
        private double zinssatz = 0.0;

        public Tagesgeld(Konto verrechnungskonto)
        {
            this.verrechnungskonto = verrechnungskonto;
        }

        public int VerrechnungsKontoNr { get{return verrechnungskonto.KontoNr; } }
        public double Guthaben { get{return guthaben; } }
        public double Zinssatz { get { return zinssatz;} set{this.zinssatz = value;}}

        public void Einzahlen(double betrag)
        {
            verrechnungskonto.Auszahlen(betrag);
            this.guthaben += betrag;


        }

        public void Auszahlen(double betrag)
        {
            if(guthaben<betrag)
            {
                throw new ArgumentOutOfRangeException("Guthaben nicht ausreichend.");
            } 
            else
            {
                verrechnungskonto.Einzahlen(betrag);
                this.guthaben -= betrag;
            }
           


        }
    }
}
