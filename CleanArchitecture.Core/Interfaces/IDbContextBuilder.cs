namespace CleanArchitecture.Core.Interfaces;

public interface IDbContextBuilder
{
    public dynamic GetDbContextBasedOnType();
}
