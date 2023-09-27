using System;

namespace Bank
{
    public class Konto
    {
        private double guthaben;
        private static int letzteKontoNr = 0;
        private int kontoNr;

        public double Guthaben
        {
            get
            {
                return guthaben;
            }
        }

        public Konto(double guthaben)
        {
            if(guthaben < 0)
            {
                throw new ArgumentOutOfRangeException("Eröffnungsbetrag darf nicht negativ sein.");
            }

            this.guthaben = guthaben;
            letzteKontoNr++;
            kontoNr = letzteKontoNr;
        }

        public int KontoNr
        {
            get
            {
                return kontoNr;
            }
        }

        public void Einzahlen(double betrag)
        {
            guthaben += betrag;
        }

        public void Auszahlen(double betrag)
        {
            if (guthaben >= betrag)
            {
                guthaben -= betrag;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Guthaben nicht ausreichend");
            }
        }
    }
}
