
namespace ASODotNetTrainingBatch1.Shared
{
    public interface IDbV2Service
    {
        int Execute(string query, object? parameters = null);
        List<ASO> Query<ASO>(string query, object? parameters = null);
    }
}