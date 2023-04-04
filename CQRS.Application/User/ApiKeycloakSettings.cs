using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.User
{
    public class ApiKeycloakSettings
    {
        public string realm { get; set; }

        [JsonProperty("auth-server-url")]
        public string authserverurl { get; set; }

        [JsonProperty("verify-token-audience")]
        public bool verifytokenaudience { get; set; }

        [JsonProperty("ssl-required")]
        public string sslrequired { get; set; }
        public string resource { get; set; }
        public Credentials credentials { get; set; }

        [JsonProperty("public-client")]
        public bool publicclient { get; set; }

        [JsonProperty("confidential-port")]
        public int confidentialport { get; set; }
    }

    public class Credentials
    {
        public string secret { get; set; }
    }
}
