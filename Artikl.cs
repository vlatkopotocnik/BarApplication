namespace BarApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class Artikl
    {
        public Artikl()
        {
            this.CjenikArtikl = new HashSet<CjenikArtikl>();
        }
    
        public int ArtiklId { get; set; }
        public string Naziv { get; set; }
    
        public virtual ICollection<CjenikArtikl> CjenikArtikl { get; set; }
    }
}
