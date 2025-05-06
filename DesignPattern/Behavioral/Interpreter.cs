using System;
using System.Globalization;

// Context: Biểu giá điện,nước
public class InterpreterContext
{
    public decimal GiaDien1kWh { get; set; } = 3000;  // 3.000 đồng/kWh
    public decimal GiaNuoc1m3 { get; set; } = 5000;   // 5.000 đồng/m³
}

// Giao diện biểu thức
public interface IExpression
{
    decimal Interpret(InterpreterContext context);
}

// Biểu thức cho tiền Điện
public class DienExpression : IExpression
{
    private readonly decimal soKWh;

    public DienExpression(decimal soKWh)
    {
        this.soKWh = soKWh;
    }

    public decimal Interpret(InterpreterContext context)
    {
        var tienDien = soKWh * context.GiaDien1kWh;
        Console.WriteLine($"- {soKWh} kWh × {context.GiaDien1kWh} = {tienDien} đ");
        return tienDien;
    }
}

// Biểu thức cho tiền Nước
public class NuocExpression : IExpression
{
    private readonly decimal soM3;

    public NuocExpression(decimal soM3)
    {
        this.soM3 = soM3;
    }

    public decimal Interpret(InterpreterContext context)
    {
        var tienNuoc = soM3 * context.GiaNuoc1m3;
        Console.WriteLine($"- {soM3} m³ × {context.GiaNuoc1m3} = {tienNuoc} đ");
        return tienNuoc;
    }
}

// Biểu thức phức thực hiện cộng tiền điện và nước
public class CongExpression : IExpression
{
    private readonly IExpression veTrai;
    private readonly IExpression vePhai;

    public CongExpression(IExpression veTrai, IExpression vePhai)
    {
        this.veTrai = veTrai;
        this.vePhai = vePhai;
    }

    public decimal Interpret(InterpreterContext context)
    {
        return veTrai.Interpret(context) + vePhai.Interpret(context);
    }
}

// Interpreter thông dịch chuỗi DSL: "100 kWh + 20 m³"
public class DSLInterpreter
{
    public static IExpression Parse(string input)
    {
        var tokens = input.Split('+', StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length != 2)
            throw new FormatException("Cú pháp không hợp lệ. VD: '100 kWh + 20 m³'");

        var expr1 = ParseDonVi(tokens[0].Trim());
        var expr2 = ParseDonVi(tokens[1].Trim());

        return new CongExpression(expr1, expr2);
    }

    private static IExpression ParseDonVi(string phan)
    {
        if (phan.EndsWith("kWh"))
        {
            var so = decimal.Parse(phan.Replace("kWh", "").Trim(), CultureInfo.InvariantCulture);
            return new DienExpression(so);
        }
        else if (phan.EndsWith("m³") || phan.EndsWith("m3"))
        {
            var so = decimal.Parse(phan.Replace("m³", "").Replace("m3", "").Trim(), CultureInfo.InvariantCulture);
            return new NuocExpression(so);
        }

        throw new NotSupportedException("Đơn vị không hỗ trợ: " + phan);
    }
}
