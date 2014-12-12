namespace BarApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cjenik
    {
        public Cjenik()
        {
            this.CjenikArtikl = new HashSet<CjenikArtikl>();
        }
    
        public int CjenikId { get; set; }
        public System.DateTime Datum_od { get; set; }
        public System.DateTime Datum_do { get; set; }
    
        public virtual ICollection<CjenikArtikl> CjenikArtikl { get; set; }
    }
}
