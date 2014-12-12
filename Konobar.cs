namespace BarApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class Konobar
    {
        public Konobar()
        {
            this.Racun = new HashSet<Racun>();
        }
    
        public int KonobarId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    
        public virtual ICollection<Racun> Racun { get; set; }
    }
}
