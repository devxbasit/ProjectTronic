using Microsoft.Data.SqlClient;

namespace ProjectTronic.Backend.Core.Services.IService;

public interface ISqlConnectionFactory
{
    public SqlConnection Create();
}