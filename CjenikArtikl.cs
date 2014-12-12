namespace BarApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class CjenikArtikl
    {
        public CjenikArtikl()
        {
            this.RacunArtiklCjenik = new HashSet<RacunArtiklCjenik>();
        }
    
        public int CjenikArtiklId { get; set; }
        public int ArtiklId { get; set; }
        public int CjenikID { get; set; }
        public int Cjena { get; set; }
    
        public virtual Artikl Artikl { get; set; }
        public virtual Cjenik Cjenik { get; set; }
        public virtual ICollection<RacunArtiklCjenik> RacunArtiklCjenik { get; set; }
    }
}
