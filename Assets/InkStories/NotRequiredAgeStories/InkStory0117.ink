VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Работа"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я много работал над перспективным проектом, но один из коллег украл мои идеи и выдал за свои. Как поступить?
* [В следующий раз не буду столь доверчивым. Разработаю новый проект]
    -> res1
* [Обвиню негодяя в воровстве интеллектуальной собственности и докажу это!]
    -> res2
* [В ответ соблазню жену этого негодяя]
    -> res3
* [Я разбираюсь в автомобилях. Подстроить автокатастрофу - раз плюнуть]
    -> res4

=== res1 === 
Я пашу как раб на галерах, а этот негодяй наслаждается результатами моего труда. Тяжело, но поправимо
~TextForLog = "Я много работал над перспективным проектом, но один из коллег украл мои идеи и выдал за свои. Мне пришлось разрабатывать новый проект."
* [Ok]
-> END
=== res2 === 
Я не смог доказать вороровство, и в результате - негодяй в шоколаде, а моя репутация запятнана ложным наветом
~TextForLog = "Я много работал над перспективным проектом, но один из коллег украл мои идеи и выдал за свои. Я обвинил его, но не смог ничего доказать."
* [Ok]
-> END
=== res3 === 
О, это была сладкая месть! Когда этот негодяй узнал об измене жены, он чуть не покончил с собой
~TextForLog = "Я много работал над перспективным проектом, но один из коллег украл мои идеи и выдал за свои. Я отомстил негодяю тем, что трахнул его жену."
* [Ok]
-> END
=== res4 === 
Он разбил тачку и сам получил травмы. Пытался обвинить меня, но когда его спросили о мотивах, прикусил язык, т.к. пришлось бы объяснсть, за что я ему мщу.
~TextForLog = "Я много работал над перспективным проектом, но один из коллег украл мои идеи и выдал за свои. Я нарочно испортил ему автомобиль и он разбился. К счастью, не насмерть."
* [Ok]
-> END