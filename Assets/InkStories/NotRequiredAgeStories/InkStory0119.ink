VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

У меня была депрессия и я подсела на антидепрессанты. Как быть дальше?
* [Резко бросить принимать таблетки]
    -> res1
* [Медленно слезть с таблеток]
    -> res2
* [Заменить таблетки алкоголем]
    -> res3
* [Продолжать пить таблетки]
    -> res4

=== res1 === 
Ужасно! Деперссия вернулась! Больше я не буду так делать. Без таблеток я амеба!
~TextForLog = "У меня была депрессия и я подсела на антидепрессанты. Я решила резко бросить их принимать, и депрессия вернулась."
* [Ok]
-> END
=== res2 === 
Мне потребовалось много усилий воли, но я смогла покончить с зависимостью. Мой организм очистился
~TextForLog = "У меня была депрессия и я подсела на антидепрессанты. Я постепенно слезла с таблеток и смогла покончить с зависимостью от них."
* [Ok]
-> END
=== res3 === 
Это была плохая идея: теперь у меня не одна зависимость, а две
~TextForLog = "У меня была депрессия и я подсела на антидепрессанты. Я попыталась заменить таблетки алкоголем, но у меня развился алкоголизм и пришлось бороться сразу с двумя зависимостями."
* [Ok]
-> END
=== res4 === 
Видимо, мне придется пить их до конца жизни
~TextForLog = "У меня была депрессия и я подсела на антидепрессанты. Я даже не пыталась победить эту зависимость. Видимо, это на всю жизнь"
* [Ok]
-> END