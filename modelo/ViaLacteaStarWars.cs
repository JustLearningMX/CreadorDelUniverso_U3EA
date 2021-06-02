using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DPRN2_U3_EA_HICL
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]

    public partial class Universo//Cambié el  nombre a universo
    {
        [JsonProperty("nombreUniverso")]
        public string NombreUniverso { get; set; }

        [JsonProperty("planetas")]
        public List<Planeta> planetas { get; set; }
    }

    public partial class Planeta
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rotation_period")]
        public long RotationPeriod { get; set; }

        [JsonProperty("orbital_period")]
        public long OrbitalPeriod { get; set; }

        [JsonProperty("diameter")]
        public long Diameter { get; set; }

        [JsonProperty("climate")]
        public string Climate { get; set; }

        [JsonProperty("gravity")]
        public string Gravity { get; set; }

        [JsonProperty("terrain")]
        public string Terrain { get; set; }

        [JsonProperty("surface_water")]
        public string SurfaceWater { get; set; }

        [JsonProperty("population")]
        public string Population { get; set; }

        [JsonProperty("residents")]
        public Uri[] Residents { get; set; }

        [JsonProperty("films")]
        public Uri[] Films { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("edited")]
        public DateTimeOffset Edited { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}