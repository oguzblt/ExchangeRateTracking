# 💱 Kur Fiyatı Takip API'si (Currency Rate Tracker API)

.NET 8 ile geliştirilen bu Web API projesi, [ExchangeRate-API](https://www.exchangerate-api.com/) servisini kullanarak anlık döviz kurlarını getirir. Belirli favori para birimlerine filtreleme, API key ile dış servis kullanımı, logging ve hata yönetimi gibi temel yazılım geliştirme pratiklerini içermektedir.

---

## 🚀 Özellikler

- 🌐 Gerçek zamanlı döviz kuru bilgisi
- 🔑 ExchangeRate-API ile API Key kullanımı
- ✅ Favori kurlar (USD, EUR, TRY, GBP) filtrelenerek döner
- 🛡️ Hata yönetimi ve validasyon
- 📜 Swagger ile kolay test edilebilir
- 🧾 Temiz ve sade yapı

---

## 🧪 Nasıl Test Edilir?

1. Projeyi çalıştır:
   ```bash
   dotnet run
2. Tarayıcıda Swagger UI açılır:

https://localhost:xxxx/swagger

3./api/currency?base=USD gibi bir istek göndererek sonucu test edebilirsin.

4. appsettings.json içinde kendi ExchangeRate-API anahtarını gir:

{
  "ExchangeRateApiKey": "YOUR_API_KEY_HERE"
}

📁 Kullanılan Teknolojiler

.NET 8 Web API
HttpClient
System.Text.Json
Swagger (Swashbuckle)

👤 Geliştirici
Ad: Oğuzhan Bulut
LinkedIn: linkedin.com/in/oguzhanbulutt
