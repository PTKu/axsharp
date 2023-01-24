using System;

namespace Pocos
{
    public partial class weatherBase
    {
        public Single Latitude { get; set; }

        public Single Longitude { get; set; }

        public Single Altitude { get; set; }

        public string Description { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public Int16 StartCounter { get; set; }
    }
}