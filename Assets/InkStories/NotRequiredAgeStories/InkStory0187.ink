VAR AgeMinCondition = 50
VAR AgeMaxCondition = 67
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Глядя на себя в зеркало, я осознала, что жизнь скоро закончится, а я так мало видела и так мало узнала. Что предпринять?
* [Заняться дайвингом]
    -> res1
* [Отправиться в путешествие автостопом]
    -> res2
* [Попробовать экзотические разновидности секса]
    -> res3
* [Затяжные прыжки с парашютом - вот выход]
    -> res4

=== res1 === 
Я открыла для себя подводный мир. Он такой замечательный.  Вот чего мне не доставало в жизни
~TextForLog = "С приближением старости я стала понимать, как мало повидала в жизни. Я занялась дайвингом и открыла для себя подводный мир. Вот чего мне не доставало в жизни."
* [Ok]
-> END
=== res2 === 
Я побывала во многих странах, испытала много невзгод и приключений. И теперь вернулась домой, испытывая те же чувства, что и Форест Гамп в свое время
~TextForLog = "С приближением старости я стала понимать, как мало повидала в жизни. Я отправилась в путешествие автостопом. Я побывала во многих странах, испытала много невзгод и приключений. И  вернулась домой."
* [Ok]
-> END
=== res3 === 
Это было плохое решение.  После всей этой грязи чувствую себя асексуалкой
~TextForLog = "С приближением старости я стала понимать, как мало повидала в жизни. Я попробовала экзотические разновидности секса, но мне не понравилось."
* [Ok]
-> END
=== res4 === 
Мне хватило двух прыжков, чтобы осознать: прыжки - кал, а выход это альпинизм!
~TextForLog = "С приближением старости я стала понимать, как мало повидала в жизни. Я решила заняться прыжками с парашютом, но мне не понравилось и я переключилась на альпинизм."
* [Ok]
-> END