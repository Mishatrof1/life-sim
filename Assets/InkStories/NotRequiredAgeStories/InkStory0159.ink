VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я был у любовницы, когда неожиданно вернулся ее муж. Что делать?
* [Ничего не поделаешь, придется объясняться]
    -> res1
* [Схвачу свою одежду в охапку и спрячусь под кроватью]
    -> res2
* [Быстро оденусь и выберусь наружу через окно]
    -> res3
* [Притворюсь сантехником и буду чинить кран на кухне]
    -> res4

=== res1 === 
Он набросился на меня с кулаками и хорошо отделал. Не знаю, стоил ли секс с его женой трех зубных имплантов?
~TextForLog = "Я был у любовницы, когда неожиданно вернулся ее муж. Я хотел с ним объясниться добром, но он меня избил."
* [Ok]
-> END
=== res2 === 
Жена отправила своего куколда за покупками, а я сумел незамеченным покинуть их дом
~TextForLog = "Я был у любовницы, когда неожиданно вернулся ее муж. Я спрятался под кроватью. Жена отправила своего куколда за покупками, а я сумел незамеченным покинуть их дом."
* [Ok]
-> END
=== res3 === 
Куколд заметил меня и погнался. Хорошо, что я быстро бегаю
~TextForLog = "Я был у любовницы, когда неожиданно вернулся ее муж. Я удрал через окно. Куколд гнался за мной, но я бегаю быстрее."
* [Ok]
-> END
=== res4 === 
Я настолько убедительно изображал сантехника, что куколд еще и заплатил мне за работу
~TextForLog = "Я был у любовницы, когда неожиданно вернулся ее муж. Я убедительно изобразил сантехника, починил им кран на кухне, куколд ничего не заподозрил."
* [Ok]
-> END