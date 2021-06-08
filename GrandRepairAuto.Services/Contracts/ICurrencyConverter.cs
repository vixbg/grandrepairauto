using System;

namespace GrandRepairAuto.Services.Contracts
{
    public interface ICurrencyConverter
    {
        double GetCurrencyExchange(String localCurrency, String foreignCurrency);
    }
}