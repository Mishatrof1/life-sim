VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

У нас с бойфрендом все серьезно, но у него ужасная мать, с которой трудно ужиться. Как быть?
* [В этой ситуации замужество невозможно, а когда перспектив в отношениях нет, их надо рвать]
    -> res1
* [Попытаюсь наладить отношения с его мамой]
    -> res2
* [Поставлю его маму на место, а иначе никаких отношений с cыном]
    -> res3
* [Буду терпеть придирки мамы при встрече. Жить мы все равно будем отдельно от нее]
    -> res4

=== res1 === 
Я некоторое время страдала, но время все залечило
~TextForLog = "У нас с бойфрендом наладились серьезные отношения, но у него ужасная мать, с которой мне трудно было ужиться. Пришлось бросить бойфренда."
* [Ok]
-> END
=== res2 === 
Она восприняла мое дружелюбие, как покорность, я на нее накричала, а сын встал на ее сторону. Маменькин сынок, такой мне не нужен
~TextForLog = "У нас с бойфрендом наладились серьезные отношения, но у него ужасная мать, с которой мне трудно было ужиться. Я попыталась ужиться со старой ведьмой, но из этого ничего не вышло. Я ушла."
* [Ok]
-> END
=== res3 === 
Я наорала на маму, наорала на сына, когда он встал на ее сторону и ушла. Пусть ищут себе дуру, а я умная
~TextForLog = "У нас с бойфрендом наладились серьезные отношения, но у него ужасная мать, с которой мне трудно было ужиться. Я попыталась поставить его маму наместо, в результате мы навсегда расстались с бойфрендом."
* [Ok]
-> END
=== res4 === 
Зря потратила время на этого придурка. Он дал мне понять, что мама ему важнее меня. Пришлось отшить
~TextForLog = "У нас с бойфрендом наладились серьезные отношения, но у него ужасная мать, с которой мне трудно было ужиться. Я попыталась терпеть его мамашу, но она начала садиться на голову. Пришлось отшить сыночка."
* [Ok]
-> END