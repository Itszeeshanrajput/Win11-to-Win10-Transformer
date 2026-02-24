using System;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Win10_Transformer.Core
{
    public class UpdateCheckResult
    {
        public bool IsUpdateAvailable { get; set; }
        public string LatestVersion { get; set; } = string.Empty;
    }

    public class GitHubRelease
    {
        public string tag_name { get; set; } = string.Empty;
    }

    public static class UpdateChecker
    {
        private const string DefaultRepo = "your-username/your-repo";
        private static readonly string CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        public static async Task<UpdateCheckResult> CheckForUpdatesAsync()
        {
            var result = new UpdateCheckResult { IsUpdateAvailable = false, LatestVersion = "Unknown" };

            string ownerAndRepo = DefaultRepo;
            try
            {
                // Try to get repo from assembly metadata if available
                var metadata = Assembly.GetExecutingAssembly().GetCustomAttributes<AssemblyMetadataAttribute>();
                var repoUrl = System.Linq.Enumerable.FirstOrDefault(metadata, m => m.Key == "RepositoryUrl")?.Value;

                if (!string.IsNullOrEmpty(repoUrl) && Uri.TryCreate(repoUrl, UriKind.Absolute, out var uri))
                {
                    ownerAndRepo = uri.AbsolutePath.Trim('/');
                }
            }
            catch { /* Fallback to default */ }

            var requestUri = $"https://api.github.com/repos/{ownerAndRepo}/releases/latest";

            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Win10-Transformer-App");

                var response = await client.GetStringAsync(requestUri);
                var release = JsonSerializer.Deserialize<GitHubRelease>(response);

                if (release != null)
                {
                    var latestVersion = new Version(release.tag_name.TrimStart('v'));
                    var currentVersion = new Version(CurrentVersion);

                    if (latestVersion > currentVersion)
                    {
                        result.IsUpdateAvailable = true;
                        result.LatestVersion = release.tag_name;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Error checking for updates: {ex.Message}");
            }

            return result;
        }
    }
}
