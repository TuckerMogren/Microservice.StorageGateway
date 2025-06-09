namespace Microservice.StorageGateway.Contracts.Settings.Interfaces;

public interface IGoogleDriveSettings
{
    public string CredentialFile { get;  }
    public IEnumerable<string> Scopes { get; }
}
