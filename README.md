# ___POS система заказов для кофейни___
## У нас есть 3 окна 
1. окно для заказов,
2. окно для сборщика, 
3. окно статуса готвности закзаов.

#### Суть работы данной программы: Клиент делает заказ в меню заказов, далее все это отправляется в базу данных, потом из базы данных идет в окно сборщика, следующим этапом в зависимости от готовности заказа сборщик нажимает на кнопку "готово" и также, если заказ оплачен, то он нажимает на соотвествующую кнопку, в следсвии чего поаченный заказ пропадает из окна ожиданий.
---
# ___Основноые инструменты___
Данная работа сделана на C# через Windows Presentation Foundation, а база данных написана на SQLlite.
# ___Скриношты данной программы___
1) Статус-Меню
![Order Menu](https://sun9-72.userapi.com/impg/DhvuE7v5qqcRRMTdGUak_SKy9TW9_Of-qcX8Rw/l3U6a4W3XGI.jpg?size=977x548&quality=95&sign=26b0c8117f400358478f29e5655d32c9&type=album)
2. Окно заказов
![](https://sun9-66.userapi.com/impg/fmhVbz-qMHwZ0jJh77AcvdoHt6IkTD3n-Li9bA/7Mm6Bi1USU0.jpg?size=1342x967&quality=95&sign=d49fb5540ceba45dbe03240253492c16&type=album)
3. Касса
![](https://sun9-26.userapi.com/impg/C2l8ZFlmRTtn_aNZdelYt47Wi5DlPmyHbkVDtw/tfZavH36dis.jpg?size=1103x756&quality=95&sign=aa1d94c2c548bec39c6ad6c7e49b6500&type=album)
4. База данных продуктов
![](https://sun9-49.userapi.com/impg/ObL7rZv6HJn9YX-Z8EWKmAPJ8X6aVvqvlUHsJw/gfAUTV8M9Z4.jpg?size=1255x807&quality=95&sign=020044bf9074ec2b142728203e08ec26&type=album)
:ok_hand:
---
# Как запустить данный проект:
1. Скачиваете Microsoft VS 2022/2019/2017 один из этих IDE
2. В меню установщика нажимаете на этот пункт
3. ![](https://sun9-6.userapi.com/impg/TckIh-5wdvvIFFjvANjuiInv9-fo2l51wOB61g/7ZQET1Fmzd4.jpg?size=1532x772&quality=95&sign=50940a1d91dd3e7c5527eac627a0e2bd&type=album)
4. Скачиваете из репозитория данный проект и нажимаете на Pos_Cafe_system.sln
5. запускаете проект.
6. Все.
