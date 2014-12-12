namespace BarApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stol
    {
        public Stol()
        {
            this.Racun = new HashSet<Racun>();
        }
    
        public int StolId { get; set; }
        public int BrojStola { get; set; }
    
        public virtual ICollection<Racun> Racun { get; set; }
    }
}
