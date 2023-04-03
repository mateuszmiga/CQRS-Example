using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CQRS.Application
{
    [DataContract]
    public class Token
    {
        [DataMember(Name = "access_token")]
        public string? AccessToken { get; set; }

        [DataMember(Name = "expires_in")]
        public int? ExpiresIn { get; set; }

        [DataMember(Name = "refresh_expires_in")]
        public int? RefreshExpiresIn { get; set; }

        [DataMember(Name = "refresh_token")]
        public string? RefreshToken { get; set; }

        [DataMember(Name = "token_type")]
        public string? TokenType { get; set; }

        [DataMember(Name = "not-before-policy")]
        public int? NotBeforePolicy { get; set; }

        [DataMember(Name = "session_state")]
        public string? SessionState { get; set; }

        [DataMember(Name = "scope")]
        public string? Scope { get; set; }
    }
}
