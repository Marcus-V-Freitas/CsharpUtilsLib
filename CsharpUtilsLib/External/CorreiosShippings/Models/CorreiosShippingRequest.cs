namespace CsharpUtilsLib.External.CorreiosShippings.Models;

public sealed class CorreiosShippingRequest
{
    public string OriginCEP { get; set; }
    public string DestinyCEP { get; set; }
    public double Weight { get; set; }
    public ShippingFormat Format { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public bool OwnHand { get; set; }
    public double DeclaredValue { get; set; }
    public bool ReceiptNotice { get; set; }
    public ShippingService Service { get; set; }
    public double Diameter { get; set; }
    public ShippingIndicator Indicator { get; set; }

    public CorreiosShippingRequest(string originCEP, string destinyCEP, double weight, ShippingFormat format, double length, double height, double width, bool ownHand, double declaredValue, bool receiptNotice, ShippingService service, double diameter, ShippingIndicator indicator)
    {
        OriginCEP = originCEP;
        DestinyCEP = destinyCEP;
        Weight = weight;
        Format = format;
        Length = length;
        Height = height;
        Width = width;
        OwnHand = ownHand;
        DeclaredValue = declaredValue;
        ReceiptNotice = receiptNotice;
        Service = service;
        Diameter = diameter;
        Indicator = indicator;
    }

}