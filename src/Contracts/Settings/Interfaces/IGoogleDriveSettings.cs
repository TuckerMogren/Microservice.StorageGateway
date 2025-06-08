namespace Microservice.StorageGateway.Contracts.Settings.Interfaces;

public interface IGoogleDriveSettings
{
    public string CredentialFilePath { get;  }
    public IEnumerable<string> Scopes { get; }
}
