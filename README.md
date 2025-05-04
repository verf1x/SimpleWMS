# Simple WMS

### Описание проекта
Проект представляет собой простейший WMS (Warehouse Management System) для управления складом маркетплейса, написанный с использованием .NET 9.0 и ASP.NET Core Web API, SQL Server.

### Механика работы склада
Склад состоит из нескольких зон: зона приемки, две зоны хранения и зона отгрузки.
На приемке принимаются товары, которые затем распределяются по зонам хранения. Из зон хранения товары отгружаются в зону отгрузки, из которой они отгружаются либо на пункты выдачи заказов курьерами, либо отправляются на другие склады для дальнейшего распределения.

### Пример работы на складе
За создание грузов, создание перевозки и отправление на наш склад по-хорошему отвечает другой склад, но так как у нас нет другого склада, который отправит нам машину с перевозкой, создадим ее вручную:

- Сначала создадим несколько товаров, которые будут помещены в груз:
`POST /api/Instances/expected`
```json
[
  {
    "shippingNumber": "SHIP-00001234-0001",
    "sortType": "Sort"
  }
]
```
```json
[
  {
    "shippingNumber": "SHIP-00001234-0002",
    "sortType": "Sort"
  }
]
```
- Создадим груз, который будет содержать эти товары:
`POST /api/Cargo`
```json
{
  "cargoName": "5898D3AF-CD82-47C8-BF3D-AA7CA7E9DB3D",
  "cargoBarcode": "CARGO-001"
}
```
- Добавим в груз товары:
`POST /api/Cargo/{id}/add-instance, в качестве id передаем Guid груза`
```json
{
  "instanceBarcode": "SHIP-00001234-0001"
}
```
```json
{
  "instanceBarcode": "SHIP-00001234-0002"
}
```
- Закроем груз:
`POST /api/Cargo/{id}/close`


- Создадим машину с перевозкой, которая будет содержать груз:
`POST /api/Transportation`
```json
{
  "transportationNumber": 1313,
  "routeA": "Moscow",
  "routeB": "Samara",
  "vehicleData": "А345УВ777",
  "shipmentDate": "2025-05-04"
}
```
- Привяжем груз к машине с перевозкой:
`POST /api/transportation/{transportationId}/cargo/{cargoId}`


- Примем созданную где-то перевозку на наш склад:
`POST /api/Receiving/transportation`
```json
{
  "transportationId": "25076f12-e454-42cd-a3ef-cac30854d732"
}
```

- Теперь примем груз из перевозки:
`POST /api/Receiving/cargo`
```json
{
  "cargoBarcode": "CARGO-002"
}
```
- Примем товар из груза отсканировав стол приемки и ШК товара:
`POST /api/Receiving/instance`
```json
{
  "instanceBarcode": "SHIP-00001234-0010",
  "tableQr": "TABLE-01"
}
```
- Разместим товар в зоне хранения:
- Для этого создадим мобильный контейнер
`POST /api/MobileContainer`
```json
{
  "number": "1-1"
}
```
- Поместим сам товар в него
`POST /api/Placement/mc`
```json
{
  "instanceBarcode": "SHIP-00001234-0010",
  "mcNumber": "1-1"
}
```
- Теперь допустим мы разместили множество товаров на нашем складе, нам нужно их отгрузить.
- Для этого создадим груз нашего склада
`POST /api/Cargo`
```json
{
  "cargoName": "Pallet C",
  "cargoBarcode": "CARGO-003"
}
```
- Добавим в груз товар:
`POST /api/Cargo/{id}/add-instance`
```json
{
  "instanceBarcode": "SHIP-00001234-0010"
}
```
- Закрываем груз:
`POST /api/Cargo/{id}/close`

- Отправляем груз на отгрузку:
`POST /api/Shipping/cargo/{cargoId}`