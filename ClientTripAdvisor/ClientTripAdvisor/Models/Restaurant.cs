using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTripAdvisor.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Restaurant
    {
        public int RES_ID { get; set; }
        public string PRX_PRIX { get; set; }
        public string RES_NOM { get; set; }
        public string RES_DESCRIPTION { get; set; }
        public string RES_CATEGORIEPRIX { get; set; }
        public string res_adr { get; set; }
        public string RES_CP { get; set; }
        public string RES_VILLE { get; set; }
        public string RES_PAYS { get; set; }
        public Nullable<float> RES_LATITUDE { get; set; }
        public Nullable<float> RES_LONGITUDE { get; set; }
        public int IND_INDICATIF { get; set; }
        public string RES_TEL { get; set; }
        public string RES_SITEWEB { get; set; }
        public string RES_MEL { get; set; }
    }
}
