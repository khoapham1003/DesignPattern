using System;

// Interface chung cho tất cả bộ sạc - Client Interface
internal interface ICharger
{
    void Charge();
}

// Bộ sạc Type C 
internal class USBTypeCCharger : ICharger
{
    public void ChargeWithUSBTypeC()
    {
        Console.WriteLine("Sạc thành công với cổng Type C.");
    }

    public void Charge()
    {
        ChargeWithUSBTypeC();
    }
}

//Adapters
// Adapter giúp cáp USB-C sạc được điện thoại Lightning
internal class USBTypeCToLightningAdapter : ICharger
{
    private readonly USBTypeCCharger _usbCCharger;

    public USBTypeCToLightningAdapter(USBTypeCCharger usbCCharger)
    {
        _usbCCharger = usbCCharger;
    }

    public void Charge()
    {
        Console.WriteLine("Đang chuyển đổi từ Type C sang Lightning...");
        _usbCCharger.ChargeWithUSBTypeC();
    }
}

// Adapter giúp cáp USB-C sạc được điện thoại Micro-USB
internal class USBTypeCToMicroUSBAdapter : ICharger
{
    private readonly USBTypeCCharger _usbCCharger;

    public USBTypeCToMicroUSBAdapter(USBTypeCCharger usbCCharger)
    {
        _usbCCharger = usbCCharger;
    }

    public void Charge()
    {
        Console.WriteLine("Đang chuyển đổi từ Type C sang Micro-USB...");
        _usbCCharger.ChargeWithUSBTypeC();
    }
}

//Services
// Điện thoại cũ sử dụng cổng Lightning
internal class LightningPhone
{
    private ICharger _charger;

    public LightningPhone(ICharger charger)
    {
        _charger = charger;
    }

    public void ChargePhone()
    {
        Console.WriteLine("\nĐiện thoại cổng Lightning đang cố gắng sạc...");
        _charger.Charge();
    }
}

// Điện thoại cũ sử dụng cổng Micro-USB
internal class MicroUSBPhone
{
    private ICharger _charger;

    public MicroUSBPhone(ICharger charger)
    {
        _charger = charger;
    }

    public void ChargePhone()
    {
        Console.WriteLine("\nĐiện thoại cổng Micro-USB đang cố gắng sạc...");
        _charger.Charge();
    }
}

// Điện thoại Type C mới
internal class TypeCPhone
{
    private ICharger _charger;

    public TypeCPhone(ICharger charger)
    {
        _charger = charger;
    }

    public void ChargePhone()
    {
        Console.WriteLine("\nĐiện thoại cổng Type C đang cố gắng sạc...");
        _charger.Charge();
    }
}
