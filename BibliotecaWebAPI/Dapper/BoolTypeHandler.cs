using Dapper;
using System.Data;

public class BoolTypeHandler : SqlMapper.TypeHandler<bool>
{
    public override void SetValue(IDbDataParameter parameter, bool value)
    {
        parameter.Value = value ? 1 : 0;
    }

    public override bool Parse(object value)
    {
        return value is string strBit && strBit.Equals("1");
    }
}
