namespace CsharpUtilsLib.External.CorreiosShippings;

public sealed class CorreiosShippingData : BaseExternalData<string>
{
    protected override string Url => "http://ws.correios.com.br/calculador/CalcPrecoPrazo.aspx?nCdEmpresa=&sDsSenha=&sCepOrigem={0}&sCepDestino={1}&nVlPeso={2}&nCdFormato={3}&nVlComprimento={4}&nVlAltura={5}&nVlLargura={6}&sCdMaoPropria={7}&nVlValorDeclarado={8}&sCdAvisoRecebimento={9}&nCdServico={10}&nVlDiametro={11}&StrRetorno=xml&nIndicaCalculo={12}";

    public async Task<CorreiosShipping> GetByShippingDetails(CorreiosShippingRequest request)
    {
        string html = await Request(endpoint: null!, request.OriginCEP,
                                                     request.DestinyCEP,
                                                     request.Weight.ToString(),
                                                     request.Format.GetEnumValue().ToString(),
                                                     request.Length.ToString(),
                                                     request.Height.ToString(),
                                                     request.Width.ToString(),
                                                     request.OwnHand ? "s" : "n",
                                                     request.DeclaredValue.ToString(),
                                                     request.ReceiptNotice ? "s" : "n",
                                                     request.Service.GetEnumValue().ToString(),
                                                     request.Diameter.ToString(),
                                                     request.Indicator.GetEnumValue().ToString());

        return XML.XML.DeserializeXmlToObject<CorreiosShipping>(html);
    }
}