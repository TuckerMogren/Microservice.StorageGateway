using Newtonsoft.Json;
namespace Microservice.StorageGateway.Contracts.Settings.Interfaces;

public interface IGoogleDriveSettings
{
    public IGoogleCredentialFile CredentialFile { get;  }
    public IEnumerable<string> Scopes { get; }
}
public interface IGoogleCredentialFile
{
    string Type { get; }
    string ProjectId { get; }
    string PrivateKeyId { get; }
    string PrivateKey { get; }
    string ClientEmail { get; }
    string ClientId { get; }
    string AuthUri { get; }
    string TokenUri { get; }
    string AuthProviderX509CertUrl { get; }
    string ClientX509CertUrl { get; }
}