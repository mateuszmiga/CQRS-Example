using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CQRS.Application.User.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, Token>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiKeycloakSettings _apiKeycloakSettings;

        public SignInCommandHandler(IHttpClientFactory httpClientFactory, IOptions<ApiKeycloakSettings> options)
        {
            _httpClientFactory = httpClientFactory;
            _apiKeycloakSettings = options.Value;
        }

        public async Task<Token> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var resource = _apiKeycloakSettings.Resource;
            var secret = _apiKeycloakSettings.Credentials.Secret;

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", request.Username),
                new KeyValuePair<string, string>("password", request.Password),
                new KeyValuePair<string, string>("client_id", resource),
                new KeyValuePair<string, string>("client_secret", secret),
                new KeyValuePair<string, string>("grant_type", "password"),
            });

            var response = await httpClient.PostAsync("http://localhost:8080/realms/Test/protocol/openid-connect/token", content);
         
            //if (response.StatusCode == HttpStatusCode.Unauthorized)
            //{
            //    throw new HttpRequestException(null, null, HttpStatusCode.Unauthorized);
            //}

            string responseContent = await response.Content.ReadAsStringAsync();
            Token token = JsonConvert.DeserializeObject<Token>(responseContent);
            
            return token;
        }
    }

    public class ApiKeycloakSettings
    {
        public string Realm { get; set; }
        public string AuthServerUrl { get; set; }
        public bool VerifyTokenAudience { get; set; }
        public string SslRequired { get; set; }
        public string Resource { get; set; }
        public ApiKeycloakCredentials Credentials { get; set; }
        public bool PublicClient { get; set; }
        public int ConfidentialPort { get; set; }
    }

    public class ApiKeycloakCredentials
    {
        public string Secret { get; set; }
    }
}
