namespace BarApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class Racun
    {
        public Racun()
        {
            this.RacunArtiklCjenik = new HashSet<RacunArtiklCjenik>();
        }
    
        public int RacunId { get; set; }
        public int KonobarId { get; set; }
        public int StolId { get; set; }
        public System.DateTime Vrijeme { get; set; }
    
        public virtual Konobar Konobar { get; set; }
        public virtual Stol Stol { get; set; }
        public virtual ICollection<RacunArtiklCjenik> RacunArtiklCjenik { get; set; }
    }
}
