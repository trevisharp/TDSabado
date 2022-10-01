using dto;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace front.Services;

public class UserService
{
    HttpClient client;

    public UserService(string server)
    {
        client = new HttpClient();
        client.BaseAddress = new Uri(server);
    }

    public async Task Register(
        string name,
        string userId,
        DateTime birth,
        string password)
    {
        UsuarioDTO user = new UsuarioDTO();
        user.Name = name;
        user.UserId = userId;
        user.Password = password;
        user.BirthDate = birth;

        var result = await client
            .PostAsJsonAsync("user/register", user);
    }

    public async Task<string> Login(
        string userId,
        string password
    )
    {
        UsuarioDTO user = new UsuarioDTO();
        user.UserId = userId;
        user.Password = password;

        var result = await client
            .PostAsJsonAsync("user/login", user);
        
        if (result.StatusCode != HttpStatusCode.OK)
            return null;
        return "Logado com Sucesso";
    }
}