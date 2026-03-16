# Admin Sistemi Entegrasyon Notu

Bu backend, **admin panelinin ayrı bir proje** (ayrı frontend/backend portal) olarak çalışması için hazırlandı.

## Ayrı Proje Mimarisi
- Ana API ile Admin Panel aynı veritabanını ve JWT kimlik doğrulamasını paylaşır.
- Admin paneli farklı origin'de çalışabileceği için CORS politikası açılmıştır (`AdminAndClient`).
- Admin işlemleri `api/admin/*` altında izole edilmiştir.

## Admin API Uç Noktaları
- `GET /api/admin/stats`
- `GET /api/admin/users`
- `PUT /api/admin/users/role`
- `PUT /api/admin/users/{id}/toggle-status`
- `GET /api/admin/reports`
- `PUT /api/admin/reports/{id}/resolve`
- `GET /api/admin/messages`

> Tüm bu endpointler `Admin` rolü gerektirir.

## Tercüman Dashboard
- `GET /api/translator/dashboard`
- Dönen alanlar:
  - `totalMessages`
  - `unreadMessages`
  - `totalFavorites`
  - `totalViews`

## Response Standardı
Yeni admin ve translator dashboard cevapları aşağıdaki standardı kullanır:

```json
{
  "success": true,
  "data": { },
  "message": "İşlem başarılı"
}
```

## Gender Uyumluluğu
- `Gender` enum'u integer olarak işlenir:
  - `0: NotSpecified`
  - `1: Male`
  - `2: Female`

