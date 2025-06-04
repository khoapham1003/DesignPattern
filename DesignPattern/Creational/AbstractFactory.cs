
interface MonAnFactory
{
    HuTieu LayToHuTieu();
    My LayToMy();
}

interface HuTieu
{
    string GetModelDetails();
}
interface My
{
    string GetModelDetails();
}

class HuTieuNac : HuTieu
{
    public string GetModelDetails()
    {
        return "Hủ tiếu Nạc của em đây!";
    }
}
class HuTieuGio : HuTieu
{
    public string GetModelDetails()
    {
        return "Hủ tiếu Giò của em đây!";
    }
}
class MyNac : My
{
    public string GetModelDetails()
    {
        return "Mỳ Nạc của em đây!";
    }
}
class MyGio : My
{
    public string GetModelDetails()
    {
        return "Mỳ Giò của em đây";
    }
}

class LoaiGioFactory : MonAnFactory
{
    public HuTieu LayToHuTieu()
    {
        return new HuTieuGio();
    }
    public My LayToMy()
    {
        return new MyGio();
    }
}
class LoaiNacFactory : MonAnFactory
{
    public HuTieu LayToHuTieu()
    {
        return new HuTieuNac();
    }
    public My LayToMy()
    {
        return new MyNac();
    }
}
class Client_FactoryMethod
{
    HuTieu hutieu;
    My my;
    public Client_FactoryMethod(MonAnFactory factory)
    {
        hutieu = factory.LayToHuTieu(); my = factory.LayToMy();
    }
    public string GetHuTieuDetails()
    {
        return hutieu.GetModelDetails();
    }
    public string GetMyDetails()
    {
        return my.GetModelDetails();
    }
}
