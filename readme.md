## Пример работы WebApi NET 9 и MongoDB

Примечания:
1) Важно! В проекте есть два файла с настройками:
appsettings.json
и
appsettings.Development.json

При отладке из Visual Studio - используются настройки из файла **'appsettings.Development.json'**
И соответственно - база будет называться так как указано именно в этом файле: "MongoDBStore77"


2) Порты для MongoDB настроены так:
27044:27017

Это означает:
- порт **27044** - используется для внешнего подключения   
Например: Для подключения из программы "MongoDB Compass" надо указать такой путь к базе, запущенной в контейнере: "mongodb://localhost:27044/"
