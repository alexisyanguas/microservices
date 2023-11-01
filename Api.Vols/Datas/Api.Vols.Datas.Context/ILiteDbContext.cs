using LiteDB;

namespace Api.Vols.Datas.Context
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }

    }
}
