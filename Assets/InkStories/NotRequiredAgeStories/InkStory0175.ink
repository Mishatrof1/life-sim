﻿VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Дочь-подросток убежала из дому. Что делать?
* [Обратиться в полицию и периодически звонить туда, чтобы узнать новости]
    -> res1
* [Обратиться в полицию и начать самостоятельные поиски ]
    -> res2
* [Бросить все и заняться поисками. Лично залезть в каждую дыру, где она могла бы быть]
    -> res3


=== res1 === 
Полиция не смогла найти мою дочь, а через 2 месяца та вернулась сама, беременная и заявила, что ее пыталичсь втянуть в занятие проституцией
~TextForLog = "Будучи подростком, моя дочь убежала из дома. Я обратилась в полицию, но найти ее не удалось. Через два месяца она вернулась беременной."
* [Ok]
-> END
=== res2 === 
Благодаря нашим совместным решительным действиям, удалось быстро найти дочь и вернуть домой. Еще немного и ее бы втянули в занятие проституцией
~TextForLog = "Будучи подростком, моя дочь убежала из дома. Я обратилась в полицию и сама начала активно искать. Благодаря нашим совместным решительным действиям, удалось быстро найти дочь."
* [Ok]
-> END
=== res3 === 
В таких делах, мать эффективнее полицейских. Я нашла ее на третий день. Раньше, чем с ней случилось, что-то плохое
~TextForLog = "Будучи подростком, моя дочь убежала из дома. Я лично залезла в каждую дыру, где она могла бы быть и нашла ее на третий день. Раньше, чем с ней случилось, что-то плохое."
* [Ok]
-> END