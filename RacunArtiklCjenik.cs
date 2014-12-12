namespace BarApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class RacunArtiklCjenik
    {
        public int RacunArtiklCjenikId { get; set; }
        public int RacunId { get; set; }
        public int CjenikArtiklId { get; set; }
        public int Kolicina { get; set; }
    
        public virtual CjenikArtikl CjenikArtikl { get; set; }
        public virtual Racun Racun { get; set; }
    }
}
