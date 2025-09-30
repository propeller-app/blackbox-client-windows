using Blackbox.Client.Rpc;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class AuthClient
{
    private readonly AuthService.AuthServiceClient _authClient;
    private readonly GrpcChannel _channel;

    public string AccessToken { get; private set; }
    public string RefreshToken { get; private set; }
    public int Credits { get; private set; }
    public string LoggedInEmail { get; private set; }
    public List<LoginReply.Types.Template> Templates { get; private set; }

    public AuthClient(string grpcUrl)
    {
        _channel = GrpcChannel.ForAddress(grpcUrl);
        _authClient = new AuthService.AuthServiceClient(_channel);
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        try
        {
            var reply = await _authClient.LoginAsync(new LoginRequest
            {
                Email = email,
                Password = password
            });

            if (reply.Success)
            {
                AccessToken = reply.AccessToken;
                RefreshToken = reply.RefreshToken;
                Credits = reply.Credits;
                LoggedInEmail = reply.Email;
                Templates = reply.Templates.ToList();
                TokenStore store = new TokenStore();
                store.Save(RefreshToken);
                return true;
            }

            return false;
        }
        catch (RpcException ex)
        {
            Console.WriteLine($"❌ Login failed: {ex.Status.Detail}");
            return false;
        }
    }

    public async Task<bool> RefreshAsync(TokenStore tokenStore = null)
    {
        tokenStore ??= new TokenStore();
        RefreshToken = tokenStore.Load();
        if (string.IsNullOrEmpty(RefreshToken))
            {
            Console.WriteLine("❌ No refresh token available.");
            return false;
        }

        try
        {
            var reply = await _authClient.RefreshAsync(new RefreshRequest
            {
                RefreshToken = RefreshToken
            });

            AccessToken = reply.AccessToken;
            RefreshToken = reply.RefreshToken;
            Credits = reply.Credits;
            LoggedInEmail = reply.Email;
            Templates = reply.Templates.ToList();
            return true;
        }
        catch (RpcException ex)
        {
            Console.WriteLine($"❌ Refresh failed: {ex.Status.Detail}");
            return false;
        }
    }

    public Metadata GetAuthHeaders()
    {
        //Console.WriteLine("Getting auth headers. AccessToken: " + (AccessToken));
        var headers = new Metadata();
        if (!string.IsNullOrEmpty(AccessToken))
        {
            headers.Add("authorization", $"Bearer {AccessToken}");
        }
        return headers;
    }
}

public class TokenStore
{
    private readonly string FilePath;

    public TokenStore()
    {
        var appData = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Blackbox"
        );
        Directory.CreateDirectory(appData);
        FilePath = Path.Combine(appData, "auth_tokens.json");
    }

    public void Save(string refreshToken)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(new { RefreshToken = refreshToken });
        File.WriteAllText(FilePath, json);
    }

    public string Load()
    {
        if (!File.Exists(FilePath)) return null;
        var json = File.ReadAllText(FilePath);
        var data = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        return data?["RefreshToken"];
    }

    public void Clear()
    {
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
        }
    }
}
