using Microservice.StorageGateway.Contracts.Settings.Interfaces;
using Newtonsoft.Json;

namespace Microservice.StorageGateway.Infrastructure.Settings;

public class GoogleDriveSettings : IGoogleDriveSettings
{
    public IGoogleCredentialFile CredentialFile { get; init; } = new GoogleCredentialFile();

    public IEnumerable<string> Scopes { get; init; } = [];
}

public class GoogleCredentialFile : IGoogleCredentialFile
{
    [JsonProperty("type")]
    public string Type { get; set; } = default!;

    [JsonProperty("project_id")]
    public string ProjectId { get; set; } = default!;

    [JsonProperty("private_key_id")]
    public string PrivateKeyId { get; set; } = default!;

    [JsonProperty("private_key")]
    public string PrivateKey { get; set; } = default!;

    [JsonProperty("client_email")]
    public string ClientEmail { get; set; } = default!;

    [JsonProperty("client_id")]
    public string ClientId { get; set; } = default!;

    [JsonProperty("auth_uri")]
    public string AuthUri { get; set; } = default!;

    [JsonProperty("token_uri")]
    public string TokenUri { get; set; } = default!;

    [JsonProperty("auth_provider_x509_cert_url")]
    public string AuthProviderX509CertUrl { get; set; } = default!;

    [JsonProperty("client_x509_cert_url")]
    public string ClientX509CertUrl { get; set; } = default!;
}