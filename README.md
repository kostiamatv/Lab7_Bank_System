# Lab7_Bank_System
Лабораторная 7
Есть несколько Банков, которые предоставляют финансовые услуги по операциям с деньгами. В банке есть Счета и Клиенты. 
У клиента есть имя, фамилия, адрес и номер паспорта. 
Счета бывают трёх видов: Дебетовый счет, Депозит и Кредитный счет. 
Каждый счет принадлежит какому-то клиенту. 
Дебетовый счет – обычный счет с фиксированным процентом на остаток. 
Деньги можно снимать в любой момент, в минус уходить нельзя. Комиссий нет.
Депозит – счет, с которого нельзя снимать и переводить деньги до тех пор, пока не закончится его срок (пополнять можно). 
Процент на остаток зависит от изначальной суммы, например, если открываем депозит до 50 000 р. - 5%, если от 50 000 р. до 100 000 р. - 5.5%, больше 100 000 р. - 6%. Комиссий нет. 
Кредитный счет – имеет кредитный лимит, в рамках которого можно уходить в минус (в плюс тоже можно). Процента на остаток нет. Есть фиксированная комиссия за использование, если клиент в минусе. 
Процент на остаток начисляется ежедневно от текущей суммы в этот день, но выплачивается раз в месяц (и для дебетовой карты и для депозита). 
Например, 3.65% годовых. Значит в день: 3.65% / 365 дней = 0.01%. У клиента сегодня 100 000 р. на счету - запомнили, что у него уже 10 р. Завтра ему пришла ЗП и стало 200 000 р. За этот день ему добавили ещё 20 р. На следующий день он купил себе новый ПК и у него осталось 50 000 р. - добавили 5 р. 
Таким образом, к концу месяца складываем все, что запоминали. Допустим, вышло 300 р. - эта сумма добавляется к счету или депозиту в текущем месяце. Разные банки предлагают разные условия.
В каждом банке известны величины процентов и комиссии. 
Каждый счет должен предоставлять механизм снятия, пополнения и перевода денег (то есть счетам нужны некоторые идентификаторы). Если при создании счета у клиента не указаны адрес или номер паспорта, мы объявляем такой счет (любого типа) сомнительным, и запрещаем операции снятия и перевода выше определенной суммы (у каждого банка своё значение). 
Периодически банки проводят операции по выплате процентов и вычету комиссии. 
Еще обязательный механизм, который должны иметь банки - отмена транзакций. 
Если вдруг выяснится, что транзакция была совершена злоумышленником, то такая транзакция должна быть отменена.
