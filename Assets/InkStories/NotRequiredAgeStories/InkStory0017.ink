VAR AgeMinCondition = 7
VAR AgeMaxCondition = 10
VAR SexCondition = "Male"
VAR GroupTitle = "Семья"
VAR TextForLog = ""

VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я играл на нашем заднем дворе и разбил любимого садового гнома мамы. Что делать?
* [Соврать маме, что я ничего об этом не знаю]
    -> res1
* [Соврать, что это соседская собака забежала к нам и разбила гнома]
    -> res2
* [Убежать из дома куда глаза глядят]
    -> res3
* [Честно признаться и попросить прощения]
    -> res4

=== res1 === 
К несчастью, соседка видела, как все было и рассказала маме. Теперь мама меня ненавидит, я чувствую
~TextForLog = "Во время игры, я разбил любимого садового гнома мамы. Я соврал, что это не я, но меня выдала соседка, которая все видела."
* [Ok]
-> END
=== res2 === 
Оказалось, что соседи и их собака весь день были за городом. Моя ложь раскрыта и я жду приговора...
~TextForLog = "Во время игры, я разбил любимого садового гнома мамы. Я соврал, что это соседская собака. Но обман был раскрыт, т.к. соседи и их собака весь день были за городом."
* [Ok]
-> END
=== res3 === 
Весь день я скитался, к вечеру меня поймала полиция. Худший день в моей жизни
~TextForLog = "Во время игры, я разбил любимого садового гнома мамы. После этого я убежал из дому, но меня поймала полиция и вернула домой."
* [Ok]
-> END
=== res4 === 
Мама долго ругалась, но в конце концов простила меня и поцеловала. Happy end!
~TextForLog = "Во время игры, я разбил любимого садового гнома мамы и честно признался в содеянном. Мама долго ругала меня, но в конце концов простила."
* [Ok]
-> END