using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FELM
{
    class VareClass
    {
        private int _VareNr;
        private string _Beskrivelse;
        private string _Tilgang;
        private string _Afgang;
        private int _Ampere;
        private string _Note;
        private bool _Status;
        private int _Antal;
        private int _VareLokation;
        private int _PinNr;

        public VareClass(int VareNr, string Beskrivelse, string Tilgang, string Afgang, int Ampere, string Note, bool Status, int Antal, int VareLokation, int PinNr)
        {
            this._VareNr = VareNr;
            this._Beskrivelse = Beskrivelse;
            this._Tilgang = Tilgang;
            this._Afgang = Afgang;
            this._Ampere = Ampere;
            this._Note = Note;
            this._Status = Status;
            this._Antal = Antal;
            this._VareLokation = VareLokation;
            this._PinNr = PinNr;
        }

        public int VareNr
        {
            get { return _VareNr; }
            set { _VareNr = value; }
        }

        public string Beskrivelse
        {
            get { return _Beskrivelse; }
            set { _Beskrivelse = value; }
        }

        public string Tilgang
        {
            get { return _Tilgang; }
            set { _Tilgang = value; }
        }

        public string Afgang
        {
            get { return _Afgang; }
            set { _Afgang = value; }
        }

        public int Ampere
        {
            get { return _Ampere; }
            set { _Ampere = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public int Antal
        {
            get { return _Antal; }
            set { _Antal = value; }
        }

        public int VareLokation
        {
            get { return _VareLokation; }
            set { _VareLokation = value; }
        }

        public int PinNr
        {
            get { return _PinNr; }
            set { _PinNr = value; }
        }
    }
}
