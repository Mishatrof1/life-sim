VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

В старшей школе один крендель отбил у меня девчонку. А сейчас мы с ним коллеги по работе. Как построить взаимоотношения?
* [Вести себя дружелюбно, вместе вспомнить тот случай и посмеяться]
    -> res1
* [Соблазнить его жену в ответ на старые обиды]
    -> res2
* [Вести себя с ним ровно и профессионально. Ничего личного]
    -> res3
* [Найти повод и набить ему морду]
    -> res4

=== res1 === 
Он в ответ тоже проявил дружелюбие и рассказал подробности той истории. Мне стало не до смеха. Я еле сдержался, чтобы не дать ему в морду
~TextForLog = "Еще в старшей школе один крендель отбил у меня девчонку. А потом мы оказались с ним коллегами по работе. Я решил, что дело прошлое, и вел себя с ним дружелюбно. Но он напомнил мне подробности и я чуть ему не вмазал."
* [Ok]
-> END
=== res2 === 
У меня не получилось. Жена ему рассказала, он полез драться и я с удовольствием набил ему морду
~TextForLog = "Еще в старшей школе один крендель отбил у меня девчонку. А потом мы оказались с ним коллегами по работе. Я в ответ соблазнил его жену. Он полез драться и я набил ему морду. Двойное удовольствие!"
* [Ok]
-> END
=== res3 === 
Это хорошо, что мы вместе работаем. Есть возможность потренировать выдержку и хладнокровие
~TextForLog = "Еще в старшей школе один крендель отбил у меня девчонку. А потом мы оказались с ним коллегами по работе. Я счел это хорошей возможностью потренировать выдержку и не стал выходить за рамки профессиональных отношений."
* [Ok]
-> END
=== res4 === 
Ну, кто ж виноват, что он не сумел извлечь корень из 3127. Так что, дебилом я назвал его справедливо, и в драку он полез первый. Лол, кулаки саднят, а сердце поет
~TextForLog = "Еще в старшей школе один крендель отбил у меня девчонку. А потом мы оказались с ним коллегами по работе. Я нашел повод затеять ссору и набил ему морду. Получил удовольствие."
* [Ok]
-> END