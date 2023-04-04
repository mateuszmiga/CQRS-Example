using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CQRS.Application.User.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, Token>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public SignInCommandHandler(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration; 
        }

        public IConfiguration Get_configuration()
        {
            return _configuration;
        }

        public async Task<Token> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient();
            ApiKeycloakSettings apiKeycloakSettings = _configuration.GetSection("Keycloak");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", request.Username),
                new KeyValuePair<string, string>("password", request.Password),
                new KeyValuePair<string, string>("client_id", "test-client"),
                new KeyValuePair<string, string>("client_secret", "4VR8ktQIszIZVWgc3ud8efGAzYbbr1uu"),
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
}
