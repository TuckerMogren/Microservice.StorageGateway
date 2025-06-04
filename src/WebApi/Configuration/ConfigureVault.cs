using Microsoft.Extensions.Configuration;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace Microservice.StorageGateway.WebApi.Configuration;

public static class VaultConfigurationExtensions
{
    public static IConfigurationBuilder ConfigureVault(this IConfigurationBuilder builder)
    {
        var vaultAddress = Environment.GetEnvironmentVariable("VAULT_ADDR") ?? "http://localhost:8200";
        var vaultToken = Environment.GetEnvironmentVariable("VAULT_TOKEN") ?? "dev-root";

        var authMethod = new TokenAuthMethodInfo(vaultToken);
        var vaultClientSettings = new VaultClientSettings(vaultAddress, authMethod);
        var vaultClient = new VaultClient(vaultClientSettings);

        var secrets = vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(path: "myapp/config").GetAwaiter().GetResult();

        var configDict = secrets.Data.Data.ToDictionary(k => k.Key, k => k.Value?.ToString());

        builder.AddInMemoryCollection(configDict);

        return builder;
    }
}