﻿using System;

namespace HomeSupply.Utils
{
    public static class SimplifyKeys
    {
        public const string PublicKey = "sbpb_N2ZhMTVlMWQtYmYzNy00ZmE1LTg1ODItMzQ3NjkwMzMyMzlk";
        public const string PrivateKey = "o5d+wNUrGQ5NoyOdQYYOmMpPDkCmyRn9Zq6hMzt6+055YFFQL0ODSXAOkNtXTToq";
        public const String sandbox = "https://sandbox.api.mastercard.com/fraud/loststolen/v1/account-inquiry?Format=XML";
    }

    public static class CurrencyInfo
    {
        public const String Currency = "BRL";
        public const String DescriptionPayment = "Pagamento Home supply";
    }
    public static class PaymentInfo
    {
        public const String PaymentSuccess = "Compra efetuada com sucesso!";
    }
}